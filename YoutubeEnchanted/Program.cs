using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using YoutubeEnchanted.API;
using YoutubeEnchanted.UI;
using static System.Windows.Forms.LinkLabel;

namespace YoutubeEnchanted
{
    internal class Program
    {
        public static bool error = false;
        public static string LogPath=AppDomain.CurrentDomain.BaseDirectory+"Logs\\"+DateTime.Now.ToString().Replace(":"," ").Replace("/","0")+".log";
        public static UserControl errorForm;
        public static BGN_VIDEO Mainwindow;
        static void Main()
        {

            //APICore.Play(Console.ReadLine());
            System.IO.File.WriteAllText(LogPath, "[" + DateTime.Now.ToString() + "] Log Started");

            System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory+"Logs\\");
            API.APICore.Log("Youtube Enchanted "+ Application.ProductVersion.Substring(0, 5));
            RunWindow();
            
         
        }
        public static void OpenLog()
        {
            System.Diagnostics.Process.Start("explorer",LogPath);
        }

        static void RunWindow()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             Mainwindow =  new UI.BGN_VIDEO();
            APICore.Log("Created Client Window");
            Mainwindow.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            Mainwindow.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Mainwindow.ClientSize = new System.Drawing.Size(800, 450);
            Mainwindow.Name = "YoutubeEnchanted v" + Application.ProductVersion.Substring(0, 5);
            Mainwindow.Text = "YoutubeEnchanted v" + Application.ProductVersion.Substring(0, 5);
            //Mainwindow.Controls.Add(new UI.StillWorkingOnProject() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom, Size = Mainwindow.Size });
            //Mainwindow.Controls.Add(new VlcControl() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom, Size = Mainwindow.Size,VlcLibDirectory=new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory+"VLCLIBx64")});

            //Mainwindow.Controls.Add(new UI.MainPage() { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom, Size = Mainwindow.Size });

            Application.Run(Mainwindow);
            APICore.Log("Quit Client Window");
            
        }
    }
}
