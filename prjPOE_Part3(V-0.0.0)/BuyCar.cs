using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE_Part3_V_0._0._0_
{
    class BuyCar : HomeLoan
    {
        //Additional variables for computations are required.
        double Loan;
        double Repayments = 0;
        double CarInsurance;
        string CarMake;
        string CarModel;

        //Getter and setter methods for variables
        public double carInsurance { get => CarInsurance; set => CarInsurance = value; }
        public string carMake { get => CarMake; set => CarMake = value; }
        public string carModel { get => CarModel; set => CarModel = value; }

        //Calculates the monthly payments on a car loan.
        public override void calculateExpenses(double price)
        {
            Loan = (price - dbldeposit) * (1 + MonthlyInterest * (LoanDuration / 12));
            Repayments = (Loan / LoanDuration) + carInsurance;
            Money -= Repayments;

            AllExpenses.Add(Math.Round(Repayments, 2));
        }
    }
}
