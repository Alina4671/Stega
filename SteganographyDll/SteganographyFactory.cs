using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    class SteganographyFactory:SteganographyAbstractFactory
    {
        public override ISteganographyFormats GetImplementationByFormat(ESupportedFormats format)
        {
            switch(format)
            {
                case ESupportedFormats.BmpFormat:
                    return new BmpFormat();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
