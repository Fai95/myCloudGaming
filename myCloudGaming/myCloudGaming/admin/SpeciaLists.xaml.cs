using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpeciaLists : ContentPage
	{
        string selectoin, email;
        Service1Client client = new Service1Client();

        public SpeciaLists(string e)
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
                GetConfirmed();
                GetUnConfirmed();

                instructions.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                    {
                        DisplayAlert("تعليمات", "من قائمة 'تفعيل الحساب' اختر الأخصائي لتفعيل حسابه حتى يتمكن من استخدام التطبيق" + '\n' + "من قائمة 'إلغاء التفعيل' اختر الأخصائي لإلغاء تأكيد حسابه", "موافق");
                    })
                });
            }
        }

        private async void GetConfirmed()
        {
            Confirmed.ItemsSource = await FillConfirmed();
        }

        private Task<string[]> FillConfirmed()
        {
            return client.AdminSpecialistsAsync(email, false);
        }

        private async void GetUnConfirmed()
        {
            Unconfirmed.ItemsSource = await FillUnConfirmed();
        }

        private Task<string[]> FillUnConfirmed()
        {
            return client.AdminSpecialistsAsync(email, true);
        }

        private void Unconfirmed_OnSelectedIndexChanged(object sender, EventArgs e)
            => selectoin = Unconfirmed.SelectedItem.ToString();

        private async void Unconfirm_OnClicked(object sender, EventArgs e)
        {
            if (selectoin == null)
                unConfirm_label.TextColor = Color.Red;
            else
                await Navigation.PushAsync(new admin.UnConfSpecialist(selectoin, email));
        }

        private void Confirmed_OnSelectedIndexChanged(object sender, EventArgs e)
            => selectoin = Confirmed.SelectedItem.ToString();

        private async void Confirm_OnClicked(object sender, EventArgs e)
        {
            if (selectoin == null)
                confirm_label.TextColor = Color.Red;
            else
                await Navigation.PushAsync(new admin.ConfirmSpecialist(selectoin, email));
        }

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new admin.ManageAccounts(email));

        private void Instructions_OnClicked(object sender, EventArgs e)
                      => DisplayAlert("تعليمات", "من قائمة 'تفعيل الحساب' اختر الأخصائي لتفعيل حسابه حتى يتمكن من استخدام التطبيق" + '\n' + "من قائمة 'إلغاء التفعيل' اختر الأخصائي لإلغاء تأكيد حسابه", "موافق");

    }
}