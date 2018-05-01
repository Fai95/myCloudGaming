using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace myCloudGaming
{
	public partial class Roles : ContentPage
	{
        string role;
		public Roles()
		{
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
		}

        private async void Parent_OnClick(object sender, EventArgs e)
        {
            role = "ولي أمر";
            await Navigation.PushAsync(new XML_S.MainPage(role));
        }

        private async void Specialist_OnClick(object sender, EventArgs e)
        {
            role = "أخصائي";
            await Navigation.PushAsync(new XML_S.MainPage(role));
        }

        private async void Admin_OnClick(object sender, EventArgs e)
        {
            role = "مشرف";
            await Navigation.PushAsync(new XML_S.MainPage(role));
        }
    }
}
