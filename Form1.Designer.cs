
using System.Drawing;
using System.Windows.Forms;

namespace ImageApp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
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

