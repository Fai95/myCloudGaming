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
	public partial class Level10 : ContentPage
	{
        public int Num;
        MediaFile file;
        int Score, id, NumOfTries = 0, clicked, LevelId = 10;
        public DateTime Starttime = new DateTime();
        Game[] games = new Game[4];
        public double Totaltime;
        string Email;

        public Level10(string email, int stud, int num, int score, double totaltime)
        {
            Score = score;
            Email = email;
            id = stud;
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            Totaltime = totaltime;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            games[1] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/left.mp3",
                Text = "اخترالوجه الأيسر"
            };
            games[3] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Blue+face.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/right.mp3",
                Text = "اخترالوجه الأيمن"
            };
            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            question.Text = games[num].Text;


            file = new MediaFile(games[num].sound);
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            question.GestureRecognizers.Add(
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

        public async void Choose1(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
                if (Num == 1)
                {
                    calculate_time();
                    RightAnswer(sender, e);
                }
                else
                {
                    WrongAnswer(sender, e);
                    clicked = 0;
                }
            }
        }
        public async void Choose2(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            {
                if (clicked == 1)
                    if (Num == 5)
                    {
                        calculate_time();
                        RightAnswer(sender, e);
                    }
                    else
                    {
                        WrongAnswer(sender, e);
                        clicked = 0;
                    }

            }
        }
        public async void Choose3(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
                if (Num == 3)
                {
                    calculate_time();
                    RightAnswer(sender, e);
                }
                else
                {
                    WrongAnswer(sender, e);
                    clicked = 0;
                }
            }
        }

        public void TryAgain()
        {
            CrossMediaManager.Current.Stop();

            string tryAgain = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/tryAgain.mp3";

            file = new MediaFile(tryAgain);
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
        }
        public void calculate_time()
        {
            DateTime endTime = new DateTime();
            endTime = DateTime.Now.ToLocalTime();
            games[Num].Time = (endTime - Starttime).TotalSeconds;
            Totaltime = Totaltime + games[Num].Time;


        }
        public async void WrongAnswer(object sender, EventArgs e)
        {

            NumOfTries++;
            if (NumOfTries > 2)
            {
                NumOfTries = 0;
                await Navigation.PushAsync(new Level10UpandDown(Email, id, Num + 1, Score, Totaltime));
            }
            else
            {
                TryAgain();

            }
        }
        public async void RightAnswer(object sender, EventArgs e)
        {
            {
                if (NumOfTries == 0) { Score++; }
                NumOfTries = 0;

                await Navigation.PushAsync(new GoodJob(Email, id, Num + 1, Score, Totaltime, LevelId));
            }
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