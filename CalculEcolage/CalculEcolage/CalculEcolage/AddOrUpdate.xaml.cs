using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculEcolage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrUpdate : ContentPage
    {
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
        new int Width = 400;
        new int Height = 100;

        public AddOrUpdate()
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

        async private void GoToSetParameters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SetParameters
            {
                BindingContext = new SetParameters()
            });
        }

        async private void GoToUpdateParameters(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UpdateParameters
            {
                BindingContext = new UpdateParameters()
            });
        }

        //on back clicked
        async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}
