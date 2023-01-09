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
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Search;

namespace YoutubeEnchanted.UI
{
    public partial class TopicVideoSelecter : UserControl
    {
        
        public TopicVideoSelecter(string topid)
        {
            InitializeComponent();
            label1.Text= topid;
            API.APICore.Log("Serching "+topid);
            UpdateVideo(topid,topid);
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TopicVideoSelecter_Load(object sender, EventArgs e)
        {
         
        }
        private async void UpdateVideo(string id,string top)
        {
            var youtube = new YoutubeExplode.YoutubeClient(new System.Net.Http.HttpClient());
            foreach (var result in await youtube.Search.GetVideosAsync(id).CollectAsync(20) )
            {
                if (flowLayoutPanel1.Controls.Count == 20)
                {  }
                else { flowLayoutPanel1.Controls.Add(new UI.VideoControl(result.Url,top)); }
               
                


            }
        }
        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        int createsize=10;
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            createsize = e.Control.Size.Width + createsize;
            e.Control.Location = new Point(createsize, 10);
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {

            try { flowLayoutPanel1.Controls[-1].Location = e.Control.Location; } catch (Exception ex) { APICore.Log(ex.Message); APICore.Log(ex.StackTrace); }
        }
    }
}
