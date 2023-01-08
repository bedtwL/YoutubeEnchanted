using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeEnchanted.API;

namespace YoutubeEnchanted.ErrorUI.Common
{
    public partial class YoutubeLimted : UserControl
    {
        public YoutubeLimted()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            // 
            // webView21
            // 
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.webView21.AllowExternalDrop = true;
            this.webView21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(15, 8);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(715, 308);
            this.webView21.TabIndex = 3;
            this.webView21.Visible = false;
            this.webView21.ZoomFactor = 1D;
            this.Controls.Add(this.webView21);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            label1.Visible = false;
            webView21.Visible = true;
            webView21.Source = new Uri("https://youtube.com");
        }

        private void Error_Load(object sender, EventArgs e)
        {
            APICore.Log("Created Error.Common.YoutubeLimted UI embed.");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Program.OpenLog();
        }
    }
}
