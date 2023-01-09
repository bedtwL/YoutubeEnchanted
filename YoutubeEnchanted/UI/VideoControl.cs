using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeEnchanted.API;
using YoutubeExplode.Channels;
using YoutubeExplode.Common;
using static YoutubeEnchanted.API.APICore;

namespace YoutubeEnchanted.UI
{
    public partial class VideoControl : UserControl
    {
        string videoURL;
        string Topics;
        public VideoControl(string vidURL,string Topic)
        {
            InitializeComponent();
            videoURL = vidURL;
            Topics= Topic;
            UpdateVideo();

           
        }

        private void VideoControl_Load(object sender, EventArgs e)
        {
            //APICore.ParseUrl(videoURL);
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }
        private async void UpdateVideo()
        {
            try {
                YoutubeExplode.YoutubeClient yt = new YoutubeExplode.YoutubeClient(APICore.HttpClient());
                APICore.Log("Getting metadata from "+videoURL);
                try
                {
                    var vid = await yt.Videos.GetAsync(videoURL);
                    label1.Text = vid.Title; label2.Text = vid.Author.ChannelTitle;
                    label3.Text = vid.Duration.ToString();
                    pictureBox1.LoadAsync(vid.Thumbnails.GetWithHighestResolution().Url);
                    var us = await yt.Channels.GetAsync(vid.Author.ChannelUrl);
                    pictureBox2.LoadAsync(us.Thumbnails[0].Url);
                    APICore.Log("Metadata Geted ("+videoURL+")");

                }
                catch (YoutubeExplode.Exceptions.RequestLimitExceededException ex)
                {
                    APICore.Log(ex.Message);
                    APICore.Log(ex.StackTrace);
                    Program.errorForm = new ErrorUI.Common.YoutubeLimted();
                    Program.error = true;

                }
                catch
                {
                    label3.Visible = false; label2.Visible = false; label1.Text = Path.GetFileNameWithoutExtension(videoURL); pictureBox2.Visible = false;
                    pictureBox1.BackgroundImage = WindowsThumbnailProvider.GetThumbnail(videoURL, 256, 256, ThumbnailOptions.None);

                }
                
            } catch(Exception ex) { API.APICore.Log(ex.Message); this.Dispose(); }
            
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //API.APICore.Log("Playing "+videoURL);
            Play(videoURL,Topics);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.Black;
                control.ForeColor = Color.White;
            }
            this.BackColor= Color.Black;
            this.Location = new Point(this.Location.X - 10, this.Location.Y -10);
            this.Size = new Size(this.Width+20,this.Height+20);
            try {this.BringToFront(); } catch (Exception ex) { APICore.Log(ex.Message); APICore.Log(ex.StackTrace); }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                control.BackColor = Color.White;
                control.ForeColor = Color.Black;
            }
            this.BackColor = Color.White;
            this.Location = new Point(this.Location.X+10,this.Location.Y+10);
            this.Size = new Size(this.Width - 20, this.Height- 20);
            try { this.SendToBack(); } catch(Exception ex) { APICore.Log(ex.Message);APICore.Log(ex.StackTrace); }
            
        }
    }
}
