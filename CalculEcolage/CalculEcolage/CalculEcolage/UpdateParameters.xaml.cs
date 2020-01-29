using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculEcolage.Algorithms;
using CalculEcolage.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CalculEcolage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateParameters : ContentPage
    {
        //Toast
        String uploadSuccessfullMessage = "Update successfull";
        String deleteMessage = "Entry deleted";
        ToastIOS toast = new ToastIOS();
        //error messages
        String alertTitle = "Error";
        String alertCheck = "OK";
        String notNumberErrorMessage = "You have to type a number";
        String nullNameErrorMessage = "You have to select one of the item";

        Picker yearPicker;
        Picker assistanceDiscountPicker;
        Picker termDiscountPicker;
        Picker zonePicker;
        Picker supportPicker;
        Picker supervisionPicker;

        public UpdateParameters()
        {
            InitializeComponent();
        }
        //initialize pickers
        protected override async void OnAppearing()
        {
            //Retrieve lists 
            List<TuitionFees> tuitions = await App.Database.GetTuittionFeesListAsync();
            List<AssistanceDiscount> assistanceDiscounts = await App.Database.GetAssistanceDiscountListAsync();
            List<TermDiscount> termDiscounts = await App.Database.GetTermDiscountListAsync();
            List<SchoolTransport> schoolTransports = await App.Database.GetSchoolTransportListAsync();
            List<Supervision> supervisions = await App.Database.GetSupervisionListAsync();
            List<Support> supports = await App.Database.GetSupportListAsync();

            // set tuition picker list
            Picker yearPicker = YearPicker as Picker;
            List<string> years = new List<string>();

            tuitions = tuitions.OrderBy(i => i.yearName).ToList();
            foreach (TuitionFees tuition in tuitions)
            {
                years.Add(tuition.yearName);
            }
            yearPicker.ItemsSource = years;

            // set assistance Discount picker list
            Picker assistanceDiscountPicker = AssistanceDiscountPicker as Picker;
            List<string> assistanceDiscountNames = new List<string>();

            assistanceDiscounts = assistanceDiscounts.OrderBy(i => i.name).ToList();
            foreach (AssistanceDiscount assistanceDiscount in assistanceDiscounts)
            {
                assistanceDiscountNames.Add(assistanceDiscount.name);
            }
            assistanceDiscountPicker.ItemsSource = assistanceDiscountNames;

            // set term Discount picker list
            Picker termDiscountPicker = TermDiscountPicker as Picker;
            List<string> termDiscountNames = new List<string>();

            termDiscounts = termDiscounts.OrderBy(i => i.name).ToList();
            foreach (TermDiscount termDiscount in termDiscounts)
            {
                termDiscountNames.Add(termDiscount.name);
            }
            termDiscountPicker.ItemsSource = termDiscountNames;

            // set zone picker list
            Picker zonePicker = ZonePicker as Picker;
            List<string> zones = new List<string>();

            schoolTransports = schoolTransports.OrderBy(i => i.zone).ToList();
            foreach (SchoolTransport schoolTransport in schoolTransports)
            {
                zones.Add(schoolTransport.zone);
            }
            zonePicker.ItemsSource = zones;

            // set supervision picker list
            Picker supervisionPicker = SupervisionPicker as Picker;
            List<string> supervisionNames = new List<string>();

            supervisions = supervisions.OrderBy(i => i.name).ToList();
            foreach (Supervision supervision in supervisions)
            {
                supervisionNames.Add(supervision.name);
            }
            supervisionPicker.ItemsSource = supervisionNames;

            // set support picker list
            Picker supportPicker = SupportPicker as Picker;
            List<string> supportNames = new List<string>();

            supports = supports.OrderBy(i => i.name).ToList();
            foreach (Support support in supports)
            {
                supportNames.Add(support.name);
            }
            supportPicker.ItemsSource = supportNames;
        }
        

         //Tuition fees
        async private void UpdateTuitionFeeButton(object sender, EventArgs e)
        {
            try
            {
                yearPicker = YearPicker as Picker;
                int yearCost = 0;
                var tuitionfees = new TuitionFees();

                tuitionfees.yearName = yearPicker.SelectedItem.ToString();
                try
                {
                    tuitionfees.cost = int.Parse(TuitionFeeCost.Text);
                }
                catch (Exception)
                { 
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck); 
                }
                await App.Database.SaveTuitionFeesAsync(tuitionfees);

                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        async private void DeleteYearFeesButton(object sender, EventArgs e)
        {
            try
            {
                // delete tuition fees
                yearPicker = YearPicker as Picker;
                var tuitionfees = new TuitionFees();

                tuitionfees.yearName = yearPicker.SelectedItem.ToString();
                await App.Database.DeleteTuitionFeesAsync(tuitionfees);
                //delete fixed charge
                var fixedCharges = new FixedCharges();

                fixedCharges.yearName = yearPicker.SelectedItem.ToString();
                await App.Database.DeleteFixedChargesAsync(fixedCharges);
                // delete external examination fees
                var externalExaminationFees = new ExternalExaminationFees();

                externalExaminationFees.yearName = yearPicker.SelectedItem.ToString();
                await App.Database.DeleteExternalExaminationFeesAsync(externalExaminationFees);
                // delete school meals
                var schoolMeals = new SchoolMeals();

                schoolMeals.yearName = yearPicker.SelectedItem.ToString();
                await App.Database.DeleteSchoolMealsAsync(schoolMeals);

                //deleste wednseday meals
                var wednesdayMeals = new WednesdayMeals();

                wednesdayMeals.yearName = yearPicker.SelectedItem.ToString();
                await App.Database.DeleteWednesdayMealsAsync(wednesdayMeals);
                await Navigation.PushAsync(new UpdateParameters());

                toast.ShowToast(deleteMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        //Fixed charges
        async private void UpdateFixedChargeButton(object sender, EventArgs e)
        {
            try
            {
                yearPicker = YearPicker as Picker;
                int yearCost = 0;
                var fixedCharges = new FixedCharges();

                fixedCharges.yearName = yearPicker.SelectedItem.ToString();
                try
                {
                    fixedCharges.cost = int.Parse(FixedChargeCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveFixedChargesAsync(fixedCharges);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        // External examination fee
        async private void UpdateExternalExaminationFeeButton(object sender, EventArgs e)
        {
            try
            {
                yearPicker = YearPicker as Picker;
                var externalExaminationFees = new ExternalExaminationFees();

                externalExaminationFees.yearName = yearPicker.SelectedItem.ToString();
                try
                {
                    externalExaminationFees.cost = int.Parse(ExternalExaminationFeeCost.Text);
                }
                catch(Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveExternalExaminationFeesAsync(externalExaminationFees);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        // School Meal
        async private void UpdateSchoolMealsButton(object sender, EventArgs e)
        {
            try
            {
                yearPicker = YearPicker as Picker;
                var schoolMeals = new SchoolMeals();

                schoolMeals.yearName = yearPicker.SelectedItem.ToString();
                try
                {
                    schoolMeals.cost = int.Parse(SchoolMealsCost.Text);
                }
                catch(Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveSchoolMealsAsync(schoolMeals);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        // wednesday School Meal
        async private void UpdateWednesdayMealsButton(object sender, EventArgs e)
        {
            try
            {
                yearPicker = YearPicker as Picker;
                var wednesdayMeals = new WednesdayMeals();

                wednesdayMeals.yearName = yearPicker.SelectedItem.ToString();
                try
                {
                    wednesdayMeals.cost = int.Parse(WednesdayMealsCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveWednesdayMealsAsync(wednesdayMeals);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        //Assistance discount
        async private void UpdateAssistanceDiscountButton(object sender, EventArgs e)
        {
            try
            {
                assistanceDiscountPicker = AssistanceDiscountPicker as Picker;
                var assistanceDiscount = new AssistanceDiscount();

                assistanceDiscount.name = assistanceDiscountPicker.SelectedItem.ToString();
                try
                {
                    assistanceDiscount.discountPercentage = int.Parse(AssistanceDiscountCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveAssistanceDiscountAsync(assistanceDiscount);

                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        async private void DeleteAssistanceDiscountButton(object sender, EventArgs e)
        {
            try
            {
                assistanceDiscountPicker = AssistanceDiscountPicker as Picker;
                var assistanceDiscount = new AssistanceDiscount();

                assistanceDiscount.name = assistanceDiscountPicker.SelectedItem.ToString();
                await App.Database.DeleteAssistanceDiscountAsync(assistanceDiscount);
                await Navigation.PushAsync(new UpdateParameters());
                toast.ShowToast(deleteMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        //term discount
        async private void UpdateTermDiscountButton(object sender, EventArgs e)
        {
            try
            {
                termDiscountPicker = TermDiscountPicker as Picker;
                var termDiscount = new TermDiscount();

                termDiscount.name = termDiscountPicker.SelectedItem.ToString();
                try
                {
                    termDiscount.discountPercentage = int.Parse(TermDiscountCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveTermDiscountAsync(termDiscount);

                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }

        }
        async private void DeleteTermDiscountButton(object sender, EventArgs e)
        {
            try
            {
                termDiscountPicker = TermDiscountPicker as Picker;
                var termDiscount = new TermDiscount();

                termDiscount.name = termDiscountPicker.SelectedItem.ToString();
                await App.Database.DeleteTermDiscountAsync(termDiscount);
                await Navigation.PushAsync(new UpdateParameters());
                toast.ShowToast(deleteMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        //School transport
        async private void UpdateSchoolTransportButton(object sender, EventArgs e)
        {
            try
            {
                zonePicker = ZonePicker as Picker;
                var schoolTransport = new SchoolTransport();

                schoolTransport.zone = zonePicker.SelectedItem.ToString();
                try
                {
                    schoolTransport.cost = int.Parse(SchoolTransportCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveSchoolTransportAsync(schoolTransport);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        async private void DeleteSchoolTransportButton(object sender, EventArgs e)
        {
            try
            {
                zonePicker = ZonePicker as Picker;
                var schoolTransport = new SchoolTransport();

                schoolTransport.zone = zonePicker.SelectedItem.ToString();
                await App.Database.DeleteSchoolTransportAsync(schoolTransport);
                await Navigation.PushAsync(new UpdateParameters());
                toast.ShowToast(deleteMessage);
                
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            

        }
        //School supervision
        async private void UpdateSupervisionButton(object sender, EventArgs e)
        {
            try
            {
                supervisionPicker = SupervisionPicker as Picker;
                var supervision = new Supervision();

                supervision.name = supervisionPicker.SelectedItem.ToString();
                try
                {
                    supervision.cost = int.Parse(SupervisionCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
                await App.Database.SaveSupervisionAsync(supervision);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch(Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        async private void DeleteSupervisionButton(object sender, EventArgs e)
        {
            try
            {
                supervisionPicker = SupervisionPicker as Picker;
                var supervision = new Supervision();
                supervision.name = supervisionPicker.SelectedItem.ToString();
                await App.Database.DeleteSupervisionAsync(supervision);
                await Navigation.PushAsync(new UpdateParameters());
                toast.ShowToast(deleteMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
        }
            

        //School support
        async private void UpdateSupportButton(object sender, EventArgs e)
        {
            try
            {
                supportPicker = SupportPicker as Picker;
                var support = new Support();

                support.name = supportPicker.SelectedItem.ToString();
                try
                {
                    support.cost = int.Parse(SupportCost.Text);
                }
                catch (Exception)
                {
                    DisplayAlert(alertTitle, notNumberErrorMessage, alertCheck);
                }
               
                await App.Database.SaveSupportAsync(support);
                toast.ShowToast(uploadSuccessfullMessage);
            }
            catch (Exception)
            {
                DisplayAlert(alertTitle, nullNameErrorMessage, alertCheck);
            }
            
        }
        async private void DeleteSupportButton(object sender, EventArgs e)
        {
            try
            {
                supportPicker = SupportPicker as Picker;
                var support = new Support();

                support.name = supportPicker.SelectedItem.ToString();
                await App.Database.DeleteSupportAsync(support);
                await Navigation.PushAsync(new UpdateParameters());
                toast.ShowToast(deleteMessage);
            }
            catch(Exception)
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