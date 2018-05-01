using myCloudGaming.Classes;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Implementations;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.Games
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Level2 : ContentPage
	{
        MediaFile file;

        public int Num, Score, id, NumOfTries = 0, clicked, LevelId = 2;
        public DateTime Starttime = new DateTime();
        Game[] games = new Game[8];
        public double Totaltime;
        string theRightAnswer, Email;

        public Level2(string email, int stud, int num, int score, double totaltime)
        {
            Email = email;
            id = stud;
            Totaltime = totaltime;
            Score = score;
            InitializeComponent();
            Num = num;
            clicked = 0;
            Starttime = DateTime.Now.ToLocalTime();
            NavigationPage.SetHasNavigationBar(this, false);
            games[0] = new Game()
            {

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/1.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/2.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/3.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/4.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/Questions/lastnum.mp3",
                Text = "بعد سماعك للصوت اختر الرقم الأخير اللذي سمعته"
                //2
            };
            games[1] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/bear.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/bird.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/lion.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/rabbit.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/three.mp3"
                ,
                Text = "بعد سماعك للصوت ماهو الصوت الثالث اللذي سمعته"//lion
            };
            games[2] = new Game()
            {

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/5.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/6.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/7.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/8.png",

                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/Questions/secondnum.mp3" //5
                 ,
                Text = "بعد سماعك للصوت ماهو الرقم الثاني اللذي سمعته"
            };
            games[3] = new Game()
            {

                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/car.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/pen.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/plane.png",
                Text = "بعد سماعك للصوت ماهو الصوت الأول اللذي سمعته",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/one.mp3" //book
            };

            games[4] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/7.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/8.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/9.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/10.png",
                Text = "بعد سماعك للصوت ماهو الرقم الثالث اللذي سمعته",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/Questions/thirednum.mp3" //9
            };
            games[5] = new Game()
            {
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/tree.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/bed.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/ball.png",
                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/house.png",
                Text = "بعد سماعك للصوت ماهو الصوت الأخير اللذي سمعته",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/last.mp3" //bed
            };
            games[6] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/5.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/9.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/7.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/6.png",
                Text = "بعد سماعك للصوت ماهو الرقم الأول اللذي سمعته",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/Questions/firstnum.mp3" //9
            };
            games[7] = new Game()
            {

                Pic4 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/train.png",
                Pic2 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/cake.png",
                Pic3 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/mosque.png",
                Pic1 = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/sweet.png",
                Text = "بعد سماعك للصوت ماهو الصوت الثاني اللذي سمعته",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/Memory/two.mp3" //train
            };

            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            pic4.Source = games[num].Pic4;

            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/2.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/lion.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/5.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/book.png";
                    break;
                case 4:
                    theRightAnswer = " https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/9.png";
                    break;
                case 5:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/bed.png";
                    break;
                case 6:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/memory/9.png";
                    break;
                case 7:
                    theRightAnswer = "https://s3.ap-south-1.amazonaws.com/cloudgamingapp/train.png";
                    break;

            }
            question.Text = games[num].Text;

            file = new MediaFile(games[Num].sound);
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
                    if (Num == 0 || Num == 6)
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
                if (Num == 1 || Num == 4 || Num == 5)
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