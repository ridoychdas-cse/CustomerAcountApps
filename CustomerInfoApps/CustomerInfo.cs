using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomerInfoApps
{
    public partial class CustomerInfo : Form
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }

        private void CustomerInfo_Load(object sender, EventArgs e)
        {

        }

        List<string> users = new List<string>();
        List<string> FirstNames = new List<string>();
        List<string> LastNames = new List<string>();
        List<string> ContactNumbers = new List<string>();
        List<string> Emails = new List<string>();
        List<string> Addresses = new List<string>();
        List<string> AcountNumbers = new List<string>();
        List<decimal> Amounts = new List<decimal>();

        private void UserNametextBox_TextChanged(object sender, EventArgs e)
        {
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    if (user == UserNametextBox.Text)
                    {
                        lblUser.Text = "Same User Already Save";
                        return;
                    }
                    else
                    {
                        lblUser.Text = "";

                    }
                }
            }
        }

        private void contactNoTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var MobileNo = Convert.ToInt64(contactNoTextBox.Text);

                if (contactNoTextBox.Text.Length == 10)
                {
                    contactErrorProvider.Clear();
                    lblContact.Text = "";
                }
                else
                {
                    contactErrorProvider.SetError(this.contactNoTextBox, "Pleace Enter Digit Phone Number");
                    lblContact.Text = "Pleace Enter Right Phone Number";
                    return;
                }
            }
            catch (Exception exception)
            {
                contactErrorProvider.SetError(this.contactNoTextBox, "Pleace Enter 11 Digit Phone Number");
                lblContact.Text = "Pleace  Phone Number is Number Data Type";
                return;
            }
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            string Parten =
                @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
            if (Regex.IsMatch(emailTextBox.Text, Parten))
            {
                emailErrorProvider.Clear();
                lblEmail.Text = "";
            }
            else
            {
                emailErrorProvider.SetError(this.emailTextBox, "Pleace Enter Right Email Id");
                lblEmail.Text = "Pleace Enter Right Email Id";
                return;

            }
        }



        private void accountNoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AcountNumbers.Count > 0)
            {
                foreach (var acount in AcountNumbers)
                {
                    if (acount == acountNoTextBox.Text)
                    {
                        lblSameAcountNo.Text = "Same Acount Already Save";
                        return;
                    }
                    else
                    {
                        lblSameAcountNo.Text = "";

                    }
                }
            }
        }

        public void clear()
        {

            UserNametextBox.Text = "";
            lblUser.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            contactNoTextBox.Text = "";
            lblContact.Text = "";
            emailTextBox.Text = "";
            lblEmail.Text = "";
            addressTextBox.Text = "";
            acountNoTextBox.Text = "";
            lblAcountCheck.Text = "";
            lblMessageBox.Text = "";
            emailErrorProvider.Clear();
            contactErrorProvider.Clear();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserNametextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter User Name";
                    return;
                }
                else if (firstNameTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter First Name";
                    return;
                }
                else if (lastNameTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter last Name";
                    return;
                }
                else if (contactNoTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter Mobile NO";
                    return;
                }
                else if (emailTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter Email ";
                    return;
                }
                else if (addressTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter Address ";
                    return;
                }
                else if (acountNoTextBox.Text == "")
                {
                    lblMessageBox.Text = "Enter Acount No";
                    return;
                }
                else
                {
                    if (lblUser.Text == "" && lblContact.Text == "" && lblEmail.Text == "" &&
                        lblSameAcountNo.Text == "")
                    {
                        users.Add(UserNametextBox.Text);
                        FirstNames.Add(firstNameTextBox.Text);
                        LastNames.Add(lastNameTextBox.Text);
                        ContactNumbers.Add("0"+contactNoTextBox.Text);
                        Emails.Add(emailTextBox.Text);
                        Addresses.Add(addressTextBox.Text);
                        AcountNumbers.Add(acountNoTextBox.Text);
                        Amounts.Add(0);
                        clear();
                    }
                    else
                    {
                        lblMessageBox.Text = "Pleace Entry By Data Right Format";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            string output = "Id\t\tUser\t\tName\t\tPhone NO.\t\tEmail\t\tAddress\t\tAcount No\t\tAmount\n";
            int index = 0;

            foreach (var acount in AcountNumbers)
            {

                output = output + "" + (index + 1) + "\t\t" + users[index] + "\t\t" + FirstNames[index] + " " +
                         LastNames[index] +
                         "\t" + ContactNumbers[index] + "\t\t" + Emails[index] + "\t" + Addresses[index] + "\t\t\t\t" +
                         AcountNumbers[index] + "\t\t" + Amounts[index] + "\n";
                index++;
            }

            showRichTextBox.Text = output;

        }

        private void AcountCheckNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (AcountNumbers.Count > 0)
            {
                int index = 0;
                foreach (var acount in AcountNumbers)
                {
                    if (acount == AcountCheckNumberTextBox.Text)
                    {
                        DepositButton.Enabled = true;
                        WithdrawButton.Enabled = true;
                        BalanceButton.Enabled = true;
                        AmountTxtBox.ReadOnly = false;
                        lblAcountCheck.Text = "";
                        lblIndex.Text = index.ToString();
                        return;

                    }
                    else
                    {
                        DepositButton.Enabled = false;
                        WithdrawButton.Enabled = false;
                        BalanceButton.Enabled = false;
                        AmountTxtBox.ReadOnly = true;
                        lblAcountCheck.Text = "No Acount Create";
                    }

                    index++;
                }

            }
            else
            {
                MessageBox.Show("No Acount Create");
                AcountCheckNumberTextBox.Text = "";
            }

        }

        private void DepositButton_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                index = Convert.ToInt32(lblIndex.Text);
                decimal amount = Amounts[index];
                amount = (amount + Convert.ToDecimal(AmountTxtBox.Text));
                Amounts[index] = amount;
                lblAmontFormat.Text = "";
            }
            catch (Exception exception)
            {

                lblAmontFormat.Text = "Pleace Entry Amount Is Number Type Data";
                return;

            }

        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            try
            {

                int index = 0;
                index = Convert.ToInt32(lblIndex.Text);
                decimal amount = Amounts[index];
                if (amount > Convert.ToDecimal(AmountTxtBox.Text))
                {
                    amount = (amount - Convert.ToDecimal(AmountTxtBox.Text));
                    Amounts[index] = amount;
                    lblAmontFormat.Text = "";
                }
                else
                {
                    lblAmontFormat.Text = "Withdraw Amount Is Over";
                    return;
                }
                
               
            }
            catch (Exception exception)
            {

                lblAmontFormat.Text = "Pleace Entry Amount Is Number Type Data";
                return;

            }

        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(lblIndex.Text);
            lblTotalAmount.Text ="Total Amount " +Amounts[index].ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            AcountCheckNumberTextBox.Text = "";
            DepositButton.Enabled = false;
            WithdrawButton.Enabled = false;
            BalanceButton.Enabled = false;
            AmountTxtBox.ReadOnly = true;
            lblAcountCheck.Text = "";
            lblIndex.Text = "";
            AmountTxtBox.Text = "";
            lblAmontFormat.Text = "";
            lblTotalAmount.Text = "";

        }
    }
}
