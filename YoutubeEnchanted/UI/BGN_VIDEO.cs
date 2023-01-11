using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using YoutubeEnchanted.API;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Converter;
using YoutubeExplode.Exceptions;
using YoutubeExplode.Videos.Streams;
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
        string nowurl = "";
        private async void UpdateVideo(string id, string top)
        {
            var youtube = new YoutubeExplode.YoutubeClient(APICore.HttpClient());
            createsize = 10;
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
            this.Controls.Add(MainSec = new UI.MainPage() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom, Size = this.Size,Location=new Point(0,10) });
            Message(new UI.Message("You are using YoutubeEnchanted v" + Application.ProductVersion.Substring(0, 5)));
            do
            {
                try
                {

                    if (APICore.FullScreen && this.FormBorderStyle == FormBorderStyle.Sizable)
                    { Message(new UI.Message("Full Screen is Enabled")); this.WindowState = FormWindowState.Normal; await Task.Delay(100); pictureBox7.Visible = true; this.FormBorderStyle = FormBorderStyle.None;this.WindowState = FormWindowState.Maximized; this.TopMost = true; }
                    else if (APICore.FullScreen == false&&this.FormBorderStyle==FormBorderStyle.None) { Message(new UI.Message("Full Screen is Disabled")); this.WindowState = FormWindowState.Normal; await Task.Delay(100); pictureBox7.Visible = false; this.FormBorderStyle = FormBorderStyle.Sizable;this.WindowState = FormWindowState.Maximized; this.TopMost = false; }
                    if (APICore.ShowPlayControlMenu)
                    {
                        //APICore.PARSED_URL = false;
                        if (nowurl == APICore._PARSE_URL)
                        {
                            pictureBox4.Visible = true;
                            label6.Visible = true;
                            label4.Visible = true;
                            
                            label3.Visible = true;
                            label2.Visible = true;
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
                        else
                        {
                            panel4.Visible = true;
                            pictureBox4.Visible = true;
                            label6.Visible = true;
                            label4.Visible = true;
                            
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

                            UpdateVideo(APICore.NOW_URL, APICore.Topic);
                            


                            label4.Text = APICore.Title;
                            UpdateVideoAuthor(APICore.NOW_URL);
                            API.APICore.Log("Playing " + APICore._PARSE_URL);
                        }

                    }
                    else
                    {
                        panel4.Visible = false;
                        label6.Visible = false;
                        label4.Visible = false;
                        
                        label3.Visible = false;
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
                    panel4.Visible = true;
                    richTextBox1.Text=vid.Description;
                    var us = await yt.Channels.GetAsync(vid.Author.ChannelUrl);
                    label6.Text = us.Title;
                    pictureBox4.LoadAsync(us.Thumbnails[0].Url);

                }
                catch(Exception ex)
                {
                    pictureBox4.Image = null;
                    Message(new Message("Cannot Load Author Info due to "+ex.Message+"\n"+ex.StackTrace));

                }
            }
            catch (Exception ex) { API.APICore.Log(ex.Message); this.Dispose(); }
        }
        private void VideoPlayCore_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            colorSlider1.Maximum = videoPlayCore.Length / 1000;
            colorSlider1.Value = videoPlayCore.Time / 1000;
            colorSlider2.Value = videoPlayCore.Audio.Volume;
            label1.Text = APICore.ToFriendllyTime(videoPlayCore.Time) + "/" + APICore.ToFriendllyTime(videoPlayCore.Length);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void colorSlider1_Scroll(object sender, ScrollEventArgs e)
        {
            if (videoPlayCore.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended)
            { videoPlayCore.Play(_PARSE_URL); }
            else { videoPlayCore.Time = long.Parse(colorSlider1.Value.ToString()) * 1000; }
        }
        private async void panel1_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(10000);
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
            if (videoPlayCore.State == Vlc.DotNet.Core.Interops.Signatures.MediaStates.Ended)
            {
                videoPlayCore.Play(_PARSE_URL);
            }
        }
        private void BGN_VIDEO_Load(object sender, EventArgs e)
        {
            Tick();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            APICore.ShowPlayControlMenu = false;
        }
        Point panel3ctrlPoint = new Point(10, 10);

        private void panel3_ControlAdded(object sender, ControlEventArgs e)
        {

            e.Control.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            e.Control.Size = new Size(panel3.Size.Width - 20, panel3.Height - 20);
            e.Control.Location = panel3ctrlPoint;
            panel3ctrlPoint = new Point(0, panel3ctrlPoint.Y + e.Control.Height);
            panel3.Visible = true;
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != panel3)
                { ctrl.Enabled = false; }

            }
            panel3.Enabled = true;
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
            APICore.Log("User Press " + e.KeyData.ToString());
            switch (e.KeyCode)
            {

                case Keys.Enter:
                    if (textBox1.Text == "")
                    { }
                    else
                    {
                        APICore.ShowPlayControlMenu = false;

                        MainSec.StartSerch(textBox1.Text);
                        textBox1.Text = "";
                    }
                    break;
                case Keys.Space:
                    try { videoPlayCore.Pause(); } catch (Exception ex) { APICore.Log("User Press Space but " + ex.Message); APICore.Log(ex.StackTrace); }
                    break;
                case Keys.Left:
                    videoPlayCore.Time = videoPlayCore.Time - 10000;
                    break;
                case Keys.Right:
                    videoPlayCore.Time = videoPlayCore.Time + 10000;
                    break;
                case Keys.F11:
                    APICore.FullScreen = APICore.ToggleBool(APICore.FullScreen);
                    break;
                case Keys.BrowserHome:
                    APICore.ShowPlayControlMenu = false;
                    break;


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { }
            else {
                APICore.ShowPlayControlMenu = false;
            
                MainSec.StartSerch(textBox1.Text);
                textBox1.Text = "";
            }
            
        }
        int createsize = 10;
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            createsize = e.Control.Size.Height + createsize;
            e.Control.Location = new Point(10, createsize);
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            try { flowLayoutPanel1.Controls[-1].Location = e.Control.Location; } catch (Exception ex) { APICore.Log(ex.Message); APICore.Log(ex.StackTrace); }

        }
        bool Downloading = false;
        
        private async void pictureBox6_Click(object sender, EventArgs e)
        {

            if (Downloading)
            {

               
            }
            else
            {
                Message(new UI.Message("Download Video Feature is temporary Removed due to high-non statble"));
                /*
                Downloading = true;
                var youtube = new YoutubeClient(APICore.HttpClient());
                string ProcessTitle = APICore.Title;
                foreach (var badName in Path.GetInvalidFileNameChars())
                {
                    ProcessTitle = ProcessTitle.Replace(badName.ToString(), " ");
                }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                
                saveFileDialog1.Filter = "Video files (*.mp4)|*.txt|All files (*.*)|*.*";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = ProcessTitle;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string TItle = APICore.Title;
                    try
                    {
                        Message(new UI.Message("Downloading " + TItle));
                        var streamManifest = await youtube.Videos.Streams.GetManifestAsync(
                            APICore.NOW_URL
                        );

                        // Select streams (1080p60 / highest bitrate audio)
                        var audioStreamInfo = streamManifest.GetAudioStreams().GetWithHighestBitrate();
                        var videoStreamInfo = streamManifest.GetVideoStreams().TryGetWithHighestBitrate();
                        var streamInfos = new IStreamInfo[] { audioStreamInfo, videoStreamInfo };

                        // Download and process them into one file
                        await youtube.Videos.DownloadAsync(streamInfos, new ConversionRequestBuilder(saveFileDialog1.FileName).Build());
                        Message(new UI.Message("Video have saved to " + saveFileDialog1.FileName));
                    }
                    catch { Message(new UI.Message("Cannot Download Video " + TItle)); }
                    Downloading = false;
                }
                Downloading = false;*/

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        public void Message(Control ctrl)
        {
            flowLayoutPanel2.Controls.Add(ctrl);
        }
        private async void flowLayoutPanel2_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Location = new Point(10, 10);
            flowLayoutPanel2.Visible = true;
            await Task.Delay(5000);
            flowLayoutPanel2.Controls.Remove(e.Control);
            flowLayoutPanel2.Visible = false;
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            if (APICore.FullScreen) { pictureBox8.Visible = true; }
          
            //panel4.Visible = true;
        }

        private async void pictureBox8_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            pictureBox8.Visible = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            APICore.FullScreen = false;
        }

        private void pictureBox8_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath g = new GraphicsPath();
            g.AddEllipse(0, 0, pictureBox8.Width, pictureBox8.Height);
            pictureBox8.Region = new System.Drawing.Region(g);

        }

        Pen pen = new Pen(Color.White, 2.0f);
        float penWidth = 2.0f;
        int _edge = 20;
        Color _borderColor = Color.White;
        public int Edge
        {
            get
            {
                return _edge;
            }
            set
            {
                _edge = value;
                Invalidate();
            }
        }

        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                pen = new Pen(_borderColor, penWidth);
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
      
            //DrawBorder(e.Graphics);
        }

        private void ExtendedDraw(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.StartFigure();
            path.AddArc(GetLeftUpper(Edge), 180, 90);
            path.AddLine(Edge, 0, Width - Edge, 0);
            path.AddArc(GetRightUpper(Edge), 270, 90);
            path.AddLine(Width, Edge, Width, Height - Edge);
            path.AddArc(GetRightLower(Edge), 0, 90);
            path.AddLine(Width - Edge, Height, Edge, Height);
            path.AddArc(GetLeftLower(Edge), 90, 90);
            path.AddLine(0, Height - Edge, 0, Edge);
            path.CloseFigure();

            Region = new Region(path);
        }

        Rectangle GetLeftUpper(int e)
        {
            return new Rectangle(0, 0, e, e);
        }
        Rectangle GetRightUpper(int e)
        {
            return new Rectangle(Width - e, 0, e, e);
        }
        Rectangle GetRightLower(int e)
        {
            return new Rectangle(Width - e, Height - e, e, e);
        }
        Rectangle GetLeftLower(int e)
        {
            return new Rectangle(0, Height - e, e, e);
        }

        void DrawSingleBorder(Graphics graphics)
        {
            graphics.DrawArc(pen, new Rectangle(0, 0, Edge, Edge), 180, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, -1, Edge, Edge), 270, 90);
            graphics.DrawArc(pen, new Rectangle(Width - Edge - 1, Height - Edge - 1, Edge, Edge), 0, 90);
            graphics.DrawArc(pen, new Rectangle(0, Height - Edge - 1, Edge, Edge), 90, 90);

            graphics.DrawRectangle(pen, 0.0F, 0.0F, Width - 1, Height - 1);
        }

        void DrawBorder(Graphics graphics)
        {
            DrawSingleBorder(graphics);
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            flowLayoutPanel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0,flowLayoutPanel2.Width,flowLayoutPanel2.Height, 20, 20));

        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
(
    int nLeftRect,     // x-coordinate of upper-left corner
    int nTopRect,      // y-coordinate of upper-left corner
    int nRightRect,    // x-coordinate of lower-right corner
    int nBottomRect,   // y-coordinate of lower-right corner
    int nWidthEllipse, // width of ellipse
    int nHeightEllipse // height of ellipse
);

        private void BGN_VIDEO_Resize(object sender, EventArgs e)
        {
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private async void panel4_VisibleChanged(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            //panel4.Visible = false;
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            pictureBox3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, flowLayoutPanel2.Width, flowLayoutPanel2.Height, 20, 20));
        }
    }
}
