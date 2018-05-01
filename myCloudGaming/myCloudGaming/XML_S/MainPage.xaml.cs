using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.XML_S
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
        string role;
        public MainPage(string r)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            role = r;
        }


        private async void LoginBtn_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new XML_S.Login(role));
        }

        private async void RegstBtn_OnClicked(object sender, EventArgs e)
        {
            if (role == "ولي أمر")
                await Navigation.PushAsync(new parent.ParentRegister(role));
            else if (role == "أخصائي")
                await Navigation.PushAsync(new specialist.SpecialistRegister(role));
            else
                await Navigation.PushAsync(new admin.CofirmationCode(role));
        }

        private async void InfoBtn_OnClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new XML_S.About(role));
        }

        private async void Return_OnClicked(object sender, EventArgs e) =>
            await Navigation.PushAsync(new Roles());
    }
}