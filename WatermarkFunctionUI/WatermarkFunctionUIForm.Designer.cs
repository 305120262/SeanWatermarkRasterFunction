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

namespace DolphinStudioUI
{
    partial class WatermarkFunctionUIForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputRasterLbl = new System.Windows.Forms.Label();
            this.watermarkImageLbl = new System.Windows.Forms.Label();
            this.blendPercentLbl = new System.Windows.Forms.Label();
            this.inputRasterTxtbox = new System.Windows.Forms.TextBox();
            this.watermarkImageTxtbox = new System.Windows.Forms.TextBox();
            this.blendPercentTxtbox = new System.Windows.Forms.TextBox();
            this.inputRasterBtn = new System.Windows.Forms.Button();
            this.watermarkImageBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.watermarkImageDlg = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.xGapTxtbox = new System.Windows.Forms.TextBox();
            this.yGapTxtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inputRasterLbl
            // 
            this.inputRasterLbl.AutoSize = true;
            this.inputRasterLbl.Location = new System.Drawing.Point(31, 57);
            this.inputRasterLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inputRasterLbl.Name = "inputRasterLbl";
            this.inputRasterLbl.Size = new System.Drawing.Size(111, 15);
            this.inputRasterLbl.TabIndex = 0;
            this.inputRasterLbl.Text = "Input Raster:";
            // 
            // watermarkImageLbl
            // 
            this.watermarkImageLbl.AutoSize = true;
            this.watermarkImageLbl.Location = new System.Drawing.Point(31, 111);
            this.watermarkImageLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.watermarkImageLbl.Name = "watermarkImageLbl";
            this.watermarkImageLbl.Size = new System.Drawing.Size(175, 15);
            this.watermarkImageLbl.TabIndex = 1;
            this.watermarkImageLbl.Text = "Watermark Image Path:";
            // 
            // blendPercentLbl
            // 
            this.blendPercentLbl.AutoSize = true;
            this.blendPercentLbl.Location = new System.Drawing.Point(31, 164);
            this.blendPercentLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.blendPercentLbl.Name = "blendPercentLbl";
            this.blendPercentLbl.Size = new System.Drawing.Size(143, 15);
            this.blendPercentLbl.TabIndex = 2;
            this.blendPercentLbl.Text = "Blend Percentage:";
            // 
            // inputRasterTxtbox
            // 
            this.inputRasterTxtbox.Location = new System.Drawing.Point(255, 47);
            this.inputRasterTxtbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputRasterTxtbox.Name = "inputRasterTxtbox";
            this.inputRasterTxtbox.Size = new System.Drawing.Size(247, 25);
            this.inputRasterTxtbox.TabIndex = 3;
            // 
            // watermarkImageTxtbox
            // 
            this.watermarkImageTxtbox.Location = new System.Drawing.Point(255, 103);
            this.watermarkImageTxtbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.watermarkImageTxtbox.Name = "watermarkImageTxtbox";
            this.watermarkImageTxtbox.Size = new System.Drawing.Size(247, 25);
            this.watermarkImageTxtbox.TabIndex = 4;
            // 
            // blendPercentTxtbox
            // 
            this.blendPercentTxtbox.Location = new System.Drawing.Point(255, 156);
            this.blendPercentTxtbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.blendPercentTxtbox.Name = "blendPercentTxtbox";
            this.blendPercentTxtbox.Size = new System.Drawing.Size(247, 25);
            this.blendPercentTxtbox.TabIndex = 5;
            this.blendPercentTxtbox.ModifiedChanged += new System.EventHandler(this.blendPercentTxtbox_ModifiedChanged);
            // 
            // inputRasterBtn
            // 
            this.inputRasterBtn.Location = new System.Drawing.Point(512, 44);
            this.inputRasterBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.inputRasterBtn.Name = "inputRasterBtn";
            this.inputRasterBtn.Size = new System.Drawing.Size(41, 27);
            this.inputRasterBtn.TabIndex = 6;
            this.inputRasterBtn.Text = "...";
            this.inputRasterBtn.UseVisualStyleBackColor = true;
            this.inputRasterBtn.Click += new System.EventHandler(this.inputRasterBtn_Click);
            // 
            // watermarkImageBtn
            // 
            this.watermarkImageBtn.Location = new System.Drawing.Point(512, 99);
            this.watermarkImageBtn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.watermarkImageBtn.Name = "watermarkImageBtn";
            this.watermarkImageBtn.Size = new System.Drawing.Size(41, 27);
            this.watermarkImageBtn.TabIndex = 7;
            this.watermarkImageBtn.Text = "...";
            this.watermarkImageBtn.UseVisualStyleBackColor = true;
            this.watermarkImageBtn.Click += new System.EventHandler(this.watermarkImageBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 159);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 211);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "X Gap:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 250);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Y Gap:";
            // 
            // xGapTxtbox
            // 
            this.xGapTxtbox.Location = new System.Drawing.Point(255, 200);
            this.xGapTxtbox.Name = "xGapTxtbox";
            this.xGapTxtbox.Size = new System.Drawing.Size(100, 25);
            this.xGapTxtbox.TabIndex = 11;
            this.xGapTxtbox.TextChanged += new System.EventHandler(this.xGapTxtbox_TextChanged);
            // 
            // yGapTxtbox
            // 
            this.yGapTxtbox.Location = new System.Drawing.Point(255, 247);
            this.yGapTxtbox.Name = "yGapTxtbox";
            this.yGapTxtbox.Size = new System.Drawing.Size(100, 25);
            this.yGapTxtbox.TabIndex = 12;
            this.yGapTxtbox.TextChanged += new System.EventHandler(this.yGapTxtbox_TextChanged);
            // 
            // WatermarkFunctionUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 320);
            this.Controls.Add(this.yGapTxtbox);
            this.Controls.Add(this.xGapTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.watermarkImageBtn);
            this.Controls.Add(this.inputRasterBtn);
            this.Controls.Add(this.blendPercentTxtbox);
            this.Controls.Add(this.watermarkImageTxtbox);
            this.Controls.Add(this.inputRasterTxtbox);
            this.Controls.Add(this.blendPercentLbl);
            this.Controls.Add(this.watermarkImageLbl);
            this.Controls.Add(this.inputRasterLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WatermarkFunctionUIForm";
            this.Text = "Watermark Raster Function";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inputRasterLbl;
        private System.Windows.Forms.Label watermarkImageLbl;
        private System.Windows.Forms.Label blendPercentLbl;
        private System.Windows.Forms.TextBox inputRasterTxtbox;
        private System.Windows.Forms.TextBox watermarkImageTxtbox;
        private System.Windows.Forms.TextBox blendPercentTxtbox;
        private System.Windows.Forms.Button inputRasterBtn;
        private System.Windows.Forms.Button watermarkImageBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog watermarkImageDlg;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xGapTxtbox;
        private System.Windows.Forms.TextBox yGapTxtbox;
    }
}

