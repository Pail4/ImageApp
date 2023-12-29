using ImageApp;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expectedInfo = "Время создания: 28.12.2023, 21:39\r\nНазвание файла: test.jpg\r\nРазмер файла: 2,10 МБ\r\nРазрешение: 4640 x 2048 px\r\n\r\nМодель камеры: \r\nИзготовитель камеры: \r\nДиафрагма: 1,89\r\nВыдержка: 59997/500000\r\nСкорость ISO: 3278\r\nФокусное расстояние: 5,43\r\nРежим вспышки: 0\r\nПредставление цвета: 1\r\n\r\nРасположение файла: D:\\Programming\\1\\ImageApp\\test.jpg";
            var info = ImageHandler.GetImageInfo("../../../../test.jpg");

            var copiedInfo = ImageHandler.CopyInfo(info);

            Assert.AreEqual(expectedInfo, info);
            Assert.AreEqual(expectedInfo, copiedInfo);
        }
    }
}