using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    public class TextTooLongException : Exception
    {
        public TextTooLongException()
        {
        }

        const String message = "Text for encode is too long for the choosed image.";
    }
}
