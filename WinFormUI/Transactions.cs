using DemoLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class Transactions : Form
    {
        private Customer _customer;
        public Transactions(Customer customer)
        {
            InitializeComponent();
            _customer = customer;

            customerText.Text = _customer.CustomerName;
            _customer.CheckingAccount.OverdraftEvent += CheckingAccount_OverdraftEvent;
        }

        private void CheckingAccount_OverdraftEvent(object sender, OverdraftEventArgs e)
        {
            errorMessage.Visible = true;
        }

        private void makePurchaseButton_Click(object sender, EventArgs e)
        {
            if (!isDeposit.Checked)
            {
                //wyplata
                if (amountValue.Value > 0)
                {
                    bool paymentResult = _customer.CheckingAccount.MakePayment("Credit Card Purchase", amountValue.Value, _customer.SavingsAccount);
                    
                }
            }
            else 
            {
                //wplata
                if (amountValue.Value > 0)
                {
                    decimal[] amounts = _customer.CheckingAccount.CheckDeposit(amountValue.Value);
                    if (amounts.Length == 0)
                    {
                        bool paymentResult = _customer.CheckingAccount.AddDeposit("Added Deposit", amountValue.Value);
                    }
                    else
                    {
                        if (amounts[0]>0)
                        {
                            bool paymentResultC = _customer.CheckingAccount.AddDeposit("Added Deposit", amounts[0]);
                        }
                        bool paymentResultS = _customer.SavingsAccount.AddDeposit("Added Deposit", amounts[1]);
                    }
                }
            }
            amountValue.Value = 0;
        }

        private void errorMessage_Click(object sender, EventArgs e)
        {
            errorMessage.Visible = false;
        }

        private void amountLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
