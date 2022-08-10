using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prjPOE_Part3_V_0._0._0_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //(Generic Collection) list for storing costs
        List<double> lstExpenses = new List<double>();
        double Monthlyincome, Houseprice, Housedeposit, Houseinterest, LoanDuration;
        //Variables for obtaining user input from textBoxes
        double Price, Deposit, Interest, carInsurance;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            addValues();

            //If it determines which radio button option is selected,
            //it changes values in the applicable class.
            if (rbtBuy.IsChecked == true )
            {
                Expense buy = new HomeLoan();
                buy.MonthlyIncome = Monthlyincome;
                buy.AllExpenses = lstExpenses;
                buy.dbldeposit = Housedeposit;
                buy.MonthlyInterest = Houseinterest;
                buy.LoanDuration = LoanDuration;

                //Determines if the user want to purchase an automobile.
                if (rbtYes.IsChecked == true)
                {
                    buy.AllExpenses = Car(buy.AllExpenses);
                    buy.ExpensesNames.Add("Monthly car payments:");
                }
                buy.calculateExpenses(Houseprice);

                //Displays the output
                lblDisplay.Content=buy.ToString() + checkSavings();
            }
            else if (rbtRent.IsChecked == true )
            {
                Expense rent = new Rent();
                rent.MonthlyIncome = Monthlyincome;
                rent.AllExpenses = lstExpenses;

                //Checks if user wants to buy a car
                if (rbtYes.IsChecked == true)
                {
                    rent.AllExpenses = Car(rent.AllExpenses);
                    rent.ExpensesNames.Add("Monthly Car payments:");
                }
                rent.calculateExpenses(Houseprice);

                //Display the output
                lblDisplay.Content = rent.ToString() + checkSavings();
            }
            //Only operates if the user does not choose to buy or rent.
            else if (rbtBuy.IsChecked == false && rbtRent.IsChecked == false)
            {
                lblDisplay.Content = "Select if you want to buy or rent a property.";
            }

            //Clears the list after computation so that new expenditures can be
            //saved separately rather of being appended to current ones.

            lstExpenses.Clear();
        }

        //The method adds data to the BuyCar class
        //and modifies the expenditures list as needed.
        private List<double> Car(List<double> expenses)
        {
            BuyCar car = new BuyCar();
            car.AllExpenses = expenses;
            car.dbldeposit = Deposit;
            car.MonthlyInterest = Interest;
            car.LoanDuration = 60;
            car.carInsurance = carInsurance;
            car.calculateExpenses(Price);
            expenses = car.AllExpenses;
            return expenses;
        }

        private void addValues()
        {

            //Try Catch to save input and throw exceptions
            //depending on the kind of mistake
            try
            {
               
                Houseprice = Convert.ToDouble(txtPriceRent.Text);
                Monthlyincome = Convert.ToDouble(txtIncome.Text);
                lstExpenses.Add(Convert.ToDouble(txtGroceries.Text));
                lstExpenses.Add(Convert.ToDouble(txtWaterLights.Text));
                lstExpenses.Add(Convert.ToDouble(txtTravel.Text));
                lstExpenses.Add(Convert.ToDouble(txtPhone.Text));
                lstExpenses.Add(Convert.ToDouble(txtOther.Text));


                //If statement only saves buy values if buy
                //option is selected.
                if (rbtBuy.IsChecked == true)
                {
                    Housedeposit = Convert.ToDouble(txtDeposit.Text);
                    Houseinterest = Convert.ToDouble(txtInterest.Text) / 100;
                    LoanDuration = Convert.ToDouble(txtMonths.Text);
                }

                //If the statement saves car values, only if the yes
                //option is chosen
                if (rbtYes.IsChecked == true)
                { 
                    Price = Convert.ToDouble(txtCarPrice.Text);
                    Deposit = Convert.ToDouble(txtCarDeposit.Text);
                    Interest = Convert.ToDouble(txtCarInterest.Text) / 100;
                    carInsurance = Convert.ToDouble(txtCarInsurance.Text);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Enter all empty fields");
              
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter numeric values");
               
            }
          
        }


        //Method for calculating the monthly amount that must be saved each
        //month in order to attain the target by the deadline.
        private string checkSavings()
        {
            string strDisplay = "";
            if (rbtSaveYes.IsChecked == true)
            {
                string strReason = txtAmount.Text;
                double dblGoal = Convert.ToDouble(txtAmount.Text);
                DateTime startDate = DateTime.Today;
                DateTime endDate = Convert.ToDateTime(dtEndDate.DisplayDate);
                double dblMonths = Math.Abs((startDate.Month - endDate.Month) + 12 * (startDate.Year - endDate.Year));
                double dblInterest = Convert.ToDouble(txtSavingsInterest.Text) / 100;
                double dblCurrentAmount = 0;

                dblGoal = dblGoal * dblInterest;
                dblCurrentAmount = Math.Pow(1 + dblInterest, dblMonths);
                dblCurrentAmount = dblCurrentAmount - 1;
                dblCurrentAmount = dblGoal / dblCurrentAmount;


                strDisplay += "\n\n\nSAVINGS:\n---------------------------------------\nMonthly Amount to save to reach goal = R" + Math.Round(dblCurrentAmount);
            }
            

            return strDisplay;
        }
    }
}
