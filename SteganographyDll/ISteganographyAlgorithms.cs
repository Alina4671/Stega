using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
  
    public abstract class ISteganographyAlgorithms
    {
        protected Int32 encodeProgress;
        protected Int32 decodeProgress;

        public event EventHandler<ProgressNotification> ProgressUpdateEncode;
        public event EventHandler<ProgressNotification> ProgressUpdateDecode;

        public abstract void Encode(ref Image picture, byte[] data);
        public abstract void Decode(Image picture, ref byte[] text);

        protected virtual void OnProgressUpdateEncode(Int32 e)
        {
            var handler = ProgressUpdateEncode;
            if (handler != null)
            {
                handler(this, new ProgressNotification(encodeProgress, decodeProgress));
            }
        }
        protected virtual void OnProgressUpdateDecode(Int32 e)
        {
            var handler = ProgressUpdateDecode;
            if (handler != null)
            {
                handler(this, new ProgressNotification(encodeProgress, decodeProgress));
            }
        }

    }
}
