
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CalculEcolage.Database;
using CalculEcolage.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CalculEcolage
{
    public partial class App : Application
    {
        static TuitionFeesDatabase database;


        public static TuitionFeesDatabase Database
        {
            get
            {

                if (database == null)
                {
                    Console.Write("Log: " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\n");
                    database = new TuitionFeesDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fees20.db3"));
                    Console.Write("Log" + database);
                }
                return database;
                
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
          
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
