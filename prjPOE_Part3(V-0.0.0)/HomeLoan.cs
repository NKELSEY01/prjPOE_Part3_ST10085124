using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE_Part3_V_0._0._0_
{
    class HomeLoan : Expense
    {
        //Only required variables in child class
        double Loan;
        double Payments = 0;

        //Method calculates loan value, monthly payments and
        //available money after deductions 
        public override void calculateExpenses(double price)
        {
            Money = MonthlyIncome;

            foreach (double e in AllExpenses)
            {
                Money -= e;
            }

            Loan = (price - dbldeposit) * (1 + MonthlyInterest * (LoanDuration / 12));
            Payments = (Loan / LoanDuration);
            Money -= Payments;

            AllExpenses.Add(Math.Round(Payments, 2));
            ExpensesNames.Add("Monthly Home Payments:");
            sortExpenses();
        }


        //ToString method to return an output string
        public override string ToString()
        {
           
            String strOutput = "MONTHLY EXPENSES:";
            strOutput += "\n****************************************\n";
            for (int x = 0; x < AllExpenses.Count; x++)
            {
                strOutput += (ExpensesNames[x] + " \tR" + AllExpenses[x] + "\n");
            }
            strOutput += "******************************************";
            strOutput += "\nAvailable = R" + Math.Round(Money, 2);
            strOutput += "\n****************************************\n";

            if (Payments > (MonthlyIncome * 0.33))
            {
                strOutput += "\nLoan approval is unlikely";
            }

            return strOutput;
        }
    }
}
