using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using System.Net.Http;
using System.Data.Common;

namespace YoutubeEnchanted.API
{
    public class APICore
    {
        public static string NOW_URL;
        public static string _PARSE_URL;
        public static bool PARSED_URL;
        public static string Topic;
        public static string VideoDes;
        public static string Title;
        public static List<string> UPDATED_LIST = new List<string>();
        public static int VideoINDEX = 0;
        public static bool CloseFirstW=false;
        public static bool FullScreen = false;
        //public static VlcControl videoPlayCore = new VlcControl() { Dock = DockStyle.Fill, VlcLibDirectory = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "VLCLIBx64") };
        public static bool ShowPlayControlMenu = false;
        //public static void ResetCore()
        //{
        //videoPlayCore.Dispose();
        //videoPlayCore=new VlcControl() { Dock = DockStyle.Fill, VlcLibDirectory = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "VLCLIBx64") };
        //}
        public static bool ToggleBool(bool Toggle)
        {
            if (Toggle)
            { Toggle = false; }
            else { Toggle = true; }
            return Toggle;
        }
        public static HttpClient HttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseCookies= true;
            handler.CookieContainer=new System.Net.CookieContainer();
            return new System.Net.Http.HttpClient(handler);
        }
        public static void UpdateURL()
        {
            try { NOW_URL = UPDATED_LIST[VideoINDEX]; } catch { }
        }
        public static void UpdateURL(string url)
        {
            NOW_URL = url;
        }
        public static void AddUrl(string url)
        {
            UPDATED_LIST.Add(url);
        }
        public static void RemoveUrl(string url)
        {
            UPDATED_LIST.Remove(url);
        }
        public static void ClearUrl()
        {
            UPDATED_LIST.Clear();
        }
        public static async void Play(string url,string Topic)
        {
            PARSED_URL = false;
            string PARSE_URL = url;
            string Titlee = "";
            NOW_URL= url;
            string VideoDess = "";
            try
            {

                var youtube = new YoutubeExplode.YoutubeClient(APICore.HttpClient());
                var video = await youtube.Videos.GetAsync(url);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestBitrate();
                PARSE_URL = streamInfo.Url;
                Titlee = video.Title;
                VideoDes = video.Description;
                _PARSE_URL = PARSE_URL;
            }
            catch (YoutubeExplode.Exceptions.RequestLimitExceededException ex)
            {
                API.APICore.Log(ex.Message);
                API.APICore.Log(ex.StackTrace);
                Program.errorForm = new ErrorUI.Common.YoutubeLimted();
                Program.error = true;
              

            }
            catch (Exception ex) { API.APICore.Log("Not Youtube Url. "+ex.Message); API.APICore.Log(ex.Message);
                API.APICore.Log(ex.StackTrace);
            }
            _PARSE_URL = PARSE_URL;
            Title = Titlee; 
            VideoDes=VideoDess;
            PARSED_URL = true;


            ShowPlayControlMenu = true;
              
                API.APICore.Log("Parsed URL.");
             
            
            
        }
        public static string runtimelog = "";
        public static void Log(string lines)
        {
            runtimelog = runtimelog + "\n[" + DateTime.Now.ToString() + "] " + lines;
            try { System.IO.File.WriteAllText(Program.LogPath, runtimelog); } catch{/* Log(ex.Message);Log(ex.StackTrace);*/ }
           
        }
        public static async void ParseUrl(string url)
        {
            PARSED_URL = false;
            string PARSE_URL = url;
            try
            {

                var youtube = new YoutubeExplode.YoutubeClient(APICore.HttpClient());
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(url);
                try {var streamInfo = streamManifest.GetMuxedStreams().TryGetWithHighestVideoQuality(); PARSE_URL = streamInfo.Url; } catch(Exception ex) {
                    API.APICore.Log(ex.Message);
                    API.APICore.Log(ex.StackTrace); Program.Mainwindow.Message(new UI.Message("Cannot play youtube Video due to "+ex.Message));  return; }
           

            }
            catch (YoutubeExplode.Exceptions.RequestLimitExceededException ex)
            {
                API.APICore.Log(ex.Message);
                API.APICore.Log(ex.StackTrace);
                Program.errorForm = new ErrorUI.Common.YoutubeLimted();
                Program.error = true;
        
            }
            catch(Exception ex) { API.APICore.Log("Not Youtube Url."); API.APICore.Log(ex.Message);
                API.APICore.Log(ex.StackTrace);
            }
            _PARSE_URL = PARSE_URL;
       
            PARSED_URL = true;
            //API.APICore.Log(PARSE_URL);

        }
        public static bool TryGetRegisteredApplication(
                  string extension, out string registeredApp)
        {
            string extensionId = GetClassesRootKeyDefaultValue(extension);
            if (extensionId == null)
            {
                registeredApp = null;
                return false;
            }

            string openCommand = GetClassesRootKeyDefaultValue(
                    Path.Combine(new[] { extensionId, "shell", "open", "command" }));

            if (openCommand == null)
            {
                registeredApp = null;
                return false;
            }

            registeredApp = openCommand
                             .Replace("%1", string.Empty)
                             .Replace("\"", string.Empty)
                             .Trim();
            return true;
        }

