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
    public partial class MainPage : UserControl
    {
       
        public MainPage()
        {
            InitializeComponent();
       
        }
        int createtmp = 0;
        
        private void MainPage_Load(object sender, EventArgs e)
        {

            AddTopic("Top");
            AddTopic("Music");
            AddTopic("Gaming");
            AddTopic("News");
            foreach (var topic in System.IO.File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory+ "Topic.db"))
            {
                AddTopic(topic);
            }
            Tick();
        }
        private async void Tick()
        {
            do { 
                try 
                {

                    if (APICore.ShowPlayControlMenu)
                    { this.Hide(); }
                    else { this.Show(); }
                    await Task.Delay(500); 
                } catch { await Task.Delay(3000); } } while (true);
          
        }
        private void AddTopic(string topic)
        {
            TopicShower.Controls.Add(new TopicVideoSelecter(topic) { Location = new Point(0, createtmp), Anchor = AnchorStyles.Right|AnchorStyles.Left|AnchorStyles.Top, Size = new Size(TopicShower.Width, 321) });
            createtmp = createtmp + 321;
        }

        private void MainPage_EnabledChanged(object sender, EventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
