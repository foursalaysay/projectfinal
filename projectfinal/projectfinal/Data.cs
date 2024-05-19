using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace projectfinal
{
    public class Data {

        [AutoIncrement, PrimaryKey]
        public int empNo { get; set; }
        public string empName { get; set; }
        public double hoursWork { get; set; }
        public string empStatus { get; set; }
        public string civilStatus { get; set; }

        // SOLVING AND OUTPUTS

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



    }

}
