using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    public enum ESupportedFormats
    {
        BmpFormat=0x00
    }
    public abstract class SteganographyAbstractFactory
    {
        public abstract ISteganographyFormats GetImplementationByFormat(ESupportedFormats format);
    }
}
