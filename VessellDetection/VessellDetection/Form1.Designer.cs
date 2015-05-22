namespace VessellDetection
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.MyFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.imageCollection1Mask = new DevExpress.Utils.ImageCollection(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.girişToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dOKTORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROGRAMCIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dosyaİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüntüYükleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüntüKaydetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.damarBulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.görüntüİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchedFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otsuThresholdingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cannyEdgeDedectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.morphologicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dİlateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionAşındırmaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openingAçılanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closingKapanışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optikDiskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performansÖlçümüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1Mask)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // MyFolderDialog
            // 
            this.MyFolderDialog.SelectedPath = "C:\\Users\\Ali\\Desktop\\drive_orginal";
            // 
            // imageComboBoxEdit1
            // 
            this.imageComboBoxEdit1.Location = new System.Drawing.Point(12, 77);
            this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
            this.imageComboBoxEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Plum;
            this.imageComboBoxEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.imageComboBoxEdit1.Properties.AutoHeight = false;
            this.imageComboBoxEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit1.Properties.LargeImages = this.imageCollection1;
            this.imageComboBoxEdit1.Properties.SmallImages = this.imageCollection2;
            this.imageComboBoxEdit1.Size = new System.Drawing.Size(224, 166);
            this.imageComboBoxEdit1.TabIndex = 6;
            this.imageComboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.ımageComboBoxEdit1_SelectedIndexChanged);
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(175, 150);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageSize = new System.Drawing.Size(565, 584);
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            // 
            // imageCollection1Mask
            // 
            this.imageCollection1Mask.ImageSize = new System.Drawing.Size(565, 584);
            this.imageCollection1Mask.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1Mask.ImageStream")));
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.girişToolStripMenuItem,
            this.dosyaİşlemleriToolStripMenuItem,
            this.damarBulToolStripMenuItem,
            this.görüntüİşlemleriToolStripMenuItem,
            this.performansÖlçümüToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1011, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // girişToolStripMenuItem
            // 
            this.girişToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dOKTORToolStripMenuItem,
            this.pROGRAMCIToolStripMenuItem});
            this.girişToolStripMenuItem.Name = "girişToolStripMenuItem";
            this.girişToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.girişToolStripMenuItem.Text = "Giriş";
            // 
            // dOKTORToolStripMenuItem
            // 
            this.dOKTORToolStripMenuItem.Name = "dOKTORToolStripMenuItem";
            this.dOKTORToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.dOKTORToolStripMenuItem.Text = "DOKTOR";
            this.dOKTORToolStripMenuItem.Click += new System.EventHandler(this.dOKTORToolStripMenuItem_Click);
            // 
            // pROGRAMCIToolStripMenuItem
            // 
            this.pROGRAMCIToolStripMenuItem.Name = "pROGRAMCIToolStripMenuItem";
            this.pROGRAMCIToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.pROGRAMCIToolStripMenuItem.Text = "PROGRAMCI";
            this.pROGRAMCIToolStripMenuItem.Click += new System.EventHandler(this.pROGRAMCIToolStripMenuItem_Click);
            // 
            // dosyaİşlemleriToolStripMenuItem
            // 
            this.dosyaİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.görüntüYükleToolStripMenuItem,
            this.görüntüKaydetToolStripMenuItem});
            this.dosyaİşlemleriToolStripMenuItem.Name = "dosyaİşlemleriToolStripMenuItem";
            this.dosyaİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.dosyaİşlemleriToolStripMenuItem.Text = "Dosya İşlemleri";
            // 
            // görüntüYükleToolStripMenuItem
            // 
            this.görüntüYükleToolStripMenuItem.Name = "görüntüYükleToolStripMenuItem";
            this.görüntüYükleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.görüntüYükleToolStripMenuItem.Text = "Görüntü Yükle";
            this.görüntüYükleToolStripMenuItem.Click += new System.EventHandler(this.görüntüYükleToolStripMenuItem_Click);
            // 
            // görüntüKaydetToolStripMenuItem
            // 
            this.görüntüKaydetToolStripMenuItem.Name = "görüntüKaydetToolStripMenuItem";
            this.görüntüKaydetToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.görüntüKaydetToolStripMenuItem.Text = "Görüntü Kaydet";
            this.görüntüKaydetToolStripMenuItem.Click += new System.EventHandler(this.görüntüKaydetToolStripMenuItem_Click);
            // 
            // damarBulToolStripMenuItem
            // 
            this.damarBulToolStripMenuItem.Name = "damarBulToolStripMenuItem";
            this.damarBulToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.damarBulToolStripMenuItem.Text = "Görüntü İşle";
            this.damarBulToolStripMenuItem.Click += new System.EventHandler(this.damarBulToolStripMenuItem_Click);
            // 
            // görüntüİşlemleriToolStripMenuItem
            // 
            this.görüntüİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem,
            this.optikDiskToolStripMenuItem});
            this.görüntüİşlemleriToolStripMenuItem.Name = "görüntüİşlemleriToolStripMenuItem";
            this.görüntüİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.görüntüİşlemleriToolStripMenuItem.Text = "Görüntü İşlemleri";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.greenChannelToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.matchedFilterToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.otsuThresholdingToolStripMenuItem,
            this.cannyEdgeDedectionToolStripMenuItem,
            this.morphologicToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // greenChannelToolStripMenuItem
            // 
            this.greenChannelToolStripMenuItem.Name = "greenChannelToolStripMenuItem";
            this.greenChannelToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.greenChannelToolStripMenuItem.Text = "Green Channel";
            this.greenChannelToolStripMenuItem.Click += new System.EventHandler(this.greenChannelToolStripMenuItem_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // matchedFilterToolStripMenuItem
            // 
            this.matchedFilterToolStripMenuItem.Name = "matchedFilterToolStripMenuItem";
            this.matchedFilterToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.matchedFilterToolStripMenuItem.Text = "Matched Filter";
            this.matchedFilterToolStripMenuItem.Click += new System.EventHandler(this.matchedFilterToolStripMenuItem_Click);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.sharpenToolStripMenuItem.Text = "Sharpen";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.sharpenToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // otsuThresholdingToolStripMenuItem
            // 
            this.otsuThresholdingToolStripMenuItem.Name = "otsuThresholdingToolStripMenuItem";
            this.otsuThresholdingToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.otsuThresholdingToolStripMenuItem.Text = "Otsu Thresholding";
            this.otsuThresholdingToolStripMenuItem.Click += new System.EventHandler(this.otsuThresholdingToolStripMenuItem_Click);
            // 
            // cannyEdgeDedectionToolStripMenuItem
            // 
            this.cannyEdgeDedectionToolStripMenuItem.Name = "cannyEdgeDedectionToolStripMenuItem";
            this.cannyEdgeDedectionToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.cannyEdgeDedectionToolStripMenuItem.Text = "Canny Edge Dedection";
            this.cannyEdgeDedectionToolStripMenuItem.Click += new System.EventHandler(this.cannyEdgeDedectionToolStripMenuItem_Click);
            // 
            // morphologicToolStripMenuItem
            // 
            this.morphologicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dİlateToolStripMenuItem,
            this.erosionAşındırmaToolStripMenuItem,
            this.openingAçılanToolStripMenuItem,
            this.closingKapanışToolStripMenuItem});
            this.morphologicToolStripMenuItem.Name = "morphologicToolStripMenuItem";
            this.morphologicToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.morphologicToolStripMenuItem.Text = "Morfolojik Operasyonlar ";
            // 
            // dİlateToolStripMenuItem
            // 
            this.dİlateToolStripMenuItem.Name = "dİlateToolStripMenuItem";
            this.dİlateToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.dİlateToolStripMenuItem.Text = "Dilation(Genişletme)";
            this.dİlateToolStripMenuItem.Click += new System.EventHandler(this.dİlateToolStripMenuItem_Click);
            // 
            // erosionAşındırmaToolStripMenuItem
            // 
            this.erosionAşındırmaToolStripMenuItem.Name = "erosionAşındırmaToolStripMenuItem";
            this.erosionAşındırmaToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.erosionAşındırmaToolStripMenuItem.Text = "Erosion(Aşındırma)";
            this.erosionAşındırmaToolStripMenuItem.Click += new System.EventHandler(this.erosionAşındırmaToolStripMenuItem_Click);
            // 
            // openingAçılanToolStripMenuItem
            // 
            this.openingAçılanToolStripMenuItem.Name = "openingAçılanToolStripMenuItem";
            this.openingAçılanToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openingAçılanToolStripMenuItem.Text = "Opening(Açılan)";
            // 
            // closingKapanışToolStripMenuItem
            // 
            this.closingKapanışToolStripMenuItem.Name = "closingKapanışToolStripMenuItem";
            this.closingKapanışToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.closingKapanışToolStripMenuItem.Text = "Closing(Kapanış)";
            // 
            // optikDiskToolStripMenuItem
            // 
            this.optikDiskToolStripMenuItem.Name = "optikDiskToolStripMenuItem";
            this.optikDiskToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.optikDiskToolStripMenuItem.Text = "Optik Disk";
            this.optikDiskToolStripMenuItem.Click += new System.EventHandler(this.optikDiskToolStripMenuItem_Click);
            // 
            // performansÖlçümüToolStripMenuItem
            // 
            this.performansÖlçümüToolStripMenuItem.Name = "performansÖlçümüToolStripMenuItem";
            this.performansÖlçümüToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.performansÖlçümüToolStripMenuItem.Text = "Performans Ölçümü";
            this.performansÖlçümüToolStripMenuItem.Click += new System.EventHandler(this.performansÖlçümüToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::VessellDetection.Properties.Resources.goz_logo2;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(280, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(562, 478);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LavenderBlush;
            this.BackgroundImage = global::VessellDetection.Properties.Resources.arkaplan;
            this.ClientSize = new System.Drawing.Size(1011, 664);
            this.Controls.Add(this.imageComboBoxEdit1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Vessel Detection";
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1Mask)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.FolderBrowserDialog MyFolderDialog;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.Utils.ImageCollection imageCollection1Mask;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dosyaİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüYükleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüKaydetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem görüntüİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optikDiskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performansÖlçümüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cannyEdgeDedectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem girişToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dOKTORToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROGRAMCIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otsuThresholdingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem morphologicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dİlateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem erosionAşındırmaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openingAçılanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closingKapanışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchedFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem damarBulToolStripMenuItem;
    }
}

