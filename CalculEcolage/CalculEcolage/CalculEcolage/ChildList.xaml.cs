using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculEcolage.Models;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using ListView = Xamarin.Forms.ListView;

namespace CalculEcolage
{
    public partial class ChildList : ContentPage
    {
        string nullErrorMessage = "You must write a name";
        string usedErrorMessage = "This name already exists";
        public ChildList()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            //set family name
            Family family = (Family)BindingContext;
            familyName.Text = family.familyName;
            familyName.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence | KeyboardFlags.Spellcheck);

            bool backButtonPressed = OnBackButtonPressed();
            //override back button
            if (backButtonPressed)
            {
                await Navigation.PushAsync(new FamilyList
                {
                    BindingContext = new FamilyList()
                });
            }

            
            base.OnAppearing();

            List<Child> children = await App.Database.GetChildListByFamilyAsync(family.id);
            children = children.OrderBy(i => i.childName).ToList();
            //Display children
            listView.ItemsSource = children;
        }
        async void OnPlusClicked(object sender, EventArgs e)
        {
            childNameEntry.Keyboard = Keyboard.Create(KeyboardFlags.CapitalizeSentence | KeyboardFlags.Spellcheck);
            childNameBlock.IsVisible = true;
        }
        async void OnChildAdded(object sender, EventArgs e)
        {
            var family = (Family)BindingContext;
            family.familyName = familyName.Text;
            List<Child> children = await App.Database.GetChildListByFamilyAsync(family.id);
            nullErrorLabel.IsVisible = false;
            try
            {
                //check if name already exists
                foreach (Child c in children)
                {
                    if (c.childName == childNameEntry.Text)
                    {
                        usedNameErrorLabel.IsVisible = true;
                        usedNameErrorLabel.Text = usedErrorMessage;
                        return;
                    }
                }


                var child = new Child();

                child.childName = childNameEntry.Text.Trim();
                if (string.IsNullOrWhiteSpace(child.childName))
                {
                    nullErrorLabel.IsVisible = true;
                    nullErrorLabel.Text = nullErrorMessage;
                }
                else
                {
                    child.familyId = family.id;

                    await App.Database.SaveChildAsync(child);
                    await App.Database.SaveFamilyAsync(family);

                    await Navigation.PushAsync(new ChildList
                    {
                        BindingContext = family
                    });
                }
                
            }
            catch(Exception)
            {
                
            }
        }
        async void OnChildSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Family family = (Family)BindingContext;
            family.familyName = familyName.Text; //set the child name if it has been modified
            await App.Database.SaveFamilyAsync(family);

            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ChildDetails
                {
                    BindingContext = e.SelectedItem as Child
                });
            }
        }
        async void Button_Delete(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Delete Family ?", "Do you really want to delete this family and all its children?", "Yes", "No");
            if (answer == true)
            {
                Family family = (Family)BindingContext;
                List<Child> children = await App.Database.GetChildListByFamilyAsync(family.id);

                foreach (Child child in children)
                {
                    await App.Database.DeleteChildAsync(child);
                }

                await App.Database.DeleteFamilyAsync(family);
                await Navigation.PushAsync(new FamilyList
                {
                    BindingContext = new FamilyList()
                });
            }
        }
        async void OnBackClicked(object sender, EventArgs e)
        {
            Family family = (Family)BindingContext;
            family.familyName = familyName.Text; //set the child name if it has been modified
            await App.Database.SaveFamilyAsync(family);
            await Navigation.PushAsync(new FamilyList
            {
                BindingContext = new FamilyList()
            });
        }
    }
}