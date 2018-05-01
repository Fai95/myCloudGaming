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
	public partial class Level1_1 : ContentPage
	{
        int Num, Score, id, NumOfTries = 0, clicked, LevelId = 1;
        public static DateTime Starttime = new DateTime();
        Game[] games = new Game[8];
        public double Totaltime;
        string theRightAnswer, Email;
        MediaFile file;
        int i = 0;
        public Level1_1(string email, int stud, int num, int score, double totaltime)
        {
            Email = email;
            id = stud;
            Score = score;
            Totaltime = totaltime;
            InitializeComponent();
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            NavigationPage.SetHasNavigationBar(this, false);
            games[0] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png", //fire
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/icecream.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Thiredpic.mp3",
                Text = "اختر الصورة الثالثة اللتي شاهدتها"
            };
            games[1] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",       //icecream    
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/icecream.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/lastpic.mp3",
                Text = "اختر الصورة الاخيرة اللتي شاهدتها"
            };
            games[2] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png", //cheesecake
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/colorpalette.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",

                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Secondpic.mp3",
                Text = "اختر الصورة الثانية اللتي شاهدتها"
            };
            games[3] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png", //colorpalette
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/colorpalette.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/firstpic.mp3",
                Text = "اختر الصورة الاولى اللتي شاهدتها"
            };

            games[4] = new Game()
            {
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Thiredpic.mp3",
                Text = "اختر الصورة الثالثة اللتي شاهدتها"
            };
            games[5] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/juice.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/lastpic.mp3",
                Text = "اختر الصورة الاخيرة اللتي شاهدتها"
            };
            games[6] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Secondpic.mp3",
                Text = "اختر الصورة الثانية اللتي شاهدتها"
            };
            games[7] = new Game()
            {
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/police+car.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png",
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fireman.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/firstpic.mp3",
                Text = "اختر الصورة الاولى اللتي شاهدتها"
            };

            question.Text = games[num].Text;
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
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/icecream.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/colorpalette.png";
                    break;
                case 4:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/cheeseCake.png";
                    break;
                case 5:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png";
                    break;
                case 6:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/fire.png";
                    break;
                case 7:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Cake.png";
                    break;
            }

            MediaFile file = new MediaFile(games[num].sound);
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
                if (Num == 0 || Num == 4)
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
                    if (Num == 2 || Num == 6)
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
                if (Num == 3 || Num == 7)
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
                if (Num == 1 || Num == 5)
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