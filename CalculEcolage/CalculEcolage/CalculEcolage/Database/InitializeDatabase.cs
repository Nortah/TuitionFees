using CalculEcolage.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculEcolage.Database
{
    public class InitializeDatabase
    {
        //Mandatory Fees
        async public void addEnrolementFees(int cost)
        {
            EnrolementFees enrolementFees = new EnrolementFees(); enrolementFees.id = 0; enrolementFees.cost = cost;
            await App.Database.SaveEnrolementFeesAsync(enrolementFees); ;
        }
        
        async public void addTuitionFees(String year, int cost)
        {
            TuitionFees tuitionFees = new TuitionFees(); tuitionFees.yearName = year; tuitionFees.cost = cost;
            await App.Database.SaveTuitionFeesAsync(tuitionFees);
        }
        async public void addFixedCharges(String year, int cost)
        {
            FixedCharges fixedCharges = new FixedCharges(); fixedCharges.yearName = year; fixedCharges.cost = cost;
            await App.Database.SaveFixedChargesAsync(fixedCharges);
        }
        async public void addExternalEliminationFee(String year, int cost)
        {
            ExternalExaminationFees examinationFees = new ExternalExaminationFees(); examinationFees.yearName = year; examinationFees.cost = cost;
            await App.Database.SaveExternalExaminationFeesAsync(examinationFees);
        }
        //Optionnal discounts
        async public void addAssistanceDiscount(String name, int percentage)
        {
            AssistanceDiscount assistanceDiscount = new AssistanceDiscount(); assistanceDiscount.name = name; assistanceDiscount.discountPercentage = percentage;
            await App.Database.SaveAssistanceDiscountAsync(assistanceDiscount);
        }
        async public void addTermDiscount(String name, int percentage)
        {
            TermDiscount termDiscount = new TermDiscount(); termDiscount.name = name; termDiscount.discountPercentage = percentage;
            await App.Database.SaveTermDiscountAsync(termDiscount);
        }

        //Optionnal Costs
        async public void addSchoolMeals(String year, int cost)
        {
            SchoolMeals schoolMeals = new SchoolMeals(); schoolMeals.yearName = year; schoolMeals.cost = cost;
            await App.Database.SaveSchoolMealsAsync(schoolMeals);

        }
        async public void addWednesdayMeals(String year, int cost)
        {
            WednesdayMeals wednesdayMeals = new WednesdayMeals(); wednesdayMeals.yearName = year; wednesdayMeals.cost = cost;
            await App.Database.SaveWednesdayMealsAsync(wednesdayMeals);

        }
        async public void addSchoolTransport(String zone, int cost)
        {
            SchoolTransport schoolTransport = new SchoolTransport(); schoolTransport.zone = zone; schoolTransport.cost = cost;
            await App.Database.SaveSchoolTransportAsync(schoolTransport);
        }
        async public void addSupervision(String name, int cost)
        {
            Supervision supervision = new Supervision(); supervision.name = name; supervision.cost = cost;
            await App.Database.SaveSupervisionAsync(supervision);
        }
        async public void addSupport(String name, int cost)
        {
            Support support = new Support(); support.name = name; support.cost = cost;
            await App.Database.SaveSupportAsync(support);
        }

        public void populateDatabase()
        {
            //year
            String y1 = "E1";
            string y1m = "E1M";
            String y2 = "E2";
            String y3 = "E3";
            String y4 = "P1";
            String y5 = "P2";
            String y6 = "P3";
            String y7 = "P4";
            String y8 = "P5";
            String y9 = "MYP1";
            String y10 = "MYP2";
            String y11 = "MYP3";
            String y12 = "MYP4";
            String y13 = "MYP5";
            String y14 = "DP1";
            String y15 = "DP2";

            //assistance discount 
            String firstDiscount = "Financial Aid";
            String secondDiscount = "Sibling";
            //term discount 
            String annual = "Annually";
            String biAnnual = "Bi-annually";
            String termly = "Termly";
            String monthly = "Monthly";
            //zone
            String zone1 = "Zone 1";
            String zone2 = "Zone 2";
            String zone3 = "Zone 3";
            String nestle = "Navette Nestlé";
            String veveyGare = "Navette  Vevey-Gare";

            //supervision
            String s1 = "All-inclusive";
            String s2 = "Wedneseday supervision";
            String s3 = "Wedneseday activities";
            String s4 = "Wedneseday activities + supervision";
            String s5 = "1 day / week teddy or study";
            String s6 = "2 days / week teddy or study";
            String s7 = "Wednedays activities until 6pm";
            //support
            String special = "Integration Langage support";
            String year1 = "Primary";
            String year2 = "Secondary";

            String type1 = "individual";
            String type2 = "group";
            
            String periodNumber1 = "1 session/week";
            String periodNumber2 = "2 sessions/ week";
            String periodNumber3 = "3 sessions/ week";
            String periodNumber4 = "4 sessions/ week";


            addEnrolementFees(3500);
            //SET Tuition fees
            addTuitionFees(y1, 24400);
            addTuitionFees(y1m, 19500);
            addTuitionFees(y2, 24500);
            addTuitionFees(y3, 25500);
            addTuitionFees(y4, 25600);
            addTuitionFees(y5, 25600);
            addTuitionFees(y6, 25700);
            addTuitionFees(y7, 25800);
            addTuitionFees(y8, 25900);
            addTuitionFees(y9, 29800);
            addTuitionFees(y10, 29800);
            addTuitionFees(y11, 30000);
            addTuitionFees(y12, 31700);
            addTuitionFees(y13, 31700);
            addTuitionFees(y14, 34500);
            addTuitionFees(y15, 34500);
            //SET fixed charges
            addFixedCharges(y1, 700);
            addFixedCharges(y1m, 300);
            addFixedCharges(y2, 800);
            addFixedCharges(y3, 800);
            addFixedCharges(y4, 1300);
            addFixedCharges(y5, 1300);
            addFixedCharges(y6, 1850);
            addFixedCharges(y7, 2000);
            addFixedCharges(y8, 2000);
            addFixedCharges(y9, 2300);
            addFixedCharges(y10, 2300);
            addFixedCharges(y11, 2300);
            addFixedCharges(y12, 2300);
            addFixedCharges(y13, 2300);
            addFixedCharges(y14, 2200);
            addFixedCharges(y15, 2200);
            //SET external examination fees
            addExternalEliminationFee(y1, 0);
            addExternalEliminationFee(y1m, 0);
            addExternalEliminationFee(y2, 0);
            addExternalEliminationFee(y3, 0);
            addExternalEliminationFee(y4, 0);
            addExternalEliminationFee(y5, 0);
            addExternalEliminationFee(y6, 0);
            addExternalEliminationFee(y7, 0);
            addExternalEliminationFee(y8, 0);
            addExternalEliminationFee(y9, 0);
            addExternalEliminationFee(y10, 0);
            addExternalEliminationFee(y11, 0);
            addExternalEliminationFee(y12, 0);
            addExternalEliminationFee(y13, 1750);
            addExternalEliminationFee(y14, 0);
            addExternalEliminationFee(y15, 2500);

            //SET assistance discount 
            addAssistanceDiscount(firstDiscount, -10);
            addAssistanceDiscount(secondDiscount, -10);
            //SET assistance discount 
            addTermDiscount(annual, -2);
            addTermDiscount(biAnnual, 0);
            addTermDiscount(termly, 0);
            addTermDiscount(monthly, 1);
            //SET school meals
            addSchoolMeals(y1, 1980);
            addSchoolMeals(y1m, 1980);
            addSchoolMeals(y2, 1980);
            addSchoolMeals(y3, 1980);
            addSchoolMeals(y4, 1980);
            addSchoolMeals(y5, 1980);
            addSchoolMeals(y6, 1980);
            addSchoolMeals(y7, 1980);
            addSchoolMeals(y8, 1980);
            addSchoolMeals(y9, 2310);
            addSchoolMeals(y10, 2310);
            addSchoolMeals(y11, 2310);
            addSchoolMeals(y12, 2310);
            addSchoolMeals(y13, 2310);
            addSchoolMeals(y14, 2310);
            addSchoolMeals(y15, 2310);
            //SET wedneday meals
            addWednesdayMeals(y1, 495);
            addWednesdayMeals(y1m, 495);
            addWednesdayMeals(y2, 495);
            addWednesdayMeals(y3, 495);
            addWednesdayMeals(y4, 495);
            addWednesdayMeals(y5, 495);
            addWednesdayMeals(y6, 495);
            addWednesdayMeals(y7, 495);
            addWednesdayMeals(y8, 495);
            addWednesdayMeals(y9, 575);
            addWednesdayMeals(y10, 575);
            addWednesdayMeals(y11, 575);
            addWednesdayMeals(y12, 575);
            addWednesdayMeals(y13, 575);
            addWednesdayMeals(y14, 575);
            addWednesdayMeals(y15, 575);
            //SET school transport
            addSchoolTransport(zone1, 1500);
            addSchoolTransport(zone2, 2700);
            addSchoolTransport(zone3, 3600);
            addSchoolTransport(nestle, 0);
            addSchoolTransport(veveyGare, 0);
            //SET Supervision
            addSupervision(s1, 2500);
            addSupervision(s2, 1850);
            addSupervision(s3, 2200);
            addSupervision(s4, 2850);
            addSupervision(s5, 430);
            addSupervision(s6, 860);
            addSupervision(s7, 2550);

            //SET support
            addSupport(special, 3000);

            addSupport(year1 + " " + type1 + " " + "lessons : " + periodNumber1, 2475);
            addSupport(year1 + " " + type1 + " " + "lessons : " + periodNumber2, 4950);
            addSupport(year1 + " " + type1 + " " + "lessons : " + periodNumber3, 7425);
            addSupport(year1 + " " + type1 + " " + "lessons : " + periodNumber4, 9900);

            addSupport(year1 + " " + type2 + " " + "lessons : " + periodNumber1, 1650);
            addSupport(year1 + " " + type2 + " " + "lessons : " + periodNumber2, 3300);
            addSupport(year1 + " " + type2 + " " + "lessons : " + periodNumber3, 4950);
            addSupport(year1 + " " + type2 + " " + "lessons : " + periodNumber4, 6600);

            addSupport(year2 + " " + type1 + " " + "lessons : " + periodNumber1, 2475);
            addSupport(year2 + " " + type1 + " " + "lessons : " + periodNumber2, 4950);
            addSupport(year2 + " " + type1 + " " + "lessons : " + periodNumber3, 7425);
            addSupport(year2 + " " + type1 + " " + "lessons : " + periodNumber4, 9900);

            addSupport(year2 + " " + type2 + " " + "lessons : " + periodNumber1, 1650);
            addSupport(year2 + " " + type2 + " " + "lessons : " + periodNumber2, 3300);
            addSupport(year2 + " " + type2 + " " + "lessons : " + periodNumber3, 4950);
            addSupport(year2 + " " + type2 + " " + "lessons : " + periodNumber4, 6600);



        }
    }
}
