using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SeattleParks.Views;
using SeattleParks.Data;
using System.IO;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SeattleParks
{
    public partial class App : Application
    {
        static FavoriteStore database;

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static FavoriteStore Database
        {
            get
            {
                if(database == null)
                {
                    database = new FavoriteStore(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Parks.db3"));
                    Console.WriteLine("Creating new database");
                }
                else
                {
                    Console.WriteLine("Loading existing database");
                }
                return database;
            }
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
