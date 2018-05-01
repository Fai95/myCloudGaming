using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.Games
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameList : ContentPage
	{
        string Email;

        int id, Clicked;
        public GameList(string email, int student)
        {
            Email = email;
            id = student;

            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            Recognetion.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Recognation.png";
            Recognize.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Recognizing.png";
            Direction.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Direction.png";
            Attention.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Attention.png";
            Closing.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/closing.png";
            Touch.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Touch.png";
            Memory.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/memorizing.png";
        }

        private async void S(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
               await Navigation.PushAsync(new Level1(Email, id, 0, 0, 0));
            }
        }
        private async void Lev11(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new Level11(Email, id, 0, 0, 0));
            }
        }
        private async void Lev1_2(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new VisionOrHearnig(Email, id, 0, 0, 0, 1));
            }
        }
        private async void Lev3_4(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new VisionOrHearnig(Email, id, 0, 0, 0, 3));
            }
        }
        private async void Lev5(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new Level5(Email, id, 0, 0, 0));
            }

        }
        private async void Lev6_7(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;

                await Navigation.PushAsync(new VisionOrHearnig(Email, id, 0, 0, 0, 6));
            }
        }
        private async void Lev8_9(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new VisionOrHearnig(Email, id, 0, 0, 0, 8));
            }
        }
        private async void Lev10(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new Level10UpandDown(Email, id, 0, 0, 0));
            }
        }
        public async void HomeTap(object snder, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;

                await Navigation.PushAsync(new MainGamesList(Email, id));
            }
        }

        public async void Menu(object snder, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;

                await Navigation.PushAsync(new MainGamesList(Email, id));
            }
        }
    }
}