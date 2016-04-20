using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyDll
{
    public class ProgressNotification : EventArgs
    {
        private readonly Int32 encodeProgress;
        private readonly Int32 decodeProgress;
        public ProgressNotification(Int32 encodeProgress, Int32 decodeProgress)
        {
            this.encodeProgress = encodeProgress;
            this.decodeProgress = decodeProgress;
        }
        public Int32 EncodeProgress
        {
            get
            {
                return encodeProgress;
            }
        }
        public Int32 DecodeProgress
        {
            get
            {
                return decodeProgress;
            }
        }
    }
}
