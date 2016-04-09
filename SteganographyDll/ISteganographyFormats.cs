using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
  
    public interface ISteganographyFormats
    {

        void Encode(ref Bitmap picture, String text);
        void Decode(Bitmap picture, ref String text);
        ESupportedFormats GetSelectedFormat();
    }
}
