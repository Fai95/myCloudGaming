using Android.Media;
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
	public partial class GoodJob : ContentPage
	{
        int Num, Score, LevelId, id, clicked;
        double TotalTime;
        string Email, excellent;

        public GoodJob(string email, int stud, int num, int score, double totaltime, int levelId)
        {
            Email = email;
            id = stud;
            clicked = 0;
            LevelId = levelId;
            TotalTime = totaltime;
            Score = score;
            Num = num;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            String[] pics = new String[4];
            pics[0] = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/azoz.png";
            pics[1] = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/abood.png";
            pics[2] = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/zozo.png";
            pics[3] = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/soso.png";

            Random pic = new Random();
            GoodJobPic.Source = pics[pic.Next(0, 3)];

            excellent = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/audio/excellent.mp3";

            MediaFile file = new MediaFile(excellent);
            CrossMediaManager.Current.Play(file);
            CrossMediaManager.Current.MediaFinished += Current_MediaFinished;

            GoodJobPic.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    TapRecognition();
                })
            });
        }

        private async void TapRecognition()
        {
            await CrossMediaManager.Current.Stop();
            if (clicked == 0)
            {
                clicked++;
                switch (LevelId)
                {
                    case 1: //الذاكرة البصرية 
                        if (Num < 8)
                        {
                            if (Num == 2 || Num == 4 || Num == 6)
                            {
                                await Navigation.PushAsync(new Level1_start(Email, id, Num, Score, TotalTime));
                            }
                            else
                            {
                                await Navigation.PushAsync(new Level1_1(Email, id, Num, Score, TotalTime));
                            }

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score / 2, TotalTime, "الذاكرة البصرية"));
                        }
                        break;

                    case 2: //الذاكرة السمعية 
                        if (Num < 8)
                        {
                            await Navigation.PushAsync(new Level2_start(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score / 2, TotalTime, "الذاكرة السمعية"));
                        }
                        break;

                    case 3: // التمييز السمعي
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level3(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التمييز السمعي"));
                        }
                        break;

                    case 4: // التمييز البصري
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level4(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التمييز البصري"));
                        }
                        break;

                    case 5:  // الانتباه
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level5(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإنتباه"));
                        }
                        break;

                    case 6: //الادراك السمعي
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level6(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإدراك السمعي"));
                        }
                        break;

                    case 7:  //الادراك البصري
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level1(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإدراك البصري"));
                        }
                        break;

                    case 8: //الاغلاق السمعي
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level8(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإغلاق السمعي"));
                        }
                        break;

                    case 9: //الاغلاق البصري 
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level9(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإغلاق البصري"));
                        }
                        break;

                    case 10:  //الاتجاهات
                        if (Num < 4)
                        {
                            if (Num == 2)
                            {
                               await Navigation.PushAsync(new Level10UpandDown(Email, id, Num, Score, TotalTime));
                            }
                            else
                            {
                                await Navigation.PushAsync(new Level10(Email, id, Num, Score, TotalTime));
                            }

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإتجاهات"));
                        }
                        break;

                    case 11:  //التعرف باللمس 
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level11(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التعرف باللمس"));
                        }
                        break;
                }
            }
        }
        private async void Current_MediaFinished(object sender, Plugin.MediaManager.Abstractions.EventArguments.MediaFinishedEventArgs e)
        {
            await CrossMediaManager.Current.Stop();
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


        public async void next_level(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
            if (clicked == 0)
            {
                clicked++;
                switch (LevelId)
                {
                    case 1: //الذاكرة البصرية 
                        if (Num < 8)
                        {
                            if (Num == 2 || Num == 4 || Num == 6)
                            {
                                await Navigation.PushAsync(new Level1_start(Email, id, Num, Score, TotalTime));
                            }
                            else
                            {
                                await Navigation.PushAsync(new Level1_1(Email, id, Num, Score, TotalTime));
                            }

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score / 2, TotalTime, "الذاكرة البصرية"));
                        }
                        break;

                    case 2: //الذاكرة السمعية 
                        if (Num < 8)
                        {
                            await Navigation.PushAsync(new Level2_start(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score / 2, TotalTime, "الذاكرة السمعية"));
                        }
                        break;

                    case 3: // التمييز السمعي
                        if (Num < 4)
                        {
                          //  await Navigation.PushAsync(new Level3(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التمييز السمعي"));
                        }
                        break;

                    case 4: // التمييز البصري
                        if (Num < 4)
                        {
                           // await Navigation.PushAsync(new Level4(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التمييز البصري"));
                        }
                        break;

                    case 5:  // الانتباه
                        if (Num < 4)
                        {
                           // await Navigation.PushAsync(new Level5(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإنتباه"));
                        }
                        break;

                    case 6: //الادراك السمعي
                        if (Num < 4)
                        {
                          //  await Navigation.PushAsync(new Level6(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإدراك السمعي"));
                        }
                        break;

                    case 7:  //الادراك البصري
                        if (Num < 4)
                        {
                           // await Navigation.PushAsync(new Level1(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإدراك البصري"));
                        }
                        break;

                    case 8: //الاغلاق السمعي
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level8(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإغلاق السمعي"));
                        }
                        break;

                    case 9: //الاغلاق البصري 
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level9(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإغلاق البصري"));
                        }
                        break;

                    case 10:  //الاتجاهات
                        if (Num < 4)
                        {
                            if (Num == 2)
                            {
                                await Navigation.PushAsync(new Level10UpandDown(Email, id, Num, Score, TotalTime));
                            }
                            else
                            {
                                await Navigation.PushAsync(new Level10(Email, id, Num, Score, TotalTime));
                            }

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "الإتجاهات"));
                        }
                        break;

                    case 11:  //التعرف باللمس 
                        if (Num < 4)
                        {
                            await Navigation.PushAsync(new Level11(Email, id, Num, Score, TotalTime));

                        }
                        else
                        {
                            await Navigation.PushAsync(new Result(Email, id, Score, TotalTime, "التعرف باللمس"));
                        }
                        break;
                }
            }

        }
    }
}