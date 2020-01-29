using CalculEcolage.Algorithms;
using CalculEcolage.Models;
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
    public partial class SetParameters : ContentPage
    {
        //Toast
        String uploadSuccessfullMessage = "Update successfull";
        ToastIOS toast = new ToastIOS();
        //error messages
        String alertTitle = "Error";
        String alertCheck = "OK";
        String notNumberErrorMessage = "You have to type a number";
        String nullNameErrorMessage = "You have to fill both fields";
        public SetParameters()
        {
            InitializeComponent();
        }
        //set enrolement fees button
        async private void SetEnrolementFees(object sender, EventArgs e)
        {
            int cost = 0;
            var item = new EnrolementFees();
            try
            {
                cost = int.Parse(EnrolementCost.Text);
                item.id = 0;
                item.cost = cost;

                await App.Database.SaveEnrolementFeesAsync(item);
                item = await App.Database.GetEnrolementFeesAsync(0);

                errorEnrolementMessage.IsVisible = false;
                await Navigation.PushAsync(new SetParameters());
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
            }
            
        }
        //set tuition fees button
        async private void SetTuitionFees(object sender, EventArgs e)
        {
            int yearCost = 0;
            var tuitionfees = new TuitionFees(); ;
           
            if (!(string.IsNullOrEmpty(TuitionFeesYear.Text)))
            {
                try
                {
                    try
                    {
                        yearCost = int.Parse(TuitionFeesCost.Text);
                        errorTuitionCostMessage.IsVisible = false;
                    }
                    catch (Exception)
                    {
                        DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                    }

                    tuitionfees.yearName = TuitionFeesYear.Text;
                    await App.Database.SaveTuitionFeesAsync(tuitionfees);
                    tuitionfees = await App.Database.GetTuitionFeesAsync(TuitionFeesYear.Text);

                    tuitionfees.cost = yearCost;
                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }

           
        }
        //set assistance discount button
        async private void SetAssistanceDiscount(object sender, EventArgs e)
        {
            int yearCost = 0;
            var assistanceDiscount = new AssistanceDiscount(); ;
            
            if (!(string.IsNullOrEmpty(AssistanceDiscountName.Text)))
            {
                try
                {
                    yearCost = int.Parse(AssistanceDiscountCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    assistanceDiscount.name = AssistanceDiscountName.Text;
                    await App.Database.SaveAssistanceDiscountAsync(assistanceDiscount);
                    assistanceDiscount = await App.Database.GetAssistanceDiscountAsync(AssistanceDiscountName.Text);

                    assistanceDiscount.discountPercentage = yearCost;

                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        //set assistance discount button
        async private void SetTermDiscount(object sender, EventArgs e)
        {
            int yearCost = 0;
            var termDiscount = new TermDiscount(); ;
            
            if (!(string.IsNullOrEmpty(TermDiscountName.Text)))
            {
                try
                {
                    yearCost = int.Parse(TermDiscountCost.Text);
                    errorTuitionCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    termDiscount.name = TermDiscountName.Text;
                    await App.Database.SaveTermDiscountAsync(termDiscount);
                    termDiscount = await App.Database.GetTermDiscountAsync(TermDiscountName.Text);

                    termDiscount.discountPercentage = yearCost;
                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        //set fixed charges button
        async private void SetFixedCharges(object sender, EventArgs e)
        {
            int cost = 0;
            var fixedCharges = new FixedCharges(); ;
            
            if (!(string.IsNullOrEmpty(FixedChargesYear.Text)))
            {
                try
                {
                    cost = int.Parse(FixedChargesCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    fixedCharges.yearName = FixedChargesYear.Text;
                    await App.Database.SaveFixedChargesAsync(fixedCharges);
                    fixedCharges = await App.Database.GetFixedChargesAsync(FixedChargesYear.Text);
                    errorFixedChargesCostMessage.IsVisible = false;
                    fixedCharges.cost = cost;
                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        //set chool meals button
        async private void SetSchoolMeals(object sender, EventArgs e)
        {
            int cost = 0;
            var schoolMeals = new SchoolMeals(); ;
            
            if (!(string.IsNullOrEmpty(SchoolMealsYear.Text)))
            {
                try
                {
                    cost = int.Parse(SchoolMealsCost.Text);
                    errorSchoolMealsCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    schoolMeals.yearName = SchoolMealsYear.Text;
                    await App.Database.SaveSchoolMealsAsync(schoolMeals);
                    schoolMeals = await App.Database.GetSchoolMealsAsync(SchoolMealsYear.Text);
                    errorSchoolMealsCostMessage.IsVisible = false;
                    schoolMeals.cost = cost;
                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        async private void SetWednesdayMeals(object sender, EventArgs e)
        {
            int cost = 0;
            var wednesdayMeals = new WednesdayMeals(); ;
            
            if (!(string.IsNullOrEmpty(WednesdayMealsYear.Text)))
            {
                try
                {
                    cost = int.Parse(WednesdayMealsCost.Text);
                    errorWednesdayMealsCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    wednesdayMeals.yearName = WednesdayMealsYear.Text;
                    await App.Database.SaveWednesdayMealsAsync(wednesdayMeals);
                    wednesdayMeals = await App.Database.GetWednesdayMealsAsync(WednesdayMealsYear.Text);
                    errorWednesdayMealsCostMessage.IsVisible = false;
                    wednesdayMeals.cost = cost;
                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        //set School Transport button
        async private void SetSchoolTransport(object sender, EventArgs e)
        {
            int cost = 0;
            var schoolTransport = new SchoolTransport(); ;
            
            if (!(string.IsNullOrEmpty(SchoolTransportZone.Text)))
            {
                try
                {
                    cost = int.Parse(SchoolTransportCost.Text);
                    errorSchoolTransportCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    schoolTransport.zone = SchoolTransportZone.Text;
                    await App.Database.SaveSchoolTransportAsync(schoolTransport);
                    schoolTransport = await App.Database.GetSchoolTransportAsync(SchoolTransportZone.Text);
                    errorSchoolTransportCostMessage.IsVisible = false;
                    schoolTransport.cost = cost;

                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        // set Supervision cost button
        async private void SetSupervision(object sender, EventArgs e)
        {
            int cost = 0;
            var supervision = new Supervision(); ;
            
            if (!(string.IsNullOrEmpty(SupervisionName.Text)))
            {
                try
                {
                    cost = int.Parse(SupervisionCost.Text);
                    errorSupervisionCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    supervision.name = SupervisionName.Text;
                    await App.Database.SaveSupervisionAsync(supervision);
                    supervision = await App.Database.GetSupervisionAsync(SupervisionName.Text);
                    errorSupervisionCostMessage.IsVisible = false;
                    supervision.cost = cost;

                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        // set support cost button
        async private void SetSupport(object sender, EventArgs e)
        {
            int cost = 0;
            var support = new Support(); ;
            
            if (!(string.IsNullOrEmpty(SupportName.Text)))
            {
                try
                {
                    cost = int.Parse(SupportCost.Text);
                    errorSupportCostMessage.IsVisible = false;
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                try
                {
                    support.name = SupportName.Text ;
                    await App.Database.SaveSupportAsync(support);
                    support = await App.Database.GetSupportAsync(SupportName.Text);
                    errorSupportCostMessage.IsVisible = false;
                    support.cost = cost;

                    await Navigation.PushAsync(new SetParameters());
                    toast.ShowToast(uploadSuccessfullMessage);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
                }
            }
            else
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
        //on back clicked
        async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrUpdate());
        }
    }
}