using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace App1
{
    public partial class App : Application
    {
        public static ObservableCollection<Plantule> Plantules { get; set; } = new ObservableCollection<Plantule>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}



