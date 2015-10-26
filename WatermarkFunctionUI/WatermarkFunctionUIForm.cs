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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Catalog;
using ESRI.ArcGIS.CatalogUI;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace DolphinStudioUI
{
    public partial class WatermarkFunctionUIForm : Form
    {
        #region Private Members
        private object myInputRaster;
        private string myWaterMarkImagePath;
        private double myBlendPercentage;
        private int myXGap;
        private int myYGap;
        private bool myDirtyFlag;
        #endregion

        #region WatermarkFunctionUIForm Properties
        /// <summary>
        /// Constructor
        /// </summary>
        public WatermarkFunctionUIForm()
        {
            InitializeComponent();
            myInputRaster = null;
            myWaterMarkImagePath = "";
            myBlendPercentage = 0.0;
            myXGap = 100;
            myYGap=100;
        }

        /// <summary>
        /// Get or set the watermark image path
        /// </summary>
        public string WatermarkImagePath
        {
            get
            {
                myWaterMarkImagePath = watermarkImageTxtbox.Text;
                return myWaterMarkImagePath;
            }
            set
            {
                myWaterMarkImagePath = value;
                watermarkImageTxtbox.Text = value;
            }
        }

        /// <summary>
        /// Flag to specify if the form has changed
        /// </summary>
        public bool IsFormDirty
        {
            get
            {
                return myDirtyFlag;
            }
            set
            {
                myDirtyFlag = value;
            }
        }

        /// <summary>
        /// Get or set the input raster
        /// </summary>
        public object InputRaster
        {
            get
            {
                return myInputRaster;
            }
            set
            {
                myInputRaster = value;
                inputRasterTxtbox.Text = GetInputRasterName(myInputRaster);
            }
        }

        /// <summary>
        /// Get or set the blending percentage
        /// </summary>
        public double BlendPercentage
        {
            get
            {
                if (blendPercentTxtbox.Text == "")
                    blendPercentTxtbox.Text = "50.00";
                myBlendPercentage = Convert.ToDouble(blendPercentTxtbox.Text);
                return myBlendPercentage;
            }
            set
            {
                myBlendPercentage = value;
                blendPercentTxtbox.Text = Convert.ToString(value);
            }
        }

        public int XGap
        {
            get { return myXGap; }
            set { myXGap = value; }
        }

        public int YGap
        {
            get { return myYGap; }
            set { myYGap = value; }
        }
        
        #endregion

        #region WatermarkFunctionUIForm Members
        /// <summary>
        /// This function takes a raster object and returns the formatted name of  
        /// the object for display in the UI.
        /// </summary>
        /// <param name="inputRaster">Object whose name is to be found</param>
        /// <returns>Name of the object</returns>
        private string GetInputRasterName(object inputRaster)
        {
            if ((inputRaster is IRasterDataset))
            {
                IRasterDataset rasterDataset = (IRasterDataset)inputRaster;
                return rasterDataset.CompleteName;
            }

            if ((inputRaster is IRaster))
            {
                IRaster myRaster = (IRaster)inputRaster;
                return ((IRaster2)myRaster).RasterDataset.CompleteName;
            }

            if (inputRaster is IDataset)
            {
                IDataset dataset = (IDataset)inputRaster;
                return dataset.Name;
            }

            if (inputRaster is IName)
            {
                if (inputRaster is IDatasetName)
                {
                    IDatasetName inputDSName = (IDatasetName)inputRaster;
                    return inputDSName.Name;
                }

                if (inputRaster is IFunctionRasterDatasetName)
                {
                    IFunctionRasterDatasetName inputFRDName = (IFunctionRasterDatasetName)inputRaster;
                    return inputFRDName.BrowseName;
                }

                if (inputRaster is IMosaicDatasetName)
                {
                    IMosaicDatasetName inputMDName = (IMosaicDatasetName)inputRaster;
                    return "MD";
                }

                IName inputName = (IName)inputRaster;
                return inputName.NameString;
            }

            if (inputRaster is IRasterFunctionTemplate)
            {
                IRasterFunctionTemplate rasterFunctionTemplate =
                    (IRasterFunctionTemplate)inputRaster;
                return rasterFunctionTemplate.Function.Name;
            }

            if (inputRaster is IRasterFunctionVariable)
            {
                IRasterFunctionVariable rasterFunctionVariable =
                    (IRasterFunctionVariable)inputRaster;
                return rasterFunctionVariable.Name;
            }

            return "";
        }

        /// <summary>
        /// Updates the UI textboxes using the properties that have been set.
        /// </summary>
        public void UpdateUI()
        {
            if (myInputRaster != null)
                inputRasterTxtbox.Text = GetInputRasterName(myInputRaster);
            blendPercentTxtbox.Text = Convert.ToString(myBlendPercentage);
            watermarkImageTxtbox.Text = myWaterMarkImagePath;
            xGapTxtbox.Text = myXGap.ToString();
            yGapTxtbox.Text = myYGap.ToString();
        }

        private void inputRasterBtn_Click(object sender, EventArgs e)
        {
            IEnumGxObject ipSelectedObjects = null;
            ShowRasterDatasetBrowser((int)(Handle.ToInt32()), out ipSelectedObjects);

            IGxObject selectedObject =  ipSelectedObjects.Next();
            if (selectedObject is IGxDataset)
            {
                IGxDataset ipGxDS = (IGxDataset)selectedObject;
                IDataset ipDataset;
                ipDataset = ipGxDS.Dataset;
                myInputRaster = ipDataset.FullName;
                inputRasterTxtbox.Text = GetInputRasterName(myInputRaster);
                myDirtyFlag = true;
            }
        }

        public void ShowRasterDatasetBrowser(int handle, out IEnumGxObject ipSelectedObjects)
        {
            IGxObjectFilterCollection ipFilterCollection = new GxDialogClass();

            IGxObjectFilter ipFilter1 = new GxFilterRasterDatasetsClass();
            ipFilterCollection.AddFilter(ipFilter1, true);
            IGxDialog ipGxDialog = (IGxDialog)(ipFilterCollection);

            ipGxDialog.RememberLocation = true;
            ipGxDialog.Title = "Open";

            ipGxDialog.AllowMultiSelect = false;
            ipGxDialog.RememberLocation = true;

            ipGxDialog.DoModalOpen((int)(Handle.ToInt32()), out ipSelectedObjects);
            return;
        }
        
        private void watermarkImageBtn_Click(object sender, EventArgs e)
        {
            watermarkImageDlg.ShowDialog();
            if (watermarkImageDlg.FileName != "")
            {
                watermarkImageTxtbox.Text = watermarkImageDlg.FileName;
                myDirtyFlag = true;
            }
        }

        private void blendPercentTxtbox_ModifiedChanged(object sender, EventArgs e)
        {
            if (blendPercentTxtbox.Text != "")
            {
                myBlendPercentage = Convert.ToDouble(blendPercentTxtbox.Text);
                myDirtyFlag = true;
            }
        }

        private void xGapTxtbox_TextChanged(object sender, EventArgs e)
        {
            myXGap = Convert.ToInt32(xGapTxtbox.Text);
            myDirtyFlag = true;
        }

        private void yGapTxtbox_TextChanged(object sender, EventArgs e)
        {
            myYGap = Convert.ToInt32(yGapTxtbox.Text);
            myDirtyFlag = true;
        }
        #endregion



    }
}
