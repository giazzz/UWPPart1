using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
    public sealed partial class Upload : Page
    {
        private const string ApiUrl = "https://2-dot-backup-server-003.appspot.com/_api/v2/songs/post-free";
        public Upload()
        {
            this.InitializeComponent();
        }
        public Boolean validate(string name, string thumbnail, string link)
        {
            if (name == "")
            {
                this.name_er.Text = "Name is not valid!";
                return false;
            };
            if (name.Length > 50)
            {
                this.name_er.Text = "Max length 50!";
                return false;
            };
            if (thumbnail == "")
            {
                this.thumbnail_er.Text = "Thumbnail is not valid!";
                return false;
            };
            if (link == "")
            {
                this.link_er.Text = "Link is not valid!";
                return false;
            };
            if (link.Length <= 4)
            {
                this.link_er.Text = "End link must is .mp3!";
                return false;
            } else if (link.Substring(link.Length - 4) != ".mp3")
            {
                this.link_er.Text = "End link must is .mp3!";
                return false;
            };
            

            return true;
        }
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (validate(this.name.Text, this.thumbnail.Text, this.link.Text))
            {
                var uploadSong = new Song
                {
                    name = this.name.Text,
                    description = this.description.Text,
                    singer = this.singer.Text,
                    author = this.author.Text,
                    thumbnail = this.thumbnail.Text,
                    link = this.link.Text
                };

                var httpClient = new HttpClient();
                //httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + token);
                HttpContent content = new StringContent(JsonConvert.SerializeObject(uploadSong), Encoding.UTF8,
                    "application/json");

                Task<HttpResponseMessage> httpRequestMessage = httpClient.PostAsync(ApiUrl, content);
                String responseContent = httpRequestMessage.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Response: " + responseContent);

                Song resSong = JsonConvert.DeserializeObject<Song>(responseContent);
                Debug.WriteLine("Singer: " + resSong.singer);
            }
            


        }
    }
}