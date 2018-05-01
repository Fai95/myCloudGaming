using myCloudGaming.Classes;
using myCloudGamingReference;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myCloudGaming.admin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentsLists : ContentPage
	{
        string confirmSelection, unconfirmSelection, email;
        Service1Client client = new Service1Client();

        public StudentsLists(string em)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            InternetConnection connection = new InternetConnection();
            if (!connection.ConnectivityCheck())
            {
                DisplayAlert("Cloud Gaming Application", "الرجاء التحقق من الاتصال بشبكة الإنترنت", "موافق");
            }
            else
            {
                email = em;
                GetConfirmed();
                GetUnConfirmed();

                instructions.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                    {
                        DisplayAlert("تعليمات", "من قائمة 'تفعيل الحساب' اختر الطالب لتفعيل حسابه حتى يتمكن من استخدام التطبيق" + '\n' + "من قائمة 'إلغاء التفعيل' اختر الطالب لإلغاء تأكيد حسابه", "موافق");
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
            return client.GetStudentsAsync(email, "مشرف", false);
        }

        private async void GetUnConfirmed()
        {
            Unconfirmed.ItemsSource = await FillUnConfirmed();
        }

        private Task<string[]> FillUnConfirmed()
        {
            return client.GetStudentsAsync(email, "مشرف", true);
        }

        private void Unconfirmed_OnSelectedIndexChanged(object sender, EventArgs e) =>
            unconfirmSelection = Unconfirmed.SelectedItem.ToString();

        private void Confirmed_OnSelectedIndexChanged(object sender, EventArgs e) =>
           confirmSelection = Confirmed.SelectedItem.ToString();

        private async void Confirm_OnClicked(object sender, EventArgs e)
           => await Navigation.PushAsync(new ConfirmStudent(email, confirmSelection));

        private async void Unconfirm_OnClicked(object sender, EventArgs e)
         => await Navigation.PushAsync(new admin.UnConfStudentInfo(email, unconfirmSelection));

        private async void Return_OnClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new admin.ManageAccounts());
    }
}