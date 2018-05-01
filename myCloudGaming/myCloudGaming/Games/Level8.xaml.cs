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
	public partial class Level8 : ContentPage
	{
        MediaFile file, file2, file3;

        int Score, Num, NumOfTries = 0, clicked, LevelId = 8, id;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[4];
        public double Totaltime;
        string theRightAnswer, Email;


        public Level8(string email, int stud, int num, int score, double totaltime)
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
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/trees.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/tLetter.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/rLetter.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/zLetter.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/ba.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closing-tree.mp3"
            };
            games[1] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Sun.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/tLetter.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/rLetter.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/sLetter.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/ba.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closing+-+4.mp3"
            };
            games[2] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Clothes.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/tLetter.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/rLetter.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/zLetter.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/ba.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closing-2.mp3"

            };
            games[3] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/salt.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/hLetter.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/rLetter.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/zLetter.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/ba.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closing-salt.mp3"
            };
            //https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3
            // https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Blue+face.png
            pic0.Source = games[num].Pic0;
            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            pic4.Source = games[num].Pic4;
            soundIcon.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Speaker.png";


            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/rLetter.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/sLetter.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/ba.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/hLetter.png";
                    break;
            }

            file = new MediaFile(games[Num].sound);
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            file3 = new MediaFile(games[Num].sound2);
            CrossMediaManager.Current.Play(file3);
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
        public async void Choose2(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();

            clicked++;
            {
                if (clicked == 1)
                    if (Num == 0)
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
                //clicked++;
            }
        }
        public async void Choose4(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
                if (Num == 2)
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
            // clicked++;
        }
        public async void TryAgain()
        {
            await CrossMediaManager.Current.Stop();

            string tryAgain = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/tryAgain.mp3";

            file2 = new MediaFile(tryAgain);
            await CrossMediaManager.Current.Play(file2);
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

        public void PlaySound(object sender, EventArgs e)
        {
            CrossMediaManager.Current.Stop();
            CrossMediaManager.Current.Play(file3);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
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