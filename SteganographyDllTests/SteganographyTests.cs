using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SteganographyDll;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

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
            format = stegaFactory.GetImplementationByFormat(ESupportedFormats.BmpFormat);
            Bitmap IndexedImage = new Bitmap("C:\\Users\\Alina\\Desktop\\Licenta\\test_licenta.bmp");

            Bitmap bitmap = IndexedImage.Clone(new Rectangle(0, 0, IndexedImage.Width, IndexedImage.Height), System.Drawing.Imaging.PixelFormat.Format32bppArgb);


            
           
            format.Encode(ref bitmap, "Alina");
            bitmap.Save("C:\\Users\\Alina\\Desktop\\Licenta\\test_modified2.bmp");
            //try
            //{
            //    using (Bitmap tempImage = new Bitmap(bitmap))
            //    {
            //        tempImage.Save("C:\\Users\\Alina\\Desktop\\Licenta\\test_modified2.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            //    }
            //}
            //catch (Exception e)
            //{
                
            //}


            //bitmap.Save("C:\\Users\\Alina\\Desktop\\Licenta\\Temp\\test_modified2.bmp", ImageFormat.Bmp);
                        
            
        }
        [TestMethod]
        public void DecodeTest()
        {
            Bitmap bitmap = new Bitmap("C:\\Users\\Alina\\Desktop\\Licenta\\test_modified2.bmp");
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
