using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using YoutubeEnchanted.API;

namespace YoutubeEnchanted.UI
{
    public partial class VideoPlayerPage : UserControl
    {
        VlcControl videoPlayCore = new VlcControl();
        string _url;
        public VideoPlayerPage(string url)
        {
            InitializeComponent();
            this.panel2.SuspendLayout();
            //videoPlayCore.Size = new Size(panel2.Size.Width-10,panel2.Height-10);
            //videoPlayCore.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayCore)).BeginInit();
            videoPlayCore.Dock= DockStyle.Fill;
            this.videoPlayCore.BackColor = System.Drawing.Color.Black;
            this.videoPlayCore.Location = new System.Drawing.Point(0, 0);
            this.videoPlayCore.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.videoPlayCore.Name = "vlcControl1";
            this.videoPlayCore.Size = new System.Drawing.Size(776, 416);
            this.videoPlayCore.Spu = -1;
            this.videoPlayCore.TabIndex = 0;
            this.videoPlayCore.Text = "videoPlayCore";
            this.videoPlayCore.VlcLibDirectory = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "VLCLIBx64");
            this.videoPlayCore.VlcMediaplayerOptions = null;
            this.panel2.Controls.Add(videoPlayCore);
            videoPlayCore.TimeChanged += VideoPlayCore_TimeChanged;
            videoPlayCore.Log += VideoPlayCore_Log;
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayCore)).EndInit();
            this.panel1.ResumeLayout();
            _url = url;
           


        }

        private void VideoPlayCore_Log(object sender, Vlc.DotNet.Core.VlcMediaPlayerLogEventArgs e)
        {
           API.APICore.Log(e.Message);
        }

        private void VideoPlayerPage_Load(object sender, EventArgs e)
        {

        }
        private void VideoPlayCore_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            colorSlider1.Maximum = videoPlayCore.Length / 1000;
            colorSlider1.Value = videoPlayCore.Time / 1000;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void colorSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            videoPlayCore.Time = long.Parse(colorSlider1.Value.ToString()) * 1000;
        }
        private async void panel1_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            panel1.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void colorSlider2_Scroll(object sender, ScrollEventArgs e)
        {
            videoPlayCore.Audio.Volume = int.Parse(colorSlider2.Value.ToString());
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            videoPlayCore.Pause();
        }
    }
}
