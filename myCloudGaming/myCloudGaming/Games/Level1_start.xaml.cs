using myCloudGaming.Classes;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Implementations;
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
	public partial class Level1_start : ContentPage
	{
        public int Num;
        int Score;
        int NumOfTries = 0;
        public int clicked;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[8];
        public double Totaltime;
        int LevelId = 1;
        public string theRightAnswer;
        string Email;
        int id;
        public Level1_start(string email, int stud, int num, int score, double totaltime)
        {
            Email = email;
            id = stud;
            Score = score;
            InitializeComponent();
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            Totaltime = totaltime;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            games[0] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/icecream.png",

            };
            games[2] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/colorpalette.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory.mp3"
            };
            games[4] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory.mp3"
            };
            games[6] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory.mp3"
            };

            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            pic4.Source = games[num].Pic4;

            MediaFile file = new MediaFile("https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/memory-visual.opus");
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            clickableLayout.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() => { Navigation.PushAsync(new Level1_1(email, id, Num, score, totaltime)); })
            });

            Question_label.GestureRecognizers.Add(
      new TapGestureRecognizer()
      {
          Command = new Command(() => {

              CrossMediaManager.Current.Play(file);
              CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
          })
      });
        }

        private async void Current_MediaFinished(object sender, Plugin.MediaManager.Abstractions.EventArguments.MediaFinishedEventArgs e)
        {
            await CrossMediaManager.Current.Stop();
        }

        public async void Start(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
                await Navigation.PushAsync(new Level1_1(Email, id, Num, Score, Totaltime));
            }
        }

        public async void Home(object snder, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            await Navigation.PushAsync(new MainGamesList(Email, id));
        }

        public async void Menu(object snder, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            await Navigation.PushAsync(new GameList(Email, id));
        }
    }
}