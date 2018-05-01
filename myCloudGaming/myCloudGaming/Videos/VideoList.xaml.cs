using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.Videos
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoList : ContentPage
	{
        string email;
        int id;
        public VideoList(string em, int stud)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Fat_ha.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/A.png";
            Kasra.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/E.png";
            Dammah.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/O.png";

            email = em;
            id = stud;
        }

        private void Fat_haTap(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://s3.amazonaws.com/cloudgamingmulitmediabucket/Fat%2Bha.MP4"));
        }

        private void KasraTap(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://s3.amazonaws.com/cloudgamingmulitmediabucket/kasra.MP4"));
        }

        private void DammahTap(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://s3.amazonaws.com/cloudgamingmulitmediabucket/Dammah.MP4"));
        }

        private async void Return_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Games.MainGamesList(email, id));
        }

        public async void HomeTap(object snder, EventArgs e)
        {
            await Navigation.PushAsync(new Games.MainGamesList(email, id));
        }
    }
}