using MetadataExtractor.Formats.Exif;
using MetadataExtractor.Formats.Jpeg;
using MetadataExtractor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageApp
{
    internal class ImageHandler
    {
        static public string GetImageInfo(string path)
        {
            string imagePath = path;
            FileInfo fileInfo = new FileInfo(imagePath);

            // Время создания
            string creationTime = fileInfo.CreationTime.ToString("dd.MM.yyyy, HH:mm");

            // Название файла
            string fileName = fileInfo.Name;

            // Размер файла
            double fileSizeInMb = fileInfo.Length / (1024.0 * 1024.0);
            string fileSizeFormatted = fileSizeInMb.ToString("0.00") + " МБ";

            // Разрешение
            string resolution = ImageHandler.GetImageResolution(path);

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
            var Info = $"Время создания: {creationTime}\n" +
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
            return Info;
        }



        static public string GetImageResolution(string path)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(path))
                {
                    int width = bitmap.Width;
                    int height = bitmap.Height;
                    return $"{width} x {height} px";
                }
            }
            catch (Exception ex)
            {
                // Обработка ошибок при получении разрешения
                return "Невозможно получить разрешение: " + ex.Message;
            }
        }

        static public void CopyInfo(string info)
        {
            Clipboard.SetText(info);
        }
    }
}
