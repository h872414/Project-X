using System;
using System.Drawing;

namespace DicomLoader.View
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.multiImportPanel = new System.Windows.Forms.Panel();
            this.inputDirPathLabel = new System.Windows.Forms.Label();
            this.importDirBtn = new System.Windows.Forms.Button();
            this.multipleLabel = new System.Windows.Forms.Label();
            this.choosenDirLabel = new System.Windows.Forms.Label();
            this.singleImportPanel = new System.Windows.Forms.Panel();
            this.inputPathLabel = new System.Windows.Forms.Label();
            this.choosenLabel = new System.Windows.Forms.Label();
            this.importBtn = new System.Windows.Forms.Button();
            this.singleLabel = new System.Windows.Forms.Label();
            this.exportPanel = new System.Windows.Forms.Panel();
            this.exportBtn = new System.Windows.Forms.Button();
            this.viewerPanel = new System.Windows.Forms.Panel();
            this.currentPanel = new System.Windows.Forms.Panel();
            this.currentLabel = new System.Windows.Forms.Label();
            this.imageCountLabeld = new System.Windows.Forms.Label();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.leftBtn = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.rightBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dicomImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dicomUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.multiImportPanel.SuspendLayout();
            this.singleImportPanel.SuspendLayout();
            this.exportPanel.SuspendLayout();
            this.viewerPanel.SuspendLayout();
            this.currentPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 30);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.multiImportPanel);
            this.splitContainer.Panel1.Controls.Add(this.singleImportPanel);
            this.splitContainer.Panel1.Controls.Add(this.exportPanel);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.viewerPanel);
            this.splitContainer.Size = new System.Drawing.Size(900, 470);
            this.splitContainer.SplitterDistance = 238;
            this.splitContainer.TabIndex = 0;
            // 
            // multiImportPanel
            // 
            this.multiImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.multiImportPanel.Controls.Add(this.inputDirPathLabel);
            this.multiImportPanel.Controls.Add(this.importDirBtn);
            this.multiImportPanel.Controls.Add(this.multipleLabel);
            this.multiImportPanel.Controls.Add(this.choosenDirLabel);
            this.multiImportPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiImportPanel.Location = new System.Drawing.Point(0, 162);
            this.multiImportPanel.Name = "multiImportPanel";
            this.multiImportPanel.Size = new System.Drawing.Size(238, 166);
            this.multiImportPanel.TabIndex = 3;
            // 
            // inputDirPathLabel
            // 
            this.inputDirPathLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputDirPathLabel.AutoSize = true;
            this.inputDirPathLabel.Location = new System.Drawing.Point(114, 132);
            this.inputDirPathLabel.Name = "inputDirPathLabel";
            this.inputDirPathLabel.Size = new System.Drawing.Size(0, 17);
            this.inputDirPathLabel.TabIndex = 7;
            // 
            // importDirBtn
            // 
            this.importDirBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importDirBtn.Location = new System.Drawing.Point(78, 58);
            this.importDirBtn.Name = "importDirBtn";
            this.importDirBtn.Size = new System.Drawing.Size(75, 23);
            this.importDirBtn.TabIndex = 4;
            this.importDirBtn.Text = "Import";
            this.importDirBtn.UseVisualStyleBackColor = true;
            this.importDirBtn.Click += new System.EventHandler(this.ImportDirBtnClick);
            // 
            // multipleLabel
            // 
            this.multipleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.multipleLabel.AutoSize = true;
            this.multipleLabel.Location = new System.Drawing.Point(20, 13);
            this.multipleLabel.Name = "multipleLabel";
            this.multipleLabel.Size = new System.Drawing.Size(195, 17);
            this.multipleLabel.TabIndex = 5;
            this.multipleLabel.Text = "DICOM könyvtár kiválasztása:";
            // 
            // choosenDirLabel
            // 
            this.choosenDirLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choosenDirLabel.AutoSize = true;
            this.choosenDirLabel.Location = new System.Drawing.Point(40, 115);
            this.choosenDirLabel.Name = "choosenDirLabel";
            this.choosenDirLabel.Size = new System.Drawing.Size(142, 17);
            this.choosenDirLabel.TabIndex = 6;
            this.choosenDirLabel.Text = "Kiválasztott könyvtár:";
            // 
            // singleImportPanel
            // 
            this.singleImportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.singleImportPanel.Controls.Add(this.inputPathLabel);
            this.singleImportPanel.Controls.Add(this.choosenLabel);
            this.singleImportPanel.Controls.Add(this.importBtn);
            this.singleImportPanel.Controls.Add(this.singleLabel);
            this.singleImportPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.singleImportPanel.Location = new System.Drawing.Point(0, 0);
            this.singleImportPanel.Name = "singleImportPanel";
            this.singleImportPanel.Size = new System.Drawing.Size(238, 162);
            this.singleImportPanel.TabIndex = 2;
            // 
            // inputPathLabel
            // 
            this.inputPathLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputPathLabel.AutoSize = true;
            this.inputPathLabel.Location = new System.Drawing.Point(114, 114);
            this.inputPathLabel.Name = "inputPathLabel";
            this.inputPathLabel.Size = new System.Drawing.Size(0, 17);
            this.inputPathLabel.TabIndex = 3;
            // 
            // choosenLabel
            // 
            this.choosenLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choosenLabel.AutoSize = true;
            this.choosenLabel.Location = new System.Drawing.Point(63, 85);
            this.choosenLabel.Name = "choosenLabel";
            this.choosenLabel.Size = new System.Drawing.Size(106, 17);
            this.choosenLabel.TabIndex = 2;
            this.choosenLabel.Text = "Kiválasztott fájl:";
            // 
            // importBtn
            // 
            this.importBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.importBtn.Location = new System.Drawing.Point(78, 45);
            this.importBtn.Name = "importBtn";
            this.importBtn.Size = new System.Drawing.Size(75, 23);
            this.importBtn.TabIndex = 0;
            this.importBtn.Text = "Import";
            this.importBtn.UseVisualStyleBackColor = true;
            this.importBtn.Click += new System.EventHandler(this.ImportFileBtnClick);
            // 
            // singleLabel
            // 
            this.singleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.singleLabel.AutoSize = true;
            this.singleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.singleLabel.Location = new System.Drawing.Point(40, 11);
            this.singleLabel.Name = "singleLabel";
            this.singleLabel.Size = new System.Drawing.Size(159, 17);
            this.singleLabel.TabIndex = 1;
            this.singleLabel.Text = "DICOM file kiválasztása:";
            // 
            // exportPanel
            // 
            this.exportPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.exportPanel.Controls.Add(this.exportBtn);
            this.exportPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exportPanel.Location = new System.Drawing.Point(0, 328);
            this.exportPanel.Name = "exportPanel";
            this.exportPanel.Size = new System.Drawing.Size(238, 142);
            this.exportPanel.TabIndex = 1;
            // 
            // exportBtn
            // 
            this.exportBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exportBtn.Location = new System.Drawing.Point(66, 61);
            this.exportBtn.Margin = new System.Windows.Forms.Padding(5);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Padding = new System.Windows.Forms.Padding(1);
            this.exportBtn.Size = new System.Drawing.Size(100, 25);
            this.exportBtn.TabIndex = 8;
            this.exportBtn.Text = "Exportálás";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // viewerPanel
            // 
            this.viewerPanel.Controls.Add(this.currentPanel);
            this.viewerPanel.Controls.Add(this.leftPanel);
            this.viewerPanel.Controls.Add(this.rightPanel);
            this.viewerPanel.Controls.Add(this.pictureBox);
            this.viewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewerPanel.Location = new System.Drawing.Point(0, 0);
            this.viewerPanel.Name = "viewerPanel";
            this.viewerPanel.Size = new System.Drawing.Size(658, 470);
            this.viewerPanel.TabIndex = 0;
            // 
            // currentPanel
            // 
            this.currentPanel.Controls.Add(this.currentLabel);
            this.currentPanel.Controls.Add(this.imageCountLabeld);
            this.currentPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.currentPanel.Location = new System.Drawing.Point(97, 402);
            this.currentPanel.Name = "currentPanel";
            this.currentPanel.Size = new System.Drawing.Size(464, 68);
            this.currentPanel.TabIndex = 15;
            // 
            // currentLabel
            // 
            this.currentLabel.AutoSize = true;
            this.currentLabel.Location = new System.Drawing.Point(191, 9);
            this.currentLabel.Name = "currentLabel";
            this.currentLabel.Size = new System.Drawing.Size(91, 17);
            this.currentLabel.TabIndex = 12;
            this.currentLabel.Text = "Jelenlegi kép";
            // 
            // imageCountLabeld
            // 
            this.imageCountLabeld.AutoSize = true;
            this.imageCountLabeld.Location = new System.Drawing.Point(191, 42);
            this.imageCountLabeld.Name = "imageCountLabeld";
            this.imageCountLabeld.Size = new System.Drawing.Size(24, 17);
            this.imageCountLabeld.TabIndex = 13;
            this.imageCountLabeld.Text = "0 /";
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.leftBtn);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(97, 470);
            this.leftPanel.TabIndex = 14;
            // 
            // leftBtn
            // 
            this.leftBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.leftBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftBtn.BackgroundImage")));
            this.leftBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.leftBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leftBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.leftBtn.Location = new System.Drawing.Point(18, 163);
            this.leftBtn.Margin = new System.Windows.Forms.Padding(5);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Padding = new System.Windows.Forms.Padding(1);
            this.leftBtn.Size = new System.Drawing.Size(70, 95);
            this.leftBtn.TabIndex = 11;
            this.leftBtn.UseVisualStyleBackColor = false;
            this.leftBtn.Click += new System.EventHandler(this.LeftBtn_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.rightBtn);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(561, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(97, 470);
            this.rightPanel.TabIndex = 13;
            // 
            // rightBtn
            // 
            this.rightBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightBtn.BackColor = System.Drawing.SystemColors.Menu;
            this.rightBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightBtn.BackgroundImage")));
            this.rightBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rightBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rightBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.rightBtn.Location = new System.Drawing.Point(13, 163);
            this.rightBtn.Margin = new System.Windows.Forms.Padding(5);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Padding = new System.Windows.Forms.Padding(1);
            this.rightBtn.Size = new System.Drawing.Size(70, 95);
            this.rightBtn.TabIndex = 10;
            this.rightBtn.UseVisualStyleBackColor = false;
            this.rightBtn.Click += new System.EventHandler(this.RightBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(163, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(336, 326);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dicomImportToolStripMenuItem,
            this.dicomUploadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dicomImportToolStripMenuItem
            // 
            this.dicomImportToolStripMenuItem.Name = "dicomImportToolStripMenuItem";
            this.dicomImportToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.dicomImportToolStripMenuItem.Text = "Dicom Import";
            this.dicomImportToolStripMenuItem.Click += new System.EventHandler(this.DicomImportToolStripMenuItem_Click);
            // 
            // dicomUploadToolStripMenuItem
            // 
            this.dicomUploadToolStripMenuItem.Name = "dicomUploadToolStripMenuItem";
            this.dicomUploadToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.dicomUploadToolStripMenuItem.Text = "Dicom Upload";
            this.dicomUploadToolStripMenuItem.Click += new System.EventHandler(this.DicomUploadToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "MainWindow";
            this.Text = "Awesome Project";
            this.Resize += new System.EventHandler(this.SetResize);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.multiImportPanel.ResumeLayout(false);
            this.multiImportPanel.PerformLayout();
            this.singleImportPanel.ResumeLayout(false);
            this.singleImportPanel.PerformLayout();
            this.exportPanel.ResumeLayout(false);
            this.viewerPanel.ResumeLayout(false);
            this.currentPanel.ResumeLayout(false);
            this.currentPanel.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button importBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label singleLabel;
        private System.Windows.Forms.Label choosenLabel;
        private System.Windows.Forms.Label inputPathLabel;
        private System.Windows.Forms.Label multipleLabel;
        private System.Windows.Forms.Button importDirBtn;
        private System.Windows.Forms.Label choosenDirLabel;
        private System.Windows.Forms.Label inputDirPathLabel;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.Panel viewerPanel;
        private System.Windows.Forms.Button leftBtn;
        private System.Windows.Forms.Label currentLabel;
        private System.Windows.Forms.Button rightBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dicomImportToolStripMenuItem;
        private System.Windows.Forms.Panel singleImportPanel;
        private System.Windows.Forms.Panel exportPanel;

        private System.Windows.Forms.Panel multiImportPanel;
        private System.Windows.Forms.Panel currentPanel;
        private System.Windows.Forms.Label imageCountLabeld;
        private System.Windows.Forms.ToolStripMenuItem dicomUploadToolStripMenuItem;
    }

}