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
    public partial class MainGamesList : ContentPage
    {
        String Email;
        int id;
        int Clicked;

        public MainGamesList(string em, int stud)
        {
            InitializeComponent();
            Clicked = 0;
            Email = em;
            id = stud;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            letsplay.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/LetsPlay2.png";
            letslearn.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/letsLearn2.png";
        }

        public async void LetsPlay(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new GameList(Email, id));
            }
        }
        public async void LetsLearn(object sender, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;
                await Navigation.PushAsync(new Videos.VideoList(Email, id));
            }
        }

        public async void HomeTap(object snder, EventArgs e)
        {
            if (Clicked == 0)
            {
                Clicked++;

                await Navigation.PushAsync(new parent.ParentPage(Email));
            }
        }
    }
}