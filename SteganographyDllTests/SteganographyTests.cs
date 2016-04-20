using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteganographyDll;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;
namespace SteganographyDllTests
{
    [TestClass]
    public class SteganographyTests
    {
        private SteganographyAbstractFactory stegaFactory = SteganographyProducer.GetFactory();
        private ISteganographyAlgorithms algo;
        [TestMethod]
        
        public void TestEncodeText()
        {
            string hiddenText = "ali";
            algo = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);
            byte[] hiddenArrayBytes = Encoding.ASCII.GetBytes(hiddenText);


            Image image = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\innocuous.png");
            Image imageNotModified = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\innocuous.png");

            algo.Encode(ref image, hiddenArrayBytes);
            Assert.AreNotEqual(imageNotModified, image);
            image.Save(@"c:\Users\Alina\Desktop\Temp\encoded.png", ImageFormat.Png);

        }
        [TestMethod]
        public void TestDecodeText()
        {
            algo = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);
            string expectedText = "ali";
            Image image = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\encoded.png");
            byte[] byteArrayText = null;
            algo.Decode(image, ref byteArrayText);


            string actualText = Encoding.Default.GetString(byteArrayText);
            Assert.AreEqual(expectedText, actualText);
        }

        [TestMethod]
        public void TestEncodeImage()
        {

            algo = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);


            Image hidden = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\hidden.png");
            Image image = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\innocuous.png");
            Image imageNotModified = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\innocuous.png");
            byte[] hiddenArrayBytes = Utils.BitmapToByteArray(hidden);
            algo.Encode(ref image, hiddenArrayBytes);
            Assert.AreNotEqual(imageNotModified, image);
            image.Save(@"c:\Users\Alina\Desktop\Temp\encoded.png", ImageFormat.Png);

        }
        [TestMethod]
        public void TestDecodeImage()
        {
            algo = stegaFactory.GetImplementationByFormat(ESupportedAlgorithms.ClasicAlgo);

            Image image = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\encoded.png");
            Image hidden = Image.FromFile(@"c:\Users\Alina\Desktop\Temp\hidded.png");
            byte[] expected = Utils.BitmapToByteArray(hidden);
            byte[] byteArrayText = null;
            algo.Decode(image, ref byteArrayText);

            Image img = Utils.ByteArrayToBitmap(byteArrayText);
            img.Save(@"c:\Users\Alina\Desktop\Temp\decoded.png", ImageFormat.Png);


        }



    }
}
