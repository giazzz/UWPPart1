using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWPPart1.Entity;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPart1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListSong : Page
    {
        
        private string GET_SONG = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        public ListSong()
        {
            this.InitializeComponent();
            HttpClient client = new HttpClient();
            var list = client.GetAsync(GET_SONG).Result.Content.ReadAsStringAsync().Result;
            JArray zzz = JArray.Parse(list);
            Debug.WriteLine(zzz);
            ObservableCollection<Song> obs = new ObservableCollection<Song>();
            this.ListSong.Add(new Song()
            {
                foreach ()
                {

                }
            };
            //ObservableCollection<Song> ListSong { get => listSong; set => listSong = Value};
            //this.ListSong = new ObservableCollection<Song>();
            //this.ListSong.Add(new Song()
            //{
            //    foreach ()
            //{

            //};
        });




        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
