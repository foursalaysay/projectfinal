using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace projectfinal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        

        // GETTING ALL THE INPUTTED VALUE AND GENERATE ALERTS
        public int eno;
        public string ename;
        public double ehour;
        public string estatus;
        public string ecivil;


        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // FUNCTIONS TO GET THE INPUT
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // SUMMARY
        //==========================
        // returnEmpNo
        // returnEmpName
        // returnTotalHours
        // returnEmpStatus
        // returnCivilStatus
        //==========================

        // GETTING THE EMPLOYEE NUMBER

        public bool isNumberEmpty()
        {
            if (string.IsNullOrEmpty(empno.Text))
                {
                    DisplayAlert("Required", "Invalid Please Enter Employee Number", "OK");
                    return true;
                }
                else
                {
                    return false;
                }
        }

        public bool isFieldsEmpty()
        {
            if (string.IsNullOrEmpty(empname.Text) || string.IsNullOrEmpty(emphour.Text) || string.IsNullOrEmpty(empstatus.Text) || string.IsNullOrEmpty(empcivil.Text))
            {
                DisplayAlert("Required", "Invalid Please Enter/Select Required Fields", "OK");
                return true;
            }
            else
            {
                return false;
            }
        }
        public int returnEmpNo()
        {
            if ((string.IsNullOrEmpty(empno.Text)) || string.IsNullOrWhiteSpace(empno.Text)){
                DisplayAlert("Empty Input", "Please Enter a Employee Number.", "OK");     
            }
            else
            {
                eno = int.Parse(empno.Text);
            }
            return eno;
        }

        //GETTING THE EMPLOYEE NAME
        public string returnEmpName()
        {
            if ((string.IsNullOrEmpty(empname.Text)) || string.IsNullOrWhiteSpace(empname.Text))
            {
                DisplayAlert("Empty Input", "Please Enter a Employee Number.", "OK");
            }
            else
            {
                ename = empname.Text;
            }
            return ename;
        }

        // GETTING THE TOTAL HOURS WORKED
        public double returnTotalHours()
        {
            if ((string.IsNullOrEmpty(emphour.Text)) || string.IsNullOrWhiteSpace(emphour.Text))
            {
                DisplayAlert("Empty Input", "Please Enter Total Hours Worked.", "OK");
            }
            else
            {
                ehour = double.Parse(emphour.Text);
            }
            return ehour;
        }

        // GETTING THE EMPLOYEE STATUS
        public string returnEmpStatus()
        {
            if ((string.IsNullOrEmpty(empstatus.Text)) || string.IsNullOrWhiteSpace(empstatus.Text))
            {
                DisplayAlert("Empty Input", "Please Enter Employee Status.", "OK");
            }
            else
            {
                estatus = empstatus.Text;
            }
            return estatus;
        }

        // GETTING THE CIVIL STATUS
        public string returnCivilStatus()
        {
            if ((string.IsNullOrEmpty(empcivil.Text)) || string.IsNullOrWhiteSpace(empcivil.Text))
            {
                DisplayAlert("Empty Input", "Please Enter Employee Status.", "OK");
            }
            else
            {
                ecivil = empcivil.Text;
            }
            return ecivil;
        }


        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------
        // THESE ARE THE FORMULAS TO GET THE CALCULATED VALUES
        //-------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------

        // FUNCITON METHODS RETURNS DATAS

        // SUMMARY
        //==========================
        // returnOvertimeHours
        // returnRatePerDay
        // returnRatePerHour
        // returnBasicIncome
        // returnOvertimeIncome
        // returnGrossIncome
        // returnDeduction
        // returnNetIncome
        // returnSSS
        // returnWTAX
        // returnPhilhealth
        // returnPagibig
        //==========================



        // OVERTIME HOURS
        public double returnOvertimeHours(double workingHours)
        {
            double overtimeHours;
            if (workingHours > 120)
            {
                overtimeHours = workingHours - 120;
            }
            else
            {
                overtimeHours = 0;
            }
            return overtimeHours;
        }

        // RATE PER DAY VALUE
        public double returnRatePerDay(string ES)
        {
            double RatePerDayValue;

            if(ES.ToLower() == "r") {
                RatePerDayValue = 800;
            }
            else if(ES.ToLower() == "p")
            {
                RatePerDayValue = 600;
            }
            else if(ES.ToLower() == "c")
            {
                RatePerDayValue = 500;
            }
            else if(ES.ToLower() == "t")
            {
                RatePerDayValue = 450;
            }
            else
            {
                RatePerDayValue = 400;
            }

            return RatePerDayValue;
        }

        // RATE PER HOUR VALUE
        public double returnRatePerHour(double RPD)
        {
            return RPD / 8;
        }

        // BASIC INCOME
        public double returnBasicIncome(double HW, double RPH)
        {
            return HW * RPH;
        }

        // OVERTIME INCOME 
        public double returnOvertimeIncome(double RPH, double OH)
        {
            return OH * (1.5 * RPH);
        }

        // GROSS INCOME
        public double returnGrossIncome(double B, double O)
        {
            return B + O;
        }

        // DEDUCTION
        public double returnDeduction(double W, double S, double PH, double PA)
        {
            return W + S + PH + PA;
        }

        // NET INCOME
        public double returnNetIncome(double GI, double D)
        {
            return GI - D;
        }

        // SSS
        public double returnSSS(double GI)
        {
            double SValue;
            if(GI > 10000)
            {
                SValue = GI * 0.10;
            }
            else if(GI > 5000 && GI <= 10000)
            {
                SValue = GI * 0.08;
            }
            else
            {
                SValue = GI * 0.05;
            }

            return SValue;
        }

        // WTAX
        public double returnWTAX(double GI)
        {
            double WValue;
            if (GI > 8000 && GI <= 30000)
            {
                WValue = 3192 * 0.15;
            }
            else if(GI > 30000)
            {
                WValue = 9167 * 0.15;
            }
            else
            {
                double B = 61.65;
                double E = 904 * 0.20;

                WValue = E + B;
            }
            return WValue;
        }

        // PHILHEALTH
        public double returnPhilhealth(string S)
        {
            double HValue;
            if (S.ToLower() == "s")
            {
                HValue = 500;
            }
            else if(S.ToLower() == "m")
            {
                HValue = 300;
            }
            else if (S.ToLower() == "w")
            {
                HValue = 400;
            }
            else
            {
                HValue = 350;
            }

            return HValue;
        }

        // PAG-IBIG

        public double returnPagibig(double GI)
        {
            double PValue;
            if(GI <= 1500)
            {
                PValue = GI * 0.01;
            }
            else
            {
                PValue = GI * 0.02;
            }

            return PValue;
        }



        // NEW VALUES CALLED IN THE ACTIONS

        // TO BE SAVED IN DATABASE
        public string eName;
        public double hWork = 0 ;
        public string eStat;
        public string cStat;

        public double rphValue;
        public double basicValue;
        public double overtimeValue;
        public double grossValue;
        public double sssValue;
        public double wTaxValue;
        public double pHealthValue;
        public double pIbigValue;
        public double deductionValue;
        public double netIncomeValue;

        // NEEDED FORMULA VALUES
        public double rpdValue;
        public double overtimeHoursValue;


        // SUMMARY
        //==========================
        // returnOvertimeHours
        // returnRatePerDay
        // returnRatePerHour
        // returnBasicIncome
        // returnOvertimeIncome
        // returnGrossIncome
        // returnDeduction
        // returnNetIncome
        // returnSSS

        // returnWTAX
        // returnPhilhealth
        // returnPagibig
        //==========================


        // ADDING TO DATABASE
        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool isEmpty = isFieldsEmpty();

                if (!isEmpty)
                {
                    eName = returnEmpName();
                    hWork = returnTotalHours();
                    eStat = returnEmpStatus();
                    cStat = returnCivilStatus();

                    // NEEDED FORMULA VALUES
                    rpdValue = returnRatePerDay(eStat);
                    overtimeHoursValue = returnOvertimeHours(hWork);

                    rphValue = returnRatePerHour(rpdValue);
                    basicValue = returnBasicIncome(120, rphValue);
                    overtimeValue = returnOvertimeIncome(rphValue, overtimeHoursValue);
                    grossValue = returnGrossIncome(basicValue, overtimeValue);
                    sssValue = returnSSS(grossValue);
                    wTaxValue = returnWTAX(grossValue);
                    pHealthValue = returnPhilhealth(cStat);
                    pIbigValue = returnPagibig(grossValue);
                    deductionValue = returnDeduction(wTaxValue, sssValue, pHealthValue, pIbigValue);
                    netIncomeValue = returnNetIncome(grossValue, deductionValue);

                    Data data = new Data()
                    {
                        empName = eName,
                        hoursWork = hWork,
                        empStatus = eStat,
                        civilStatus = cStat,
                        ratePerHour = rphValue,
                        basicIncome = basicValue,
                        overtimeIncome = overtimeValue,
                        grossIncome = grossValue,
                        SSS = sssValue,
                        WTAX = wTaxValue,
                        PHILHEALTH = pHealthValue,
                        PAGIBIG = pIbigValue,
                        DEDUCTION = deductionValue,
                        netIncome = netIncomeValue
                    };

                    // Proceed with saving data
                    await App.SQLitedb.SaveItemAsync(data);
                    await DisplayAlert("Success", "Successfully saved!", "OK");


                    Data latestData = await App.SQLitedb.ReadLatestItemAsync();

                    if (latestData != null)
                    {
                        int autoValue = latestData.empNo;
                        await Navigation.PushAsync(new Add(autoValue));
                    }
                    else
                    {
                        // Handle the case when no data is available
                        Console.WriteLine("No data available in the database.");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $" Error Occured {ex.Message}", "OK");
            }
        }


        //UPDATING THE RECORD
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                bool isEmpty = isFieldsEmpty();

                if (!isEmpty)
                {
                    eName = returnEmpName();
                    hWork = returnTotalHours();
                    eStat = returnEmpStatus();
                    cStat = returnCivilStatus();

                    // NEEDED FORMULA VALUES
                    rpdValue = returnRatePerDay(eStat);
                    overtimeHoursValue = returnOvertimeHours(hWork);

                    rphValue = returnRatePerHour(rpdValue);
                    basicValue = returnBasicIncome(120, rphValue);
                    overtimeValue = returnOvertimeIncome(rphValue, overtimeHoursValue);
                    grossValue = returnGrossIncome(basicValue, overtimeValue);
                    sssValue = returnSSS(grossValue);
                    wTaxValue = returnWTAX(grossValue);
                    pHealthValue = returnPhilhealth(cStat);
                    pIbigValue = returnPagibig(grossValue);
                    deductionValue = returnDeduction(wTaxValue, sssValue, pHealthValue, pIbigValue);
                    netIncomeValue = returnNetIncome(grossValue, deductionValue);

                    Data updatedData = new Data()
                    {
                        empName = eName,
                        hoursWork = hWork,
                        empStatus = eStat,
                        civilStatus = cStat,
                        ratePerHour = rphValue,
                        basicIncome = basicValue,
                        overtimeIncome = overtimeValue,
                        grossIncome = grossValue,
                        SSS = sssValue,
                        WTAX = wTaxValue,
                        PHILHEALTH = pHealthValue,
                        PAGIBIG = pIbigValue,
                        DEDUCTION = deductionValue,
                        netIncome = netIncomeValue
                    };

                    // Retrieve the empNo value from the UI
                    int empNo = int.Parse(empno.Text);

                    // Proceed with updating data
                    Data updatedRecord = await App.SQLitedb.UpdateItemAsync(updatedData, empNo);

                    if (updatedRecord != null)
                    {
                        await DisplayAlert("Success", "Successfully Updated!", "OK");
                        await Navigation.PushAsync(new Add(empNo));
                    }
                    else
                    {
                        await DisplayAlert("Error", "Failed to update record.", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error Occurred: {ex.Message}", "OK");
            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                int autoValue = int.Parse(empno.Text);

                // Check if a record exists with the provided empNo
                Data existingData = await App.SQLitedb.ReadItemAsync(autoValue);

                if (existingData != null)
                {
                    await Navigation.PushAsync(new Add(autoValue));
                }
                else
                {
                    await DisplayAlert("Error", "No record found for the provided Employee Number.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error Occurred: {ex.Message}", "OK");
            }
        }

        private async void Button_Clicked_3(object sender, EventArgs e)
        {
            try
            {
                bool isEmpty = isNumberEmpty();

                if (!isEmpty)
                {
                    int empNo = int.Parse(empno.Text);
                    await App.SQLitedb.DeleteItemAsync(empNo);
                    await DisplayAlert("Success", "Record deleted successfully.", "OK");

                    // Clear the form fields
                    empno.Text = string.Empty;
                    empname.Text = string.Empty;
                    emphour.Text = string.Empty;
                    empstatus.Text = string.Empty;
                    empcivil.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error Occurred: {ex.Message}", "OK");
            }
        }
    }
}
