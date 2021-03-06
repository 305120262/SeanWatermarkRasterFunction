// Copyright 2015 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at <your ArcGIS install location>/DeveloperKit10.3/userestrictions.txt.
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.CATIDs;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Geodatabase;
using DolphinStudio;

namespace DolphinStudioUI
{
    [Guid("755ED2FF-920F-4FF3-87C3-2E1207F25EA8")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("DolphinStudioUI.WatermarkFunctionUIClass")]
    [ComVisible(true)]
    public class WatermarkFunctionUIClass: IComPropertyPage
    {
        #region Private Members
        WatermarkFunctionUIForm myForm; // The UI form object.
        IWatermarkFunctionArguments myArgs; // The watermark function arguments object.
        int myPriority; // Priority for the UI page.
        IComPropertyPageSite myPageSite;
        string myHelpFile; // Location for the help file if needed.
        UID mySupportedID; // UID for the Raster function supported by the property page.
        bool templateMode; // Flag to specify template mode.
        bool isFormReadOnly; // Flag to specify whether the UI is in Read-Only Mode.

        IRasterFunctionVariable myRasterVar; // Variable for the Raster property.
        IRasterFunctionVariable myBlendPercentageVar; // Variable for the BlendPercentage property.
        IRasterFunctionVariable myWatermarkImagePathVar; // Variable for WatermarkImagePath property.
        IRasterFunctionVariable myXGapVar;
        IRasterFunctionVariable myYGapVar;
        #endregion

        public WatermarkFunctionUIClass()
        {
            myForm = new WatermarkFunctionUIForm();
            myArgs = null;
            myPriority = 100;
            myPageSite = null;
            myHelpFile = "";
            mySupportedID = new UIDClass();
            mySupportedID.Value = "{" + "25BE29A6-AAF9-496E-AE73-130D5947682D" + "}";
            templateMode = false;
            isFormReadOnly = false;

            myRasterVar = null;
            myBlendPercentageVar = null;
            myWatermarkImagePathVar = null;
            myXGapVar = null;
            myYGapVar = null;
        }

        #region IComPropertyPage Members
        /// <summary>
        /// Activate the form. 
        /// </summary>
        /// <returns>Handle to the form</returns>
        public int Activate()
        {
            if (templateMode)
            {
                // In template mode, set the form values using the RasterFunctionVariables
                myForm.BlendPercentage = (double)myBlendPercentageVar.Value;
                myForm.WatermarkImagePath = (string)myWatermarkImagePathVar.Value;
                myForm.XGap = (int)myXGapVar.Value;
                myForm.YGap = (int)myYGapVar.Value;
                myForm.InputRaster = myRasterVar;
            }
            else
            {
                // Otherwise use the arguments object to update the form values.
                myForm.XGap = myArgs.XGap ;
                myForm.YGap = myArgs.YGap;
                myForm.BlendPercentage = myArgs.BlendPercentage;
                myForm.WatermarkImagePath = myArgs.WatermarkImagePath;
                myForm.InputRaster = myArgs.Raster;
            }
            myForm.UpdateUI();
            myForm.Activate();
            return myForm.Handle.ToInt32();
        }

