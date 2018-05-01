using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.XML_S
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class About : ContentPage
	{
        string role;
        public About(string r)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            role = r;
            about_Label.Text = "'Cloud Gaming Application' \n";
        }

        private async void Return_OnClicked(object sender, EventArgs e) =>
           await Navigation.PushAsync(new XML_S.MainPage(role));
    }
}