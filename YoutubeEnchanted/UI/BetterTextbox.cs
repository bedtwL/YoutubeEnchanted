using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeEnchanted.UI
{
    internal class BetterTextbox:TextBox
    {
        public BetterTextbox() { BorderStyle = BorderStyle.None;ReadOnly = true;BackColor = System.Drawing.Color.White; }
    }
}
