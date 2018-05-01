using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.specialist
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentResults : ContentPage
	{
        List<LevelsList> lvlist;

        List<string> list = new List<string>();
        Service1Client client = new Service1Client();

        string email, student;
        int id;

        public StudentResults(string em, string stud)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }
            else
            {
                student = stud;

                email = em;
                studName.Text = "اسم الطالب: " + " " + student;


                lvlist = new List<LevelsList>{
                    new LevelsList {Name= "الإتجاهات",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/transfer+-+no-label.png" },
                    new LevelsList {Name="الإدراك البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/ok-mark-+no-label.png" },
                    new LevelsList {Name="الإدراك السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/ok-mark-+no-label.png" },
                    new LevelsList {Name="الإغلاق البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/puzzle+-++no-label.png" },
                    new LevelsList {Name="الإغلاق السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/puzzle+-++no-label.png" },
                    new LevelsList {Name="الإنتباه",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/light-bulb+(1)+-+no-label.png" },
                    new LevelsList {Name="التعرف باللمس",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/tap+(2)-++no-label.png" },
                    new LevelsList {Name="التمييز البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/icon+(1)+-+no-label.png" },
                    new LevelsList {Name="التمييز السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/icon+(1)+-+no-label.png" },
                    new LevelsList {Name="الذاكرة البصرية",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/brain+(1)+-+no-label.png" },
                     new LevelsList {Name="الذاكرة السمعية",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/brain+(1)+-+no-label.png" }
                };
                StudentsListView.ItemsSource = lvlist;

                string idStrng = Regex.Replace(student, "[^0-9]+", string.Empty);
                id = Int32.Parse(idStrng);

            }
        }

        public StudentResults(string em, int stud)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                DisplayAlert("Cloud Gaming Application", Connectivity.Text, "موافق");
            }
            else
            {
                id = stud;

                email = em;
                studName.Text = "اسم الطالب: " + " " + student;


                lvlist = new List<LevelsList>{
                    new LevelsList {Name= "الإتجاهات",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/transfer+-+no-label.png" },
                    new LevelsList {Name="الإدراك البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/ok-mark-+no-label.png" },
                    new LevelsList {Name="الإدراك السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/ok-mark-+no-label.png" },
                    new LevelsList {Name="الإغلاق البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/puzzle+-++no-label.png" },
                    new LevelsList {Name="الإغلاق السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/puzzle+-++no-label.png" },
                    new LevelsList {Name="الإنتباه",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/light-bulb+(1)+-+no-label.png" },
                    new LevelsList {Name="التعرف باللمس",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/tap+(2)-++no-label.png" },
                    new LevelsList {Name="التمييز البصري",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/icon+(1)+-+no-label.png" },
                    new LevelsList {Name="التمييز السمعي",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/icon+(1)+-+no-label.png" },
                    new LevelsList {Name="الذاكرة البصرية",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/brain+(1)+-+no-label.png" },
                     new LevelsList {Name="الذاكرة السمعية",
                    Img="https://s3.amazonaws.com/cloudgamingmulitmediabucket/Main+Game+page/brain+(1)+-+no-label.png" }
                };
                StudentsListView.ItemsSource = lvlist;

            }
        }

        private async void Selected(object sender, ItemTappedEventArgs e)
        {
            var level = e.Item as LevelsList;
            await Navigation.PushAsync(new specialist.Details(email, id, level.Name));
        }

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new specialist.ChooseStudent(email));
    }
}