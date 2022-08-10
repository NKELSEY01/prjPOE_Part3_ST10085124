using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE_Part3_V_0._0._0_
{
    class Rent : Expense
    {
        //The method computes the amount of money left over after costs.
        public override void calculateExpenses(double price)
        {
            Money = MonthlyIncome - price;

            foreach (double e in AllExpenses)
            {
                Money -= e;
            }
            AllExpenses.Add(price);
            ExpensesNames.Add("Rent:\t\t");
            sortExpenses();
        }

        //For output, the method returns a string.
        public override string ToString()
        {
            String strDisplay = "MONTHLY EXPENSES:";
            strDisplay += "\n*****************************************\n";
            for (int y = 0; y < AllExpenses.Count; y++)
            {
                strDisplay += ExpensesNames[y] + " \tR" + AllExpenses[y] + "\n";
            }
            strDisplay += "******************************************";
            strDisplay += "\nAvailable = R" + Math.Round(Money, 2);
            return strDisplay;
        }

    }
}
