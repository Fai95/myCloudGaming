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
	public partial class Level6 : ContentPage
	{
        MediaFile file, file3, file4;
        int Score, NumOfTries = 0, clicked, Num, LevelId = 6, id;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[4];
        public double Totaltime;
        string theRightAnswer, Email;

        public Level6(string email, int stud, int num, int score, double totaltime)
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
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid3.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid2.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",

                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/gal.mp3",
                sound3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/kal.mp3",

            };
            games[1] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid3.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid2.png",

                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/hamal.mp3",
                sound3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/camel.mp3"
            };
            games[2] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid3.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid2.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/alam.mp3",
                sound3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/pencil.mp3"
            };
            games[3] = new Game()
            {
                Pic0 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid2.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid3.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/closingStart.mp3",
                sound2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/gam.mp3",
                sound3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/sam.mp3"
            };


            pic0.Source = games[num].Pic0;
            pic1.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Speaker.png";
            pic2.Source = games[num].Pic2;
            pic3.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Speaker.png";
            pic4.Source = games[num].Pic4;
            pic5.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Speaker.png";



            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid3.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid2.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/kid1.png";
                    break;
            }
            //player.SetDataSource(games[num].sound);
            //player.SetAudioStreamType(Android.Media.Stream.Music);
            //player.Prepare();
            //player.Start();



            file = new MediaFile("https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus");
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;


            file3 = new MediaFile(games[num].sound2);
            CrossMediaManager.Current.Play(file3);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            file4 = new MediaFile(games[num].sound3);
            CrossMediaManager.Current.Play(file4);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            Question_label.GestureRecognizers.Add(
             new TapGestureRecognizer()
             {
                 Command = new Command(() => {

                     CrossMediaManager.Current.Play("https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/last+virsion/recognation-hearing.opus");
                     CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                 })
             });

        }

        private async void Current_MediaFinished(object sender, MediaFinishedEventArgs e)
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
                    if (Num == 0 || Num == 3)
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
            if (NumOfTries > 1)
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

                await Navigation.PushAsync(new
                    GoodJob(Email, id, Num + 1, Score, Totaltime, LevelId));
            }
        }

        public void PlaySound(object sender, EventArgs e)
        {
            CrossMediaManager.Current.Play(file3);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
        }
        public void PlaySound1(object sender, EventArgs e)
        {
            CrossMediaManager.Current.Stop();
            switch (Num)
            {
                case 0:
                    {
                        CrossMediaManager.Current.Play(file4);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 1:
                    {
                        CrossMediaManager.Current.Play(file4);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 2:
                    {
                        CrossMediaManager.Current.Play(file3);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 3:
                    {
                        CrossMediaManager.Current.Play(file4);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
            }

        }
        public void PlaySound2(object sender, EventArgs e)
        {
            CrossMediaManager.Current.Stop();
            switch (Num)
            {
                case 0:
                    {
                        CrossMediaManager.Current.Play(file3);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 1:
                    {
                        CrossMediaManager.Current.Play(file3);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 2:
                    {
                        CrossMediaManager.Current.Play(file4);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
                case 3:
                    {
                        CrossMediaManager.Current.Play(file3);
                        CrossMediaManager.Current.MediaFinished += Current_MediaFinished;
                    }; break;
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