        /// <summary>
        /// Check if the form is applicable to the given set of objects. In this case
        /// only the Raster function object is used to check compatibility.
        /// </summary>
        /// <param name="objects">Set of object to check against.</param>
        /// <returns>Flag to specify whether the form is applicable.</returns>
        public bool Applies(ESRI.ArcGIS.esriSystem.ISet objects)
        {
            objects.Reset();
            for (int i = 0; i < objects.Count; i++)
            {
                object currObject = objects.Next();
                if (currObject is IRasterFunction)
                {
                    IRasterFunction rasterFunction = (IRasterFunction)currObject;
                    if (rasterFunction is IPersistVariant)
                    {
                        IPersistVariant myVariantObject = (IPersistVariant)rasterFunction;
                        // Compare the ID from the function object with the ID's supported by this UI page.
                        if (myVariantObject.ID.Compare(mySupportedID))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Apply the properties set in the form to the arguments object.
        /// </summary>
        public void Apply()
        {
            if (!isFormReadOnly) // If the form is read only, do not update.
            {
                if (templateMode)
                {
                    // If in template mode, use the values from the page to
                    // update the variables.
                    if (myForm.InputRaster != null)
                    {
                        if (myForm.InputRaster is IRasterFunctionVariable)
                            myRasterVar = (IRasterFunctionVariable)myForm.InputRaster;
                        else
                            myRasterVar.Value = myForm.InputRaster;
                    }
                    myBlendPercentageVar.Value = myForm.BlendPercentage;
                    myWatermarkImagePathVar.Value = myForm.WatermarkImagePath;
                    myXGapVar.Value = myForm.XGap;
                    myYGapVar.Value = myForm.YGap;
                    // Then set the variables on the arguments object.
                    IRasterFunctionArguments rasterFunctionArgs =
                        (IRasterFunctionArguments)myArgs;
                    rasterFunctionArgs.PutValue("Raster", myRasterVar);
                    rasterFunctionArgs.PutValue("BlendPercentage", myBlendPercentageVar);
                    rasterFunctionArgs.PutValue("XGap", myXGapVar);
                    rasterFunctionArgs.PutValue("YGap", myYGapVar);
                    rasterFunctionArgs.PutValue("WatermarkImagePath", myWatermarkImagePathVar);
                }
                else if (myArgs != null)
                {
                    // If not in template mode, update the arguments object
                    // with the values from the form.
                    myArgs.BlendPercentage = myForm.BlendPercentage;
                    myArgs.XGap = myForm.XGap;
                    myArgs.YGap = myForm.YGap;
                    myArgs.WatermarkImagePath = myForm.WatermarkImagePath;
                    if (myForm.InputRaster != null)
                        myArgs.Raster = myForm.InputRaster;
                }
            }

            myForm.IsFormDirty = false;
        }

        /// <summary>
        /// Do not set any properties set in the form
        /// </summary>
        public void Cancel()
        {
            myForm.IsFormDirty = false;
        }

        /// <summary>
        /// Shut down the form and destroy the object.
        /// </summary>
        public void Deactivate()
        {
            myForm.Close();
            myForm.Dispose();
            myForm = null;
        }

        /// <summary>
        /// Return the height of the form.
        /// </summary>
        public int Height
        {
            get { return myForm.Height; }
        }

        /// <summary>
        /// Returns the path to the helpfile associated with the form.
        /// </summary>
        public string HelpFile
        {
            get { return myHelpFile; }
        }

        /// <summary>
        /// Hide the form.
        /// </summary>
        public void Hide()
        {
            myForm.Hide();
        }

        /// <summary>
        /// Flag to specify if the form has been changed.
        /// </summary>
        public bool IsPageDirty
        {
            get { return myForm.IsFormDirty; }
        }

        /// <summary>
        /// Set the pagesite for the form.
        /// </summary>
        public IComPropertyPageSite PageSite
        {
            set { myPageSite = value; }
        }
        
        /// <summary>
        /// Get or set the priority for the form.
        /// </summary>
        public int Priority
        {
            get
            {
                return myPriority;
            }
            set
            {
                myPriority = value;
            }
        }

        /// <summary>
        /// Set the necessary objects required for the form. In this case
        /// the form is given an arguments object in edit mode, or is required 
        /// to create one in create mode. After getting or creating the arguments
        /// object, template mode is checked for and handled. The template mode 
        /// requires all parameters of the arguments object to converted to variables.
        /// </summary>
        /// <param name="objects">Set of objects required for the form.</param>
        public void SetObjects(ESRI.ArcGIS.esriSystem.ISet objects)
        {
            try
            {
                // Recurse through the objects
                objects.Reset();
                for (int i = 0; i < objects.Count; i++)
                {
                    object currObject = objects.Next();
                    // Find the properties to be set.
                    if (currObject is IPropertySet)
                    {
                        IPropertySet uiParameters = (IPropertySet)currObject;
                        object names, values;
                        uiParameters.GetAllProperties(out names, out values);

                        bool disableForm = false;
                        try { disableForm = Convert.ToBoolean(uiParameters.GetProperty("RFxPropPageIsReadOnly")); }
                        catch (Exception) { }

                        if (disableForm)
                            isFormReadOnly = true;
                        else
                            isFormReadOnly = false;

                        // Check if the arguments object exists in the property set.
                        object functionArgument = null;
                        try{ functionArgument = uiParameters.GetProperty("RFxArgument"); }
                        catch (Exception) {}
                        // If not, the form is in create mode.
                        if (functionArgument == null)
                        {
                            #region Create Mode
                            // Create a new arguments object.
                            myArgs = new WatermarkFunctionArguments();
                            // Create a new property and set the arguments object on it.
                            uiParameters.SetProperty("RFxArgument", myArgs);
                            // Check if a default raster is supplied.
                            object defaultRaster = null;
                            try { defaultRaster = uiParameters.GetProperty("RFxDefaultInputRaster"); }
                            catch (Exception) { }
                            if (defaultRaster != null) // If it is, set it to the raster property.
                                myArgs.Raster = defaultRaster;
                            // Check if the form is in template mode.
                            templateMode = (bool)uiParameters.GetProperty("RFxTemplateEditMode");
                            if (templateMode)
                            {
                                // Since we are in create mode already, new variables have to be 
                                // created for each property of the arguments object.
                                #region Create Variables
                                if (defaultRaster != null)
                                {
                                    // If a default raster is supplied and it is a variable,
                                    // there is no need to create one.
                                    if (defaultRaster is IRasterFunctionVariable)
                                        myRasterVar = (IRasterFunctionVariable)defaultRaster;
                                    else
                                    {
                                        // Create variable object for the InputRaster property.
                                        myRasterVar = new RasterFunctionVariableClass();
                                        myRasterVar.Value = defaultRaster;
                                        myRasterVar.Name = "InputRaster";
                                        myRasterVar.IsDataset = true;
                                    }
                                }

                                // Create a variable for the BlendPercentage property.
                                myBlendPercentageVar = new RasterFunctionVariableClass();
                                myBlendPercentageVar.Name = "BlendPercentage";
                                // Use the default value from the arguments object
                                myBlendPercentageVar.Value = myArgs.BlendPercentage;

                                myXGapVar = new RasterFunctionVariableClass();
                                myXGapVar.Name = "XGap";
                                myXGapVar.Value = myArgs.XGap;

                                myYGapVar = new RasterFunctionVariableClass();
                                myYGapVar.Name = "YGap";
                                myYGapVar.Value = myArgs.YGap;

                                // Create a variable for the WatermarkImagePath property.
                                myWatermarkImagePathVar = new RasterFunctionVariableClass();
                                myWatermarkImagePathVar.Name = "WatermarkImagePath";
                                // Use the default value from the arguments object
                                myWatermarkImagePathVar.Value = myArgs.WatermarkImagePath;

                                // Set the variables created as properties on the arguments object.
                                IRasterFunctionArguments rasterFunctionArgs =
                                    (IRasterFunctionArguments)myArgs;
                                rasterFunctionArgs.PutValue("Raster", myRasterVar);
                                rasterFunctionArgs.PutValue("BlendPercentage", myBlendPercentageVar);
                                rasterFunctionArgs.PutValue("XGap", myXGapVar);
                                rasterFunctionArgs.PutValue("YGap", myYGapVar);
                                #endregion
                            }
                            #endregion
                        }
                        else
                        {
                            #region  Edit Mode
                            // Get the arguments object from the property set.
                            myArgs = (IWatermarkFunctionArguments)functionArgument;
                            // Check if the form is in template mode.
                            templateMode = (bool)uiParameters.GetProperty("RFxTemplateEditMode");
                            if (templateMode)
                            {
                                #region Edit Template
                                // In template edit mode, the variables from the arguments object
                                // are extracted.
                                IRasterFunctionArguments rasterFunctionArgs =
                                    (IRasterFunctionArguments)myArgs;
                                object raster = rasterFunctionArgs.GetValue("Raster");
                                object blendPercentage = rasterFunctionArgs.GetValue("BlendPercentage");
                                object watermarkLocation = rasterFunctionArgs.GetValue("WatermarkLocation");
                                object watermarkPath = rasterFunctionArgs.GetValue("WatermarkImagePath");
                                object xGap = rasterFunctionArgs.GetValue("XGap");
                                object yGap = rasterFunctionArgs.GetValue("YGap");

                                // Create or Open the Raster variable.
                                if (raster is IRasterFunctionVariable)
                                    myRasterVar = (IRasterFunctionVariable)raster;
                                else
                                {
                                    myRasterVar = new RasterFunctionVariableClass();
                                    myRasterVar.Name = "InputRaster";
                                    myRasterVar.Value = raster;
                                }
                                // Create or Open the BlendPercentage variable.
                                if (blendPercentage is IRasterFunctionVariable)
                                    myBlendPercentageVar = (IRasterFunctionVariable)blendPercentage;
                                else
                                {
                                    myBlendPercentageVar = new RasterFunctionVariableClass();
                                    myBlendPercentageVar.Name = "BlendPercentage";
                                    myBlendPercentageVar.Value = blendPercentage;
                                }
                                
                                if (xGap is IRasterFunctionVariable)
                                    myXGapVar = (IRasterFunctionVariable)xGap;
                                else
                                {
                                    myXGapVar = new RasterFunctionVariableClass();
                                    myXGapVar.Name = "XGap";
                                    myXGapVar.Value = xGap;
                                }

                                if (yGap is IRasterFunctionVariable)
                                    myYGapVar = (IRasterFunctionVariable)yGap;
                                else
                                {
                                    myYGapVar = new RasterFunctionVariableClass();
                                    myYGapVar.Name = "YGap";
                                    myYGapVar.Value = yGap;
                                }

                                // Create or Open the WatermarkImagePath variable.
                                if (watermarkPath is IRasterFunctionVariable)
                                    myWatermarkImagePathVar = (IRasterFunctionVariable)watermarkPath;
                                else
                                {
                                    myWatermarkImagePathVar = new RasterFunctionVariableClass();
                                    myWatermarkImagePathVar.Name = "WatermarkImagePath";
                                    myWatermarkImagePathVar.Value = watermarkPath;
                                }
                                #endregion
                            }
                            #endregion
                        }
                    }
                }
            }
            catch (Exception exc)            {
                string errorMsg = exc.Message;
            }
        }

        /// <summary>
        /// Show the form.
        /// </summary>
        public void Show()
        {
            if (isFormReadOnly)
                myForm.Enabled = false;
            else
                myForm.Enabled = true;
            myForm.Show();
        }

        /// <summary>
        /// Get or set the title of the form
        /// </summary>
        public string Title
        {
            get
            {
                return myForm.Text;
            }
            set
            {
                myForm.Text = value;
            }
        }

        /// <summary>
        /// Get the width of the form.
        /// </summary>
        public int Width
        {
            get { return myForm.Width; }
        }

        /// <summary>
        /// Return the help context ID of the form if it exists.
        /// </summary>
        /// <param name="controlID">Control ID for the sheet.</param>
        /// <returns>The context ID.</returns>
        public int get_HelpContextID(int controlID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region COM Registration Function(s)
        /// <summary>
        /// Register the Property Page with the Raster Function Property Pages
        /// </summary>
        /// <param name="regKey">Key to register.</param>
        [ComRegisterFunction()]
        static void Reg(string regKey)
        {            
            RasterFunctionPropertyPages.Register(regKey);
        }

        /// <summary>
        /// Unregister the Property Page with the Raster Function Property Pages
        /// </summary>
        /// <param name="regKey">Key to unregister.</param>
        [ComUnregisterFunction()]
        static void Unreg(string regKey)
        {
            RasterFunctionPropertyPages.Unregister(regKey);
        }        
        #endregion
    }
}
