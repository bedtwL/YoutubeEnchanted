using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoutubeEnchanted.Installer
{
    public partial class Installer : Form
    {
        public Installer()
        {
            InitializeComponent();
        }
        bool Installing = false;
        private void Installer_Load(object sender, EventArgs e)
        {
            this.Text="YoutubeEnchanted Installer v"+Application.ProductVersion.Substring(0,5);
            this.Controls.Add(new UI.StillWorkingOnProject() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,Size=this.Size });
        }

        private void Installer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Installing)
            {
                MessageBox.Show("Cannot Exit now, Installation is running", "YoutubeEnchanted Installer v"+Application.ProductVersion.Substring(0,5));
                e.Cancel= true;
            }
        }
    }
}
