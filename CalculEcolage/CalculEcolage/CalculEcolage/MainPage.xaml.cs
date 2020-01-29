
using CalculEcolage.Database;
using CalculEcolage.Models;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using Plugin.ShareFile;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using UIKit;
using CalculEcolage.Algorithms;
using Foundation;
using Xamarin.Essentials;
using System;
using UIKit;
using Foundation;
using XAMLtoPDF;

namespace CalculEcolage
{

    public partial class MainPage : ContentPage
    {

        ToastIOS toast = new ToastIOS();
        public UIBarButtonItem shareButton;


        Color backgroundColour = Color.DeepSkyBlue;
        Color textColor = Color.White;
        double fontSize = 30;
        Thickness margin = new Thickness();
        Thickness padding = new Thickness();
        //Layout
        LayoutOptions horizontalOptions = LayoutOptions.Center;
        LayoutOptions verticalOptions = LayoutOptions.Center;
        //Padding
        int verticalPadding = 10;
        int horizontalPadding = 15;
        //Height
        int Width = 400;
        int Height = 100;



        public MainPage()
        {
            InitializeComponent();
            padding.Left = horizontalPadding;
            padding.Right = horizontalPadding;
            padding.Top = verticalPadding;
            padding.Bottom = verticalPadding;
            margin.Bottom = 60;
            //set buttons properties
            SetParametersButton.BackgroundColor = backgroundColour;
            SetParametersButton.TextColor = textColor;
            SetParametersButton.FontSize = fontSize;
            SetParametersButton.Margin = margin;
            SetParametersButton.HorizontalOptions = horizontalOptions;
            SetParametersButton.VerticalOptions = verticalOptions;
            SetParametersButton.HeightRequest = Height;
            SetParametersButton.WidthRequest = Width;
            SetParametersButton.Padding = padding;

            FamilyButton.BackgroundColor = backgroundColour;
            FamilyButton.TextColor = textColor;
            FamilyButton.FontSize = fontSize;
            FamilyButton.Margin = margin;
            FamilyButton.HorizontalOptions = horizontalOptions;
            FamilyButton.VerticalOptions = verticalOptions;
            FamilyButton.HeightRequest = Height;
            FamilyButton.WidthRequest = Width;
            FamilyButton.Padding = padding;

        }
        protected override async void OnAppearing()
        {
            //override back button
            if (OnBackButtonPressed())
            {
                await Navigation.PushAsync(new MainPage
                {
                    BindingContext = new MainPage()
                });
            }

            base.OnAppearing();
            try
            {
                InitializeDatabase ini = new InitializeDatabase();
                //use script to fill database if previous database has been deleted
                List<TuitionFees> tuitionFees = await App.Database.GetTuittionFeesListAsync();
                if (tuitionFees.Count() == 0)
                {
                    ini.populateDatabase();
                }
            }
            catch (Exception)
            {
                Console.WriteLine(">>> The database can't be read try to import a database in .db3 format (SQLite)");
            }


        }

        async private void GoToSetParameters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrUpdate
            {
                BindingContext = new AddOrUpdate()
            });
        }

        async private void GoToFamilyList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FamilyList
            {
                BindingContext = new FamilyList()
            });
        }

        async private void ImportDB(object sender, EventArgs e)
        {
            FileData file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                string filePath = file.FilePath;
                string format = filePath.Substring(filePath.Length - 3);
                try
                {
                    if (format.Equals("db3"))
                    {
                        var bytes = File.ReadAllBytes(filePath);
                        File.WriteAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fees20.db3"), bytes); //Replace the current database with the new database
                    }
                    else
                    {
                        Console.WriteLine(">>> Database format has to be '.db3' (SQLite)");
                        DisplayAlert("Error", "You can't import a database which isn't in .db3 format (SQLite)", "OK");
                    }
                }
                catch (Exception) { }

            }


        }

        async private void ExportDB(object sender, EventArgs e)
        {
            //select the database file
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Fees20.db3");
            
            //get memory stream
            MemoryStream stream = new MemoryStream();
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                stream.SetLength(fileStream.Length);
                fileStream.Read(stream.GetBuffer(), 0, (int)fileStream.Length);
            }

            //save file
            DependencyService.Get<ISave>().Save("Fees20.db3", "", stream);
        }
    }
}
