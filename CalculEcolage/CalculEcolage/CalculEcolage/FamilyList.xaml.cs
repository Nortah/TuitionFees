using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculEcolage.Models;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace CalculEcolage
{
    public partial class FamilyList : ContentPage
    {
        string nullErrorMessage = "You must write a name";
        string usedErrorMessage = "This name already exists";
        public FamilyList()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                List<Family> families = await App.Database.GetFamilyListAsync();
                families = families.OrderBy(i => i.familyName).ToList();
                
                //save family cost
                foreach (Family f in families)
                {
                    f.totalCost = 0;
                    List<Child> children = await App.Database.GetChildListByFamilyAsync(f.id);
                    foreach (Child c in children)
                    {
                        f.totalCost = f.totalCost + c.cost;
                    }
                    await App.Database.SaveFamilyAsync(f);
                }
                //Display families
                listView.ItemsSource = families;
            }
            catch(System.Exception)
            { }
            
   
        }
        async void OnPlusClicked(object sender, EventArgs e)
        {
            familyNameEntry.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence | KeyboardFlags.Spellcheck);
            familyNameBlock.IsVisible = true;
        }
        async void OnAddClicked(object sender, EventArgs e)
        {
            List<Family> families = await App.Database.GetFamilyListAsync();
            
            nullErrorLabel.IsVisible = false;
            try
            {
                //check if name already exists
                foreach (Family f in families)
                {
                    if (f.familyName == familyNameEntry.Text)
                    {
                        usedNameErrorLabel.IsVisible = true;
                        usedNameErrorLabel.Text = usedErrorMessage;
                        return;
                    }
                }
                
                var family = new Family();

                family.familyName = familyNameEntry.Text.Trim();

                if (string.IsNullOrWhiteSpace(family.familyName))
                {
                    nullErrorLabel.IsVisible = true;
                    nullErrorLabel.Text = nullErrorMessage;
                }
                else
                {
                    await App.Database.SaveFamilyAsync(family);
                    await Navigation.PushAsync(new FamilyList());
                }
                
            }
            catch (Exception)
            {
                nullErrorLabel.IsVisible = true;
                nullErrorLabel.Text = nullErrorMessage;
            }
        }

            async void OnFamilySelected(object sender, SelectedItemChangedEventArgs e)
        {
           if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ChildList
                {
                    BindingContext = e.SelectedItem as Family
                });
            }
        }
        async void OnBackClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
        
    }
}