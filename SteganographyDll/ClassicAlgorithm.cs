using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    
    
    class ClassicAlgorithm : ISteganographyAlgorithms
    {
        
       
        public override void Encode(ref Image image, byte[] data)
        {
            //throw exception is size of data is greater than Image
            if(data.Length>(3*image.Width*image.Height))
            {
                throw new TextTooLongException();
            }

            //set encodeProgress to 0;
            
            //calculate the length of the data that will be encoded
            byte[] hiddenLengthBytes = new byte[4];
            hiddenLengthBytes[0] = (byte)(data.Length);
            hiddenLengthBytes[1] = (byte)(data.Length >> 8);
            hiddenLengthBytes[2] = (byte)(data.Length >> 16);
            hiddenLengthBytes[3] = (byte)(data.Length >> 24);
            //create a buffer that will contain the size of the data and data;
            byte[] hiddenCombinedBytes = Utils.Combine(hiddenLengthBytes, data);
            //get rgb bytes from image
            byte[] rgbComponents = Utils.RgbComponentsToBytes(image);
            //encoding data
            byte[] encodedRgbComponents = EncodeBytes(hiddenCombinedBytes, rgbComponents);
            Bitmap encodedBitmap = Utils.ByteArrayToBitmap(encodedRgbComponents, image.Width, image.Height);
            image = encodedBitmap;
        }

        public override void Decode(Image picture, ref byte[] text)
        {
            byte[] imageBytes = Utils.RgbComponentsToBytes(picture);
            byte[] hiddenLengthBytes = DecodeBytes(imageBytes, 0, sizeof(Int32));
            if (hiddenLengthBytes == null)
            {
                text = Encoding.ASCII.GetBytes(new string(' ', 1));
            }
            Int32 hiddenLength = BitConverter.ToInt32(hiddenLengthBytes, 0);
            byte[] hiddenBytes = DecodeBytes(imageBytes, sizeof(Int32), hiddenLength);
            text = hiddenBytes;

        }
        
        #region private methods
        private byte[] EncodeBytes(byte[] hiddenBytes, byte[] rgbComponents)
        {
            encodeProgress = 0;
            BitArray hiddenBits = new BitArray(hiddenBytes);
            byte[] encodedBitmapRgbComponents = new byte[rgbComponents.Length];
            Int32 i;
            for (i = 0; i < rgbComponents.Length && i < hiddenBits.Length; i++)
            {

                byte evenByte = (byte)(rgbComponents[i] - rgbComponents[i] % 2);
                encodedBitmapRgbComponents[i] = (byte)(evenByte + (hiddenBits[i] ? 1 : 0));
                encodeProgress++;
                /*
                 * How progress is calculated:
                 *  l-----100%
                 *  x------y
                 *  y=(x*100)/l
                 * Where l is the length of the hidden message, x is the current character 
                 * and y is the calculated percent
                 */
                OnProgressUpdateEncode((encodeProgress*100)/hiddenBytes.Length);

            }
            //Buffer.BlockCopy(encodedBitmapRgbComponents, i, encodedBitmapRgbComponents, i, encodedBitmapRgbComponents.Length - i);
            Buffer.BlockCopy(rgbComponents, i, encodedBitmapRgbComponents, i, encodedBitmapRgbComponents.Length - i);
            return encodedBitmapRgbComponents;
        }

 


        private byte[] DecodeBytes(byte[] imageBytes, Int32 byteIndex, Int32 byteCount)
        {
            const int noOfBitsInByte = 8;
            decodeProgress = 0;
            Int32 bitCount = byteCount * noOfBitsInByte;
            Int32 bitIndex = byteIndex * noOfBitsInByte;
            bool[] hiddenBools = null; 
            try
            {
                hiddenBools = new bool[bitCount];
            }
            catch(System.OverflowException e)
            {
                return null;
            }
             
            for (Int32 i = 0; i < bitCount; i++)
            {
                hiddenBools[i] = (imageBytes[i + bitIndex] % 2 == 1);
                //this if is used only for updating progress when text is decoded from image, not length
                if(byteCount!=sizeof(Int32))
                {
                    /*
                     * How progress is calculated:
                     *  l-----100%
                     *  x------y
                     *  y=(x*100)/l
                     * Where l is the length of the hidden message, x is the current character 
                     * and y is the calculated percent
                     */
               //     OnProgressUpdateDecode((decodeProgress * 100) / byteCount);
                }
                
            }
            BitArray hiddenBits = new BitArray(hiddenBools);
            byte[] hiddenBytes = new byte[hiddenBits.Length / noOfBitsInByte];
            hiddenBits.CopyTo(hiddenBytes, 0);
            return hiddenBytes;

        }
        #endregion
    }
}
