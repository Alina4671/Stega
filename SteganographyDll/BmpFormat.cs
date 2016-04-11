using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    enum EStateEncode
    {
        HiddingCharacters,
        FillingZeroes

    }
    class BmpFormat : ISteganographyFormats
    {
        private const byte NUMBER_OF_TRAILLING_ZEROES = 8;
        #region Private Methods for extracting pixels from picture,recreating picture and decoding
        private int reverseBits(int n)
        {
            int result = 0;

            for (int i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;

                n /= 2;
            }

            return result;
        }
        private void AlgoEncode(ref Color[] modifiedPixelsBuffer, Color[] originalBuffer, String text, int length)
        {
            byte red, green, blue;
            EStateEncode encodeAlgoState = EStateEncode.HiddingCharacters;
            int character = 0x00;
            int characterIndex = 0;
            int pixelIndex = 0;
            byte charValueBuffer = 0x00;
            byte zeroes = 0;
            byte bitsConsumedPerCharacter = 0;
            foreach (Color pixel in originalBuffer)
            {
                red = (byte)(pixel.R & (~(1 << 0)));
                green = (byte)(pixel.G & (~(1 << 0)));
                blue = (byte)(pixel.B & (~(1 << 0)));

                for (int n = 0; n < 3; n++)
                {
                    if (bitsConsumedPerCharacter % 8 == 0)
                    {
                        if (encodeAlgoState == EStateEncode.FillingZeroes && zeroes == NUMBER_OF_TRAILLING_ZEROES)
                        {
                            if ((bitsConsumedPerCharacter - 1) % 3 < 2)
                            {
                                modifiedPixelsBuffer[pixelIndex] = Color.FromArgb(red, green, blue);
                            }
                        }
                        if (characterIndex >= text.Length)
                        {
                            encodeAlgoState = EStateEncode.FillingZeroes;
                        }
                        else
                        {
                            character = text[characterIndex++];
                        }
                    }
                    if (encodeAlgoState == EStateEncode.HiddingCharacters)
                    {
                        charValueBuffer = (byte)(character % 2);
                        character /= 2;
                    }

                    switch (bitsConsumedPerCharacter % 3)
                    {
                        case 0:
                            {
                                red += charValueBuffer;
                            } break;
                        case 1:
                            {
                                green += charValueBuffer;
                            } break;
                        case 2:
                            {
                                blue += charValueBuffer;
                                modifiedPixelsBuffer[pixelIndex++] = Color.FromArgb(red, green, blue);
                            } break;
                    }
                    bitsConsumedPerCharacter++;
                    if (encodeAlgoState == EStateEncode.FillingZeroes)
                    {
                        zeroes++;
                    }
                }

            }
        }

        private Color[] ExtractPixelsBuffer(Bitmap picture, int neededLength)
        {
            int i, j;
            int bufferLength = 0;
            bool isTextFullyConsumed = false;
            Color[] pixelsBuffer = new Color[neededLength];
            for (i = 0; i < picture.Width && isTextFullyConsumed == false; i++)
            {
                for (j = 0; j < picture.Height && isTextFullyConsumed == false; j++)
                {
                    if (bufferLength < neededLength)
                    {
                        Color pixel = picture.GetPixel(i, j);
                        pixelsBuffer[bufferLength] = pixel;
                        bufferLength++;
                    }
                    else
                    {
                        isTextFullyConsumed = true;
                    }

                }
            }
            return pixelsBuffer;
        }
        public void recreatePicture(ref Bitmap picture, Color[] modifiedPixelsBuffer)
        {
            int bufferIndex = 0;
            bool isRecreatingDone = false;
            for (int i = 0; i < picture.Width && isRecreatingDone == false; i++)
            {
                for (int j = 0; j < picture.Height && isRecreatingDone == false; j++)
                {
                    if (bufferIndex < modifiedPixelsBuffer.Length)
                    {
                        picture.SetPixel(i, j, modifiedPixelsBuffer[bufferIndex++]);
                    }
                    else
                    {
                        isRecreatingDone = true;
                    }
                }
            }
        }
        #endregion
        
        public void Encode(ref Bitmap picture, String text)
        {

            int length = (text.Length + NUMBER_OF_TRAILLING_ZEROES) * 3;
            if ((text.Length*3) > (picture.Width * picture.Height))
            {
                throw new TextTooLongException();
            }
            Color[] pixelsBuffer = ExtractPixelsBuffer(picture, length);

            Color[] modifiedPixelsBuffer = new Color[length];
            AlgoEncode(ref modifiedPixelsBuffer, pixelsBuffer, text, length);
            recreatePicture(ref picture, modifiedPixelsBuffer);

        }


        public void Decode(Bitmap picture, ref String text)
        {
            int colorUnitIndex = 0;
            int charValue = 0;
            int numberOfZeroes = 0;
            for (int i = 0; i < picture.Width && numberOfZeroes<NUMBER_OF_TRAILLING_ZEROES; i++)
            {
                for (int j = 0; j < picture.Height && numberOfZeroes < NUMBER_OF_TRAILLING_ZEROES; j++)
                {
                    Color pixel = picture.GetPixel(i, j);
                    for (int n = 0; n < 3; n++)
                    {
                        switch (colorUnitIndex % 3)
                        {
                            case 0:
                                {
                                    charValue = charValue * 2 + pixel.R % 2;
                                } break;
                            case 1:
                                {
                                    charValue = charValue * 2 + pixel.G % 2;
                                } break;
                            case 2:
                                {
                                    charValue = charValue * 2 + pixel.B % 2;
                                } break;
                        }
                        colorUnitIndex++;
                        if (colorUnitIndex % 8 == 0)
                        {
                            charValue = reverseBits(charValue);
                            if (charValue != 0)
                            {
                                char c = (char)charValue;
                                text += c.ToString();
                            }
                            else
                            {
                                numberOfZeroes++;
                            }
                        }
                    }
                }
            }
        }







        public ESupportedFormats GetSelectedFormat()
        {
            return ESupportedFormats.BmpFormat;
        }
    }
}
