namespace DicomLoader.View
{
    partial class UploadWindow
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.CommitLabel = new System.Windows.Forms.Label();
            this.BrowseLabel = new System.Windows.Forms.Label();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.DescriptionInput = new System.Windows.Forms.RichTextBox();
            this.DateInput = new System.Windows.Forms.DateTimePicker();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(176, 54);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(62, 29);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Név:";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateLabel.Location = new System.Drawing.Point(150, 122);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(88, 29);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "Dátum:";
            // 
            // CommitLabel
            // 
            this.CommitLabel.AutoSize = true;
            this.CommitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CommitLabel.Location = new System.Drawing.Point(89, 202);
            this.CommitLabel.Name = "CommitLabel";
            this.CommitLabel.Size = new System.Drawing.Size(149, 29);
            this.CommitLabel.TabIndex = 2;
            this.CommitLabel.Text = "Megjegyzés:";
            // 
            // BrowseLabel
            // 
            this.BrowseLabel.AutoSize = true;
            this.BrowseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrowseLabel.Location = new System.Drawing.Point(41, 309);
            this.BrowseLabel.Name = "BrowseLabel";
            this.BrowseLabel.Size = new System.Drawing.Size(197, 29);
            this.BrowseLabel.TabIndex = 3;
            this.BrowseLabel.Text = "Kép kiválasztása:";
            // 
            // NameInput
            // 
            this.NameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameInput.Location = new System.Drawing.Point(294, 49);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(341, 30);
            this.NameInput.TabIndex = 4;
            // 
            // DescriptionInput
            // 
            this.DescriptionInput.Location = new System.Drawing.Point(294, 176);
            this.DescriptionInput.Name = "DescriptionInput";
            this.DescriptionInput.Size = new System.Drawing.Size(341, 96);
            this.DescriptionInput.TabIndex = 5;
            this.DescriptionInput.Text = "";
            // 
            // DateInput
            // 
            this.DateInput.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DateInput.Location = new System.Drawing.Point(294, 120);
            this.DateInput.Name = "DateInput";
            this.DateInput.Size = new System.Drawing.Size(341, 30);
            this.DateInput.TabIndex = 6;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BrowseButton.Location = new System.Drawing.Point(294, 309);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(116, 37);
            this.BrowseButton.TabIndex = 7;
            this.BrowseButton.Text = "Tallózás";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UploadButton.Location = new System.Drawing.Point(411, 373);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(116, 36);
            this.UploadButton.TabIndex = 8;
            this.UploadButton.Text = "Feltöltés";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // UploadWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.DateInput);
            this.Controls.Add(this.DescriptionInput);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.BrowseLabel);
            this.Controls.Add(this.CommitLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.NameLabel);
            this.Name = "UploadWindow";
            this.Text = "UploadWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label CommitLabel;
        private System.Windows.Forms.Label BrowseLabel;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.RichTextBox DescriptionInput;
        private System.Windows.Forms.DateTimePicker DateInput;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button UploadButton;
    }
}