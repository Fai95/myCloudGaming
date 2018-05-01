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
	public partial class Level3 : ContentPage
	{
        MediaFile file, file2;
        int Score, id, NumOfTries = 0, clicked, LevelId = 3, Num;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[4];
        public double Totaltime;
        string theRightAnswer, Email;

        public Level3(string email, int stud, int num, int score, double totaltime)
        {
            Email = email;
            id = stud;
            Score = score;
            InitializeComponent();
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            NavigationPage.SetHasNavigationBar(this, false);
            Totaltime = totaltime;
            games[0] = new Game()
            {

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/saeed.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/baeed.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/happy.mp3"
            };
            games[1] = new Game()
            {

                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/bsl.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/wsl.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/bsl.mp3"
            };
            games[2] = new Game()
            {

                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/thLetter.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/sLetter.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/s.mp3"
            };
            games[3] = new Game()
            {
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/hLetter.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/HHLette.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/h.mp3"
            };

            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;

            soundIcon.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Speaker.png";

            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/saeed.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/bsl.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/sLetter.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/hLetter.png";
                    break;
            }

            file = new MediaFile(games[Num].sound);
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            file2 = new MediaFile(games[Num].sound2);
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
        public async void Choose1(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
                if (Num == 0 || Num == 2)
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
                    if (Num == 1 || Num == 3)
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

        public async void TryAgain()
        {
            await CrossMediaManager.Current.Stop();

            string tryAgain = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/tryAgain.mp3";

            file = new MediaFile(tryAgain);
            await CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
        }

        private async void Current_MediaFinished(object sender, MediaFinishedEventArgs e)
        {
            await CrossMediaManager.Current.Stop();
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
                calculate_time();
                NumOfTries = 0;
                await Navigation.PushAsync(new TheRightAnswer(Email, id, Num + 1, Score, Totaltime, LevelId, theRightAnswer));
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
        public async void PlaySound(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();

            file2 = new MediaFile(games[Num].sound2);
            await CrossMediaManager.Current.Play(file2);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
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