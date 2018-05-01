using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.specialist
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChooseStudent : ContentPage
	{
        string email, student;

        Service1Client client = new Service1Client();

        public ChooseStudent(string e)
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
                email = e;
                GetStudents();
            }
        }

        private async void GetStudents()
        {
            studentsPicker.ItemsSource = await FillStudents();
        }

        private Task<string[]> FillStudents()
        {
            return client.GetSpecialistsStudentsAsync(email);
        }

        private void StudentsPicker_OnSelectedItem(object sender, EventArgs e)
            => student = studentsPicker.SelectedItem.ToString();

        private async void Select_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new specialist.StudentResults(email, student));

        private async void Logout_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new Roles());
    }
}