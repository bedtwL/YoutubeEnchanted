using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            var youtube = new YoutubeClient();
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
    }
}