        private static string GetClassesRootKeyDefaultValue(string keyPath)
        {
            using (var key = Registry.ClassesRoot.OpenSubKey(keyPath))
            {
                if (key == null)
                {
                    return null;
                }

                var defaultValue = key.GetValue(null);
                if (defaultValue == null)
                {
                    return null;
                }

                return defaultValue.ToString();
            }
        }
        public static string ToFriendllyTime(long num)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(num);
            string answer = "Unknow";
            if (t.Hours == 0)
            {

                answer = string.Format("{0:D2}:{1:D2}",

                                   t.Minutes,
                                   t.Seconds);
            }
            else
            {
                answer = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds);
            }

            return answer;
        }
        [Flags]
        public enum ThumbnailOptions
        {
            None = 0x00,
            BiggerSizeOk = 0x01,
            InMemoryOnly = 0x02,
            IconOnly = 0x04,
            ThumbnailOnly = 0x08,
            InCacheOnly = 0x10,
        }

        public class WindowsThumbnailProvider
        {
            private const string IShellItem2Guid = "7E9FB0D3-919F-4307-AB2E-9B1860310C93";

            [DllImport("shell32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int SHCreateItemFromParsingName(
                [MarshalAs(UnmanagedType.LPWStr)] string path,
                // The following parameter is not used - binding context.
                IntPtr pbc,
                ref Guid riid,
                [MarshalAs(UnmanagedType.Interface)] out IShellItem shellItem);

            [DllImport("gdi32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            internal static extern bool DeleteObject(IntPtr hObject);

            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
            internal interface IShellItem
            {
                void BindToHandler(IntPtr pbc,
                    [MarshalAs(UnmanagedType.LPStruct)] Guid bhid,
                    [MarshalAs(UnmanagedType.LPStruct)] Guid riid,
                    out IntPtr ppv);

                void GetParent(out IShellItem ppsi);
                void GetDisplayName(SIGDN sigdnName, out IntPtr ppszName);
                void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
                void Compare(IShellItem psi, uint hint, out int piOrder);
            };

            internal enum SIGDN : uint
            {
                NORMALDISPLAY = 0,
                PARENTRELATIVEPARSING = 0x80018001,
                PARENTRELATIVEFORADDRESSBAR = 0x8001c001,
                DESKTOPABSOLUTEPARSING = 0x80028000,
                PARENTRELATIVEEDITING = 0x80031001,
                DESKTOPABSOLUTEEDITING = 0x8004c000,
                FILESYSPATH = 0x80058000,
                URL = 0x80068000
            }

            internal enum HResult
            {
                Ok = 0x0000,
                False = 0x0001,
                InvalidArguments = unchecked((int)0x80070057),
                OutOfMemory = unchecked((int)0x8007000E),
                NoInterface = unchecked((int)0x80004002),
                Fail = unchecked((int)0x80004005),
                ElementNotFound = unchecked((int)0x80070490),
                TypeElementNotFound = unchecked((int)0x8002802B),
                NoObject = unchecked((int)0x800401E5),
                Win32ErrorCanceled = 1223,
                Canceled = unchecked((int)0x800704C7),
                ResourceInUse = unchecked((int)0x800700AA),
                AccessDenied = unchecked((int)0x80030005)
            }

            [ComImportAttribute()]
            [GuidAttribute("bcc18b79-ba16-442f-80c4-8a59c30c463b")]
            [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
            internal interface IShellItemImageFactory
            {
                [PreserveSig]
                HResult GetImage(
                [In, MarshalAs(UnmanagedType.Struct)] NativeSize size,
                [In] ThumbnailOptions flags,
                [Out] out IntPtr phbm);
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct NativeSize
            {
                private int width;
                private int height;

                public int Width { set { width = value; } }
                public int Height { set { height = value; } }
            };

            [StructLayout(LayoutKind.Sequential)]
            public struct RGBQUAD
            {
                public byte rgbBlue;
                public byte rgbGreen;
                public byte rgbRed;
                public byte rgbReserved;
            }

            public static Bitmap GetThumbnail(string fileName, int width, int height, ThumbnailOptions options)
            {
                IntPtr hBitmap = GetHBitmap(Path.GetFullPath(fileName), width, height, options);

                try
                {
                    // return a System.Drawing.Bitmap from the hBitmap
                    return GetBitmapFromHBitmap(hBitmap);
                }
                finally
                {
                    // delete HBitmap to avoid memory leaks
                    DeleteObject(hBitmap);
                }
            }

            public static Bitmap GetBitmapFromHBitmap(IntPtr nativeHBitmap)
            {
                Bitmap bmp = Bitmap.FromHbitmap(nativeHBitmap);

                if (Bitmap.GetPixelFormatSize(bmp.PixelFormat) < 32)
                    return bmp;

                return CreateAlphaBitmap(bmp, PixelFormat.Format32bppArgb);
            }

            public static Bitmap CreateAlphaBitmap(Bitmap srcBitmap, PixelFormat targetPixelFormat)
            {
                Bitmap result = new Bitmap(srcBitmap.Width, srcBitmap.Height, targetPixelFormat);

                Rectangle bmpBounds = new Rectangle(0, 0, srcBitmap.Width, srcBitmap.Height);

                BitmapData srcData = srcBitmap.LockBits(bmpBounds, ImageLockMode.ReadOnly, srcBitmap.PixelFormat);

                bool isAlplaBitmap = false;

                try
                {
                    for (int y = 0; y <= srcData.Height - 1; y++)
                    {
                        for (int x = 0; x <= srcData.Width - 1; x++)
                        {
                            Color pixelColor = Color.FromArgb(
                                Marshal.ReadInt32(srcData.Scan0, (srcData.Stride * y) + (4 * x)));

                            if (pixelColor.A > 0 & pixelColor.A < 255)
                            {
                                isAlplaBitmap = true;
                            }

                            result.SetPixel(x, y, pixelColor);
                        }
                    }
                }
                finally
                {
                    srcBitmap.UnlockBits(srcData);
                }

                if (isAlplaBitmap)
                {
                    return result;
                }
                else
                {
                    return srcBitmap;
                }
            }

            private static IntPtr GetHBitmap(string fileName, int width, int height, ThumbnailOptions options)
            {
                IShellItem nativeShellItem;
                Guid shellItem2Guid = new Guid(IShellItem2Guid);
                int retCode = SHCreateItemFromParsingName(fileName, IntPtr.Zero, ref shellItem2Guid, out nativeShellItem);

                if (retCode != 0)
                    throw Marshal.GetExceptionForHR(retCode);

                NativeSize nativeSize = new NativeSize();
                nativeSize.Width = width;
                nativeSize.Height = height;

                IntPtr hBitmap;
                HResult hr = ((IShellItemImageFactory)nativeShellItem).GetImage(nativeSize, options, out hBitmap);

                Marshal.ReleaseComObject(nativeShellItem);

                if (hr == HResult.Ok) return hBitmap;

                throw Marshal.GetExceptionForHR((int)hr);
            }
        }
    }
}
