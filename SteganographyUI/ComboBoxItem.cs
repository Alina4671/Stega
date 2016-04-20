using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteganographyUI
{
    public class ComboBoxItem
    {
        public ComboBoxItem(byte ItemId,string ItemName)
        {
            this.ItemId = ItemId;
            this.ItemName = ItemName;
        }
        public byte ItemId { get; set; }
        public string ItemName { get; set; }
        public override string ToString()
        {
            return ItemName;
        }
    }

}
