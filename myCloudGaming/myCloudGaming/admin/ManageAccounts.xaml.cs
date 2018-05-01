using myCloudGaming.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManageAccounts : ContentPage
	{
        string email;
        public ManageAccounts()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                Connectivity.Text = "الرجاء التحقق من الاتصال بشبكة الإنترنت";
                Connectivity.IsVisible = true;
            }

        }

        public ManageAccounts(string uname)
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
                email = uname;
            }
        }

        private async void Parents_OnClicked(object sender, EventArgs e)
           => await Navigation.PushAsync(new StudentsLists(email));

        private async void SpeciaLists_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new SpeciaLists(email));

        private async void Logout_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new Roles());
    }
}