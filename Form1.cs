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

        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (BMP,JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF, *.BMP";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(openFileDialog.FileName);

                    string imagePath = openFileDialog.FileName;
                    FileInfo fileInfo = new FileInfo(imagePath);

                    // Время создания
                    string creationTime = fileInfo.CreationTime.ToString("dd.MM.yyyy, HH:mm");

                    // Название файла
                    string fileName = fileInfo.Name;

                    // Размер файла
                    double fileSizeInMb = fileInfo.Length / (1024.0 * 1024.0);
                    string fileSizeFormatted = fileSizeInMb.ToString("0.00") + " МБ";

                    // Разрешение
                    int imageWidth = pictureBox1.Image.Width;
                    int imageHeight = pictureBox1.Image.Height;
                    string resolution = $"{imageWidth} x {imageHeight} px";

                    var directories = ImageMetadataReader.ReadMetadata(imagePath);
                    var exifSubIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();
                    var jpegDirectory = directories.OfType<JpegDirectory>().FirstOrDefault();

                    string cameraModel = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagModel);
                    string cameraManufacturer = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagMake);
                    string aperture = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagFNumber);
                    string exposureTime = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagExposureTime);
                    string isoSpeed = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagIsoEquivalent);
                    string focalLength = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagFocalLength);
                    string flashMode = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagFlash);
                    string colorSpace = exifSubIfdDirectory?.GetString(ExifDirectoryBase.TagColorSpace);

                    // Расположение файла
                    string fileLocation = fileInfo.FullName;
                    Info = $"Время создания: {creationTime}\n" +
                                    $"Название файла: {fileName}\n" +
                                    $"Размер файла: {fileSizeFormatted}\n" +
                                    $"Разрешение: {resolution}\n\n" +
                                    $"Модель камеры: {cameraModel}\n" +
                                    $"Изготовитель камеры: {cameraManufacturer}\n" +
                                    $"Диафрагма: {aperture}\n" +
                                    $"Выдержка: {exposureTime}\n" +
                                    $"Скорость ISO: {isoSpeed}\n" +
                                    $"Фокусное расстояние: {focalLength}\n" +
                                    $"Режим вспышки: {flashMode}\n" +
                                    $"Представление цвета: {colorSpace}\n\n" +
                                    $"Расположение файла: {fileLocation}";
                    // Вывод информации
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
                Clipboard.SetText(Info);
        }
    }
}
