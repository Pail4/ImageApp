using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (BMP,JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF, *.BMP";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);
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
    }
}
