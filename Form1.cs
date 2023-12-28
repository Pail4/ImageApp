using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Jpeg;
using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageApp
{
    public partial class Form1 : Form
    {
        private string Info { get; set; }
        public Form1()
        {
            InitializeComponent();
            Info = "";
        }

        public void LoadImage_Click(object sender, EventArgs e) { LoadImage_Click(); }
        public void LoadImage_Click()
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "Image Files (BMP,JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF, *.BMP";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(dialog.FileName);
                    Info = ImageHandler.GetImageInfo(dialog.FileName);
                    MessageBox.Show(Info);
                }
                catch
                {
                    Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                    Graphics g = Graphics.FromImage(b);
                    g.DrawString("Невозможно отобразить\n        изображение", new Font("Time New Roman", 15), new SolidBrush(Color.Red), new PointF(10, 10));
                    pictureBox1.Image = b;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Info))
            {
                ImageHandler.CopyInfo(Info);
            }
        }
    }
}
