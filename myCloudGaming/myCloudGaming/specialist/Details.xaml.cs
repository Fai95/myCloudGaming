using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.specialist
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Details : ContentPage
	{
        int id;
        string email, level;
        Service1Client client = new Service1Client();
        ObservableCollection<string> det = new ObservableCollection<string>();
        public Details(string mail, int stud, string lvl)
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
                email = mail;
                id = stud;
                level = lvl;

                GetInfoList();

            }
        }
        private async void GetInfoList()
        {
            try
            {
                if (FillInfoList() != null)
                {
                    foreach (var i in await FillInfoList())
                        det.Add(i.ToString());

                    if (det.Contains("True"))
                    {
                        stateImg.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/pass.png";
                    }
                    else
                    {
                        stateImg.Source = "https://s3.amazonaws.com/cloudgamingmulitmediabucket/fail.png";
                    }

                    student_name.Text = det[0] + " " + det[1];
                    level_name.Text = det[2];
                    score.Text = det[3];
                    time.Text = det[4];

                }

                else
                    await DisplayAlert("Cloud Gaming Application", "لا يوجد بيانات لعرضها", "موافق");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Cloud Gaming Application", "لا يوجد بيانات لعرضها", "موافق");
            }
        }

        private Task<string[]> FillInfoList()
        {
            try
            {
                return client.GetStudentInfoListAsync(id, email, level);
            }
            catch (Exception ex)
            {
                DisplayAlert("exception", ex.Message, "OK");
                return null;
            }
        }

        private async void Contact_OnClick(object sender, EventArgs e)
            => await Navigation.PushAsync(new ParentContact(email, id));

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new specialist.StudentResults(email, id));
    }
}