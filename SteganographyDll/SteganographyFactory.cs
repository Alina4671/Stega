using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    class SteganographyFactory:SteganographyAbstractFactory
    {
        public override ISteganographyAlgorithms GetImplementationByFormat(ESupportedAlgorithms format)
        {
            switch(format)
            {
                case ESupportedAlgorithms.ClasicAlgo:
                    return new ClassicAlgorithm();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
