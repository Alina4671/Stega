using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    public class Utils
    {
        #region Function designed to be used just inside DLL's code
        internal static byte[] Combine(byte[] left, byte[] right)
        {
            byte[] combined = new byte[left.Length + right.Length];
            Buffer.BlockCopy(left, 0, combined, 0, left.Length);
            Buffer.BlockCopy(right, 0, combined, left.Length, right.Length);
            return combined;
        }


        internal static byte[] RgbComponentsToBytes(Image inputImage)
        {
            //create a bitmap
            Bitmap bitmapImage = new Bitmap(inputImage);
            //This method will get pixels and set them in a byte array;
            Int32 counter = 0;
            byte[] components = new byte[3 * bitmapImage.Width * bitmapImage.Height];
            for (Int32 y = 0; y < bitmapImage.Height; y++)
            {
                for (Int32 x = 0; x < bitmapImage.Width; x++)
                {
                    Color color = bitmapImage.GetPixel(x, y);
                    components[counter++] = color.R;
                    components[counter++] = color.G;
                    components[counter++] = color.B;
                }
            }
            return components;

        }

        internal static Bitmap ByteArrayToBitmap(byte[] encodedRgbComponents, int width, int height)
        {
            Queue<byte> rgbComponentsQueue = new Queue<byte>(encodedRgbComponents);
            Bitmap bitmap = new Bitmap(width, height);
            for (Int32 y = 0; y < height; y++)
            {
                for (Int32 x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(rgbComponentsQueue.Dequeue(), rgbComponentsQueue.Dequeue(), rgbComponentsQueue.Dequeue()));
                }
            }
            return bitmap;


        }
        #endregion
        public static Image ByteArrayToBitmap(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }
        public static byte[] BitmapToByteArray(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

    }
}
