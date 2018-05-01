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
	public partial class TheRightAnswer : ContentPage
	{
        int Num;
        int Score;
        int LevelId;
        double TotalTime;
        public int clicked;
        string Email;
        int id;

        public TheRightAnswer(string email, int stud, int num, int score, double totaltime, int levelId, String theRightpic)
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

            RightAnswer.Source = theRightpic;
        }

        public async void next_level(object sender, EventArgs e)
        {
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
    }
}