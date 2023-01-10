using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeEnchanted.UI
{
    public partial class Message : UserControl
    {
        public Message(string message)
        {
            InitializeComponent();
            label2.Text = message;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
