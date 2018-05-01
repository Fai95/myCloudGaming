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
	public partial class VisionOrHearnig : ContentPage
	{
        int Num;
        int Score;
        int LevelId;
        double TotalTime;
        public int clicked;
        string Email;
        int id;
        public VisionOrHearnig(string email, int stud, int num, int score, double totaltime, int levelId)
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
            switch (LevelId)
            {
                case 1: gameName.Text = "لعبة الذاكرة"; break;
                case 3: gameName.Text = "لعبة التمييز"; break;
                case 6: gameName.Text = "لعبة الإدراك"; break;
                case 8: gameName.Text = "لعبة الإغلاق"; break;
            }
        }
        public async void Menu(object snder, EventArgs e)
        {
            await Navigation.PushAsync(new GameList(Email, id));
        }
        private async void Hearing(object sender, EventArgs e)
        {
            if (clicked == 0)
            {
                // clicked++;
                switch (LevelId)
                {
                    case 1: await Navigation.PushAsync(new Level2_start(Email, id, 0, 0, 0)); break;
                    case 3: await Navigation.PushAsync(new Level3(Email, id, 0, 0, 0)); break;
                    case 6: await Navigation.PushAsync(new Level6(Email, id, 0, 0, 0)); break;
                    case 8: await Navigation.PushAsync(new Level8(Email, id, 0, 0, 0)); break;
                }
            }
        }
        public async void Home(object snder, EventArgs e)
        {
            await Navigation.PushAsync(new GameList(Email, id));
        }

        private async void Visual(object sender, EventArgs e)
        {
            if (clicked == 0)
            {
                // clicked++;
                switch (LevelId)
                {
                    case 1: await Navigation.PushAsync(new Level1_start(Email, id, 0, 0, 0)); break;
                    case 3: await Navigation.PushAsync(new Level4(Email, id, 0, 0, 0)); break;
                    case 6: await Navigation.PushAsync(new Level1(Email, id, 0, 0, 0)); break;
                    case 8: await Navigation.PushAsync(new Level9(Email, id, 0, 0, 0)); break;
                }
            }
        }
    }
}