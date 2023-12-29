using ImageApp;

namespace BankTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expectedInfo = "����� ��������: 28.12.2023, 21:39\r\n�������� �����: test.jpg\r\n������ �����: 2,10 ��\r\n����������: 4640 x 2048 px\r\n\r\n������ ������: \r\n������������ ������: \r\n���������: 1,89\r\n��������: 59997/500000\r\n�������� ISO: 3278\r\n�������� ����������: 5,43\r\n����� �������: 0\r\n������������� �����: 1\r\n\r\n������������ �����: D:\\Programming\\1\\ImageApp\\test.jpg";
            var info = ImageHandler.GetImageInfo("../../../../test.jpg");

            var copiedInfo = ImageHandler.CopyInfo(info);

            Assert.AreEqual(expectedInfo, info);
            Assert.AreEqual(expectedInfo, copiedInfo);
        }
    }
}