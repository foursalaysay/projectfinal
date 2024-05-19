using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectfinal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {

        public int AutoIncrementedValue { get; set; }
        public string empName { get; set; }
        public double hoursWork { get; set; }
        public string empStatus { get; set; }
        public string civilStatus { get; set; }
        public double ratePerHour { get; set; }
        public double basicIncome { get; set; }
        public double overtimeIncome { get; set; }
        public double grossIncome { get; set; }
        public double SSS { get; set; }
        public double WTAX { get; set; }
        public double PHILHEALTH { get; set; }
        public double PAGIBIG { get; set; }
        public double DEDUCTION { get; set; }
        public double netIncome { get; set; }

        public Add(int autoValue)
        {
            InitializeComponent();
            AutoIncrementedValue = autoValue;
            BindingContext = this; // Make sure to set the BindingContext after initializing the properties
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //display all Item
            await showData();
        }



        public async Task showData()
        {

            var getData = await App.SQLitedb.ReadItemAsync(AutoIncrementedValue);

            if (getData != null)
            {
                // Assign the retrieved data to the UI controls
                empNumberEntry.Text = getData.empNo.ToString();
                empNameEntry.Text = getData.empName;
                hoursWorkedEntry.Text = getData.hoursWork.ToString();
                empStatusEntry.Text = getData.empStatus;
                civilStatusEntry.Text = getData.civilStatus;
                ratePerHourEntry.Text = getData.ratePerHour.ToString();
                basicIncomeEntry.Text = getData.basicIncome.ToString();
                overtimeIncomeEntry.Text = getData.overtimeIncome.ToString();
                grossIncomeEntry.Text = getData.grossIncome.ToString();
                sssEntry.Text = getData.SSS.ToString();
                wtaxEntry.Text = getData.WTAX.ToString();
                philhealthEntry.Text = getData.PHILHEALTH.ToString();
                pagibigEntry.Text = getData.PAGIBIG.ToString();
                deductionsEntry.Text = getData.DEDUCTION.ToString();
                netIncomeEntry.Text = getData.netIncome.ToString();
            }
        }
    }
}