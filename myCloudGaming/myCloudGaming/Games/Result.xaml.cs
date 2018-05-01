using myCloudGamingReference;
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
	public partial class Result : ContentPage
	{
        string Email, levelid;
        int id, time, scr;
        public Result(string email, int stud, int Score, double totaltime, string lvlid)
        {
            levelid = lvlid;
            Email = email;
            id = stud;
            time = Convert.ToInt32(totaltime);
            DateTime m = new DateTime();
            m = DateTime.Now.ToLocalTime();
            InitializeComponent();
            scr = Score;

            NavigationPage.SetHasNavigationBar(this, false);
            switch (Score)
            {
                case 0: score.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/score0.png"; break;
                case 1: score.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/score1.png"; break;
                case 2: score.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/score2.png"; break;
                case 3: score.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/score3.png"; break;
                case 4: score.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/score4.png"; break;
            }

            SaveGameInfo();
        }

        private async void SaveGameInfo()
        {
            Service1Client client = new Service1Client();
            try
            {
                bool check = await client.SaveGameStateAsync(id, levelid, scr, time, Email);

                if (check)
                    return;
            }
            catch (Exception ex)
            {
                await DisplayAlert("exception", ex.Message, "ok");
            }
        }

        public async void Home(object snder, EventArgs e)
        {
            await Navigation.PushAsync(new MainGamesList(Email, id));
        }
        public async void Menu(object snder, EventArgs e)
        {

            await Navigation.PushAsync(new GameList(Email, id));
        }
    }
}