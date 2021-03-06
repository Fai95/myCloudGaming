﻿using myCloudGaming.Classes;
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
	public partial class Level4 : ContentPage
	{
        public int Num;
        MediaFile file;
        int Score;
        int NumOfTries = 0;
        public int clicked;
        public DateTime Starttime = new DateTime();
        public int LevelId = 4;
        Game[] games = new Game[4];
        public double Totaltime;
        string theRightAnswer;
        string Email;
        int id;
        public Level4(string email, int stud, int num, int score, double totaltime)
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

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square2.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square2.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/polygon.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square2.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/discrimination0.mp3"
            };
            games[1] = new Game()
            {
                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/circle.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square.png",
                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/discrimination0.mp3"
            };
            games[2] = new Game()
            {

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/polygon.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/polygon.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/polygon.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square2.png",

                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/discrimination0.mp3"

            };
            games[3] = new Game()
            {

                Pic1 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square.png",
                Pic2 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/circle.png",
                Pic3 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/circle.png",
                Pic4 = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/circle.png",

                sound = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/discrimination0.mp3"
            };

            // https://s3.ap-south-1.amazonaws.com/cloudgamingapp/Blue+face.png

            pic1.Source = games[num].Pic1;
            pic2.Source = games[num].Pic2;
            pic3.Source = games[num].Pic3;
            pic4.Source = games[num].Pic4;

            switch (Num)
            {
                case 0:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/polygon.png";
                    break;
                case 1:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/circle.png";
                    break;
                case 2:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square2.png";
                    break;
                case 3:
                    theRightAnswer = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/visual+/Square.png";
                    break;
            }


            file = new MediaFile(games[0].sound);
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

            file = new MediaFile(tryAgain);
            await CrossMediaManager.Current.Play(file);
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