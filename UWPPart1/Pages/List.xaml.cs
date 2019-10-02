﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWPPart1.Entity;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWPPart1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class List : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/get-free-songs";
        private ObservableCollection<Song> ListSong { get; set; }
        public List()
        {
            this.InitializeComponent();
            this.ListSong = new ObservableCollection<Song>();
            var httpClient = new HttpClient();
            Task<HttpResponseMessage> httpRequestMessage = httpClient.GetAsync(ApiUrl);
            String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
            List<Song> listSong = JsonConvert.DeserializeObject<List<Song>>(responseContent);
            foreach (Song item in listSong)
            {
                this.ListSong.Add(new Song()
                {
                    name = item.name,
                    singer = item.singer,
                    thumbnail = item.thumbnail,
                    link = item.link
                });
            }
        }
    }
}
