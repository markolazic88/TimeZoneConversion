using Xamarin.Forms;

namespace TimeZoneConversion
{
    public partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();

            MainPage = new TimeZoneConversion.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
