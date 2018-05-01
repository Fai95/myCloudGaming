using myCloudGaming.Classes;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Implementations;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.Games
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Level1 : ContentPage
    {
        int Num, Score, NumOfTries = 0, clicked, LevelId = 7, id;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[4];
        public double Totaltime;
        public string theRightAnswer, Email;
        string sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/chooseAshape.mp3";
        MediaFile file;

        public Level1(string email, int stud, int num, int score, double totaltime)
        {
            Email = email;
            id = stud;
            Score = score;
            InitializeComponent();
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            Totaltime = totaltime;
            NavigationPage.SetHasNavigationBar(this, false);

            games[0] = new Game()
            {
                Pic0 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mouth.png",
            };
            games[1] = new Game()
            {
                Pic0 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png",
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mouth.png",
            };
            games[2] = new Game()
            {
                Pic0 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/policeman.png",
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mouth.png",

            };
            games[3] = new Game()
            {
                Pic0 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/tp.png",
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mouth.png",

            };

            // https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Blue+face.png
            pic0.Source = games[num].Pic0;
            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            pic4.Source = games[num].Pic4;
            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mouth.png";
                    break;
            }

            file = new MediaFile(sound);
            CrossMediaManager.Current.Play(file);
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

        }
        public async void Choose2(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            {
                if (clicked == 1)
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
        public async void Choose3(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            clicked++;
            if (clicked == 1)
            {
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
                //clicked++;
            }
        }
        public async void Choose4(object sender, EventArgs e)
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
            clicked++;
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
                calculate_time();
                NumOfTries = 0;
                await Navigation.PushAsync(new TheRightAnswer(Email, id, Num + 1, Score, Totaltime, LevelId, theRightAnswer));
            }
            else
            { TryAgain(); }
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
            //player2.Stop();
            await Navigation.PushAsync(new GameList(Email, id));
        }
        public async void Home(object snder, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            //player2.Stop();
            await Navigation.PushAsync(new MainGamesList(Email, id));
        }
    }
}