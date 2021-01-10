using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using ProiectMedii.Data;

namespace ProiectMedii
{
    public partial class App : Application
    {
        static ToDoDatabase database;
        public static ToDoDatabase Database
        {
            get
            {
                if(database==null)
                {
                    database = new ToDoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDo.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToDoEntryPage());
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
