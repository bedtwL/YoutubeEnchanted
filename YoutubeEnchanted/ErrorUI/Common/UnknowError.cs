using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeEnchanted.ErrorUI.Common
{
    public partial class UnknowError : UserControl
    {
        public UnknowError(Exception exception)
        {
            InitializeComponent();
            label2.Text = "Why this happen? \nUnknow error Found in " + exception.Source + "\n More info:\n"+exception.StackTrace+"";
            label1.Text ="Error, "+ exception.Message;
    
        }

        private void UnknowError_Load(object sender, EventArgs e)
        {

        }
    }
}
