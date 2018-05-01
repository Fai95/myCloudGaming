using Android.Media;
using myCloudGaming.Classes;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.EventArguments;
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
	public partial class Level2_start : ContentPage
	{
        MediaFile file, file2, file3;
        int Score, clicked, LevelId = 2, id, Num;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[8];
        public double Totaltime;
        string Email;

        public Level2_start(string email, int stud, int num, int score, double totaltime)
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
            games[0] = new Game() { sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/1+3+4+2.mp3" };
            games[1] = new Game() { sound = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Bear%2C+bird%2C+lion%2C+rabbit.mp3" };
            games[2] = new Game() { sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/7+5+6+8.mp3" };
            games[3] = new Game() { sound = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Book+car+pilot+pen.mp3" };
            games[4] = new Game() { sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/8+7+9+10.mp3" };
            games[5] = new Game() { sound = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Tree+House+Ball+Bed.mp3" };
            games[6] = new Game() { sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/9+5+6+7.mp3" };
            games[7] = new Game() { sound = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Sweet+Train+cake+Mosque.mp3" };

            file = new MediaFile("https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/question.mp3");
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            file2 = new MediaFile(games[Num].sound);
            CrossMediaManager.Current.Play(file2);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            Question_label.GestureRecognizers.Add(
            new TapGestureRecognizer()
            {
                Command = new Command(() => {

                    CrossMediaManager.Current.Play(file);
                    CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                })
            });
        }

        private async void Current_MediaFinished(object sender, MediaFinishedEventArgs e)
        {
            await CrossMediaManager.Current.Stop();
        }

        public async void Play()
        {
            await CrossMediaManager.Current.Stop();
            file3 = new MediaFile(games[Num].sound);
            await CrossMediaManager.Current.Play(file3);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
        }

        public async void Start(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            await Navigation.PushAsync(new Level2(Email, id, Num, Score, Totaltime));
        }
        public async void Menu(object snder, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            await Navigation.PushAsync(new GameList(Email, id));
        }

        public async void Home(object snder, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            await Navigation.PushAsync(new MainGamesList(Email, id));
        }
    }
}