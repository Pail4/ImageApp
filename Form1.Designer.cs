﻿namespace ImageApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LoadImage = new Button();
            SuspendLayout();
            // 
            // LoadImage
            // 
            LoadImage.Location = new Point(33, 26);
            LoadImage.Name = "LoadImage";
            LoadImage.Size = new Size(296, 49);
            LoadImage.TabIndex = 0;
            LoadImage.Text = "Загрузить изображение";
            LoadImage.UseVisualStyleBackColor = true;
            LoadImage.Click += LoadImage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(LoadImage);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button LoadImage;
    }
}