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
using Vlc.DotNet.Forms;
using YoutubeEnchanted.API;
using YoutubeExplode;
using YoutubeExplode.Common;
using static YoutubeEnchanted.API.APICore;

namespace YoutubeEnchanted.UI
{
    public partial class BGN_VIDEO : Form
    {
        VlcControl videoPlayCore = new VlcControl();
        public BGN_VIDEO()
        {
            InitializeComponent();

         

        }
        private void VideoPlayCore_Log(object sender, Vlc.DotNet.Core.VlcMediaPlayerLogEventArgs e)
        {
            API.APICore.Log(e.Message);
           
        }
        string nowurl="";
        private async void UpdateVideo(string id, string top)
        {
            var youtube = new YoutubeExplode.YoutubeClient(APICore.HttpClient());
            flowLayoutPanel1.Controls.Clear();
            foreach (var result in await youtube.Search.GetVideosAsync(id).CollectAsync(20))
            {
                if (flowLayoutPanel1.Controls.Count == 20)
                { }
                else { flowLayoutPanel1.Controls.Add(new UI.VideoControl(result.Url, top)); }




            }
        }
        private MainPage MainSec;
        private async void Tick()
        {
            await Task.Delay(1000);
            this.Controls.Add(MainSec= new UI.MainPage() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom, Size = this.Size });
            do
            {
                try
                {
                 
       
                    
                    if (APICore.ShowPlayControlMenu)
                    {
                        //APICore.PARSED_URL = false;
                        if (nowurl == APICore._PARSE_URL)
                        {
                            switch (videoPlayCore.State)
                            {
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.NothingSpecial:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.StopIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Opening:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PauseIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Buffering:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PauseIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Playing:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PauseIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Paused:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PlayIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Stopped:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.StopIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.StopIcon;
                                    break;
                                case Vlc.DotNet.Core.Interops.Signatures.MediaStates.Error:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.StopIcon;
                                    break;
                                default:
                                    pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.StopIcon;
                                    break;
                            }
                            

                        }
                        else {
                            pictureBox4.Visible = true;
                            label6.Visible = true;
                            label4.Visible = true;
                            label5.Visible = true;
                            label3.Visible = true;
                            label2.Visible = true;

                            flowLayoutPanel1.Visible = true;
                            nowurl = APICore._PARSE_URL;
                            panel2.Visible = true;
                            this.videoPlayCore.Dispose();
                            await Task.Delay(1000);
                            this.videoPlayCore = new VlcControl();
                            this.panel2.SuspendLayout();

                            ((System.ComponentModel.ISupportInitialize)(this.videoPlayCore)).BeginInit();
                            //videoPlayCore.Dock = DockStyle.Fill;
                            this.videoPlayCore.BackColor = System.Drawing.Color.Black;
                            this.videoPlayCore.Location = new System.Drawing.Point(10, 10);
                            this.videoPlayCore.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
                            this.videoPlayCore.Name = "videoPlayCore";
                            videoPlayCore.Size = new Size(panel2.Size.Width - 20, panel2.Height - 20);
                            videoPlayCore.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
                            //this.videoPlayCore.Size = new System.Drawing.Size(776, 416);
                            this.videoPlayCore.Spu = -1;
                            this.videoPlayCore.TabIndex = 0;
                            this.videoPlayCore.Text = "videoPlayCore";
                            this.videoPlayCore.VlcLibDirectory = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "VLCLIBx64");
                            this.videoPlayCore.VlcMediaplayerOptions = null;

                            this.panel2.Controls.Add(videoPlayCore);
                            
                            videoPlayCore.TimeChanged += VideoPlayCore_TimeChanged;
                            videoPlayCore.Log += VideoPlayCore_Log;
                            ((System.ComponentModel.ISupportInitialize)(this.videoPlayCore)).EndInit();
                            this.panel2.ResumeLayout();
                            pictureBox1.BackgroundImage = global::YoutubeEnchanted.Properties.Resources.PauseIcon;
                            videoPlayCore.Play(APICore._PARSE_URL);
                            UpdateVideo(APICore.NOW_URL,APICore.Topic);
                            label5.Text = APICore.VideoDes;
                           

                            label4.Text= APICore.Title;
                            UpdateVideoAuthor(APICore.Topic);
                            API.APICore.Log("Playing " + APICore._PARSE_URL);
                        }
                        
                    }
                    else
                    {
                        label6.Visible = false;
                        label4.Visible =false;
                        label5.Visible = false;
                        label3.Visible= false;
                        pictureBox4.Visible = false;
                        flowLayoutPanel1.Visible = false;
                        label2.Visible = false;
                        panel2.Visible = false;
                        try { videoPlayCore.Dispose(); } catch { }
                        //API.APICore.Log("Not Playing Any thing");
                    }
                    if (Program.error)
                    {
                        this.panel3 = new System.Windows.Forms.Panel();
                        // 
                        // panel3
                        // 
                        this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
                        this.panel3.AutoScroll = true;
                        this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;

                        this.panel3.Location = new System.Drawing.Point(143, 31);
                        this.panel3.Name = "panel3";
                        this.panel3.Size = new System.Drawing.Size(945, 627);
                        this.panel3.TabIndex = 14;
                        this.panel3.Visible = false;
                        this.panel3.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel3_ControlAdded);
                        this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
                        panel3.Controls.Add(Program.errorForm);
                        return;
                    }
                    //API.APICore.Log("Ticked");

                }
                catch (Exception ex) { API.APICore.Log(ex.Message); }
                await Task.Delay(500);
            } while (true);
        }
        private async void UpdateVideoAuthor(string vidUrl)
        {
            try
            {
                YoutubeExplode.YoutubeClient yt = new YoutubeExplode.YoutubeClient(new System.Net.Http.HttpClient());
                try
                {
                    var vid = await yt.Videos.GetAsync(vidUrl);
                   
                    var us = await yt.Channels.GetAsync(vid.Author.ChannelUrl);
                    label6.Text= us.Title;
                    pictureBox4.LoadAsync(us.Thumbnails[0].Url);

                }
                catch
                {
                    pictureBox4.Image = null;

                }
            }
            catch (Exception ex) { API.APICore.Log(ex.Message); this.Dispose(); }
        }
        private void VideoPlayCore_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            colorSlider1.Maximum = videoPlayCore.Length / 1000;
            colorSlider1.Value = videoPlayCore.Time / 1000;
            colorSlider2.Value = videoPlayCore.Audio.Volume;
            label1.Text=APICore.ToFriendllyTime(videoPlayCore.Time)+"/"+APICore.ToFriendllyTime(videoPlayCore.Length);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void colorSlider1_Scroll(object sender, ScrollEventArgs e)
        {

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
        private void BGN_VIDEO_Load(object sender, EventArgs e)
        {
            Tick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APICore.ShowPlayControlMenu = false;
        }
        Point panel3ctrlPoint = new Point(10,10);
        private void panel3_ControlAdded(object sender, ControlEventArgs e)
        {
            
            e.Control.Anchor= AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            e.Control.Size =new Size(panel3.Size.Width-20,panel3.Height-20);
            e.Control.Location =panel3ctrlPoint;
            panel3ctrlPoint = new Point(0,panel3ctrlPoint.Y+e.Control.Height);
            panel3.Visible = true;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != panel3)
                { ctrl.Enabled = false; }
            
            }
            panel3.Enabled= true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BGN_VIDEO_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode) 
            {
                case Keys.Enter:
                    MainSec.StartSerch(textBox1.Text);
                    textBox1.Text = "";
                    break;
                case Keys.Space:
                    try { videoPlayCore.Pause(); } catch(Exception ex) { APICore.Log("User Press Space but "+ex.Message); APICore.Log(ex.StackTrace); }
                    break;

          
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MainSec.StartSerch(textBox1.Text);
            APICore.ShowPlayControlMenu = false;
            textBox1.Text = "";
        }
        int createsize = 10;
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            createsize = e.Control.Size.Height + createsize;
            e.Control.Location = new Point(10, createsize);
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            try { flowLayoutPanel1.Controls[-1].Location = e.Control.Location; } catch(Exception ex) { APICore.Log(ex.Message);APICore.Log(ex.StackTrace); }
  
        }
    }
}
