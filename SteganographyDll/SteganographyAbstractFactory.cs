using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    public enum ESupportedAlgorithms
    {
        ClasicAlgo=0x00
    }
    public abstract class SteganographyAbstractFactory
    {
        public abstract ISteganographyAlgorithms GetImplementationByFormat(ESupportedAlgorithms format);
    }
}
