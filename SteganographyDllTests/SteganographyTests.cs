using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteganographyDll;
using System.Drawing;
namespace SteganographyDllTests
{
    [TestClass]
    public class SteganographyTests
    {
        private SteganographyAbstractFactory stegaFactory = SteganographyProducer.GetFactory();
        private ISteganographyFormats format;
        [TestMethod]
        public void EncodeTest()
        {
            format= stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);
            Bitmap indexedBitmap = new Bitmap("D:\\Temp\\test2.bmp");
            format.Encode(ref indexedBitmap, "Alina");
            indexedBitmap.Save("D:\\Temp\\test_modified2.bmp");
            
            
        }
        [TestMethod]
        public void DecodeTest()
        {
            Bitmap bitmap = new Bitmap("D:\\Temp\\test_modified2.bmp");
            String actual = "";
            String expected = "Alina";
            format = stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);
            format.Decode(bitmap, ref actual);
            

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ObjectTypeTest()
        {
            
            format = stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);
            Assert.AreEqual(ESupportedFormats.BmpFormat, format.GetSelectedFormat());
        }
    }
}
