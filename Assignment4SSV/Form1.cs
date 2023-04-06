using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assignment4SSV
{ /* Name: Snehal Vibhute
   * Date: 3/1/2023
   * Pupose: Create a desktop application that will allow user to calculate the monthly payment for a fixed-rate interest loan
   */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Validate required fields are not empty
            if(string.IsNullOrWhiteSpace(txtPurchasePrice.Text) ||
                string.IsNullOrWhiteSpace(txtDownPaymentAmount.Text) ||
                string.IsNullOrWhiteSpace(txtInterestRate.Text) ||
                string.IsNullOrWhiteSpace(txtLoanTerm.Text))
            { MessageBox.Show("This inputs form cannot be empty.", "Missing Required Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // validate numeric input for required field
            double purchasePrice, downPaymentAmount, interestRate;
            int loanTerm;

            if(!double.TryParse(txtPurchasePrice.Text, out purchasePrice))
            {
                MessageBox.Show("Please enter a valid numeric value for Purchase Price.","Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (!double.TryParse(txtDownPaymentAmount.Text, out downPaymentAmount))
            {
                MessageBox.Show("Please enter a valid numeric value for Down Payment Amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!double.TryParse(txtInterestRate.Text, out interestRate))
            {
                MessageBox.Show("This input's value must be a valid decimal.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtLoanTerm.Text, out loanTerm))
            {
                MessageBox.Show("Please enter a valid numeric value for Loan Term(in months).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Calculate amount to finance and monthly payment
            double amountToFinance = purchasePrice - downPaymentAmount;
            double monthlyInterestRate = interestRate / 1200;
            double monthlyPayment = (amountToFinance * monthlyInterestRate) * Math.Pow(1 + monthlyInterestRate, loanTerm) / (Math.Pow(1 + monthlyInterestRate, loanTerm) - 1);

            // Display results
            txtAmountToFinance.Text = amountToFinance.ToString("C");
            txtMonthlyPayment.Text = monthlyPayment.ToString("C");
            }
        }
    }



