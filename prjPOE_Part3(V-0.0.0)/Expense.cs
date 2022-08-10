using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE_Part3_V_0._0._0_
{
    public abstract class Expense
    {
        //Lists of costs and their descriptions
        List<double> allExpenses = new List<double>();
        List<string> expensesNames = new List<string>()
        {
            "Groceries:\t", "Water and lights:\t","Travel costs:\t", "Cellphone and telephone:",
            "Other expenses:\t"
        };

        //Calculations necessitate the use of variables.
        public double Money;
        public double MonthlyIncome;
        public double dbldeposit;
        public double MonthlyInterest;
        public double LoanDuration;

        //Getter and setter methods 
        public List<double> AllExpenses { get => allExpenses; set => allExpenses = value; }
        public List<string> ExpensesNames { get => expensesNames; set => expensesNames = value; }

        //Method for categorizing expenditures
        public void sortExpenses()
        {
            double tempValue;
            string tempName;

            for (int x = 0; x < AllExpenses.Count - 1; x++)
            {
                for (int y = 0; y < AllExpenses.Count - 1; y++)
                {
                    if (AllExpenses[y] < AllExpenses[y + 1])
                    {
                        tempValue = AllExpenses[y + 1];
                        tempName = ExpensesNames[y + 1];
                        AllExpenses[y + 1] = AllExpenses[y];
                        ExpensesNames[y + 1] = ExpensesNames[y];
                        AllExpenses[y] = tempValue;
                        ExpensesNames[y] = tempName;
                    }
                }
            }
        }

        //Methods to be overridden in child classes
        public abstract void calculateExpenses(double price);
        public abstract string ToString();
    }
}
