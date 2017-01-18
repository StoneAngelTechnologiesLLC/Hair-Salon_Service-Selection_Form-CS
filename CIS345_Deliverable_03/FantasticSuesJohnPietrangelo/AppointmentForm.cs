//John Pietrangelo CIS345 Tues/Thurs 9am
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FantasticSuesJohnPietrangelo
{
    public partial class AppointmentForm : Form
    {
        private static int positionNum =0;
        private static int aptCount = 0;
        private static bool validPhoneNumber =false;
        private static string firstName;
        private static string lastName;
        private static int phoneNumber;
        private static int areaCode;
        private static int prefix;
        private static int postfix;
        private static bool adultHairCut;
        private static bool chldSrHairCut;
        private static bool hairStyling;
        private static bool perm;
        private static bool bangNeckBeardTrim;
        private static bool shampoo;
        private static double totalBill;
        private static double totalBillDoubleValue;
        private static double adultPrice = 13.00;
        private static double cldSrPrice = 11.00;
        private static double permPrice = 72.00;
        private static double stylePrice = 45.00;
        private static double bngBrdNckPrice = 6.50;
        private static double shampooPrice = 4.00;
        private static Appointment [] appointments = new Appointment[100];

        public AppointmentForm()
        {
            InitializeComponent();
            firstNameTxBx.Focus();
            MessageBox.Show("Thank You For Choosing Fantastic Susie's!!!\n\nPress OK to Setup Your Haircut Appointment");
        }

        private void setAptBtn_Click(object sender, EventArgs e)
        {
            if (subTotalTxBx.Text == ""||subTotalTxBx.Text =="$0.00")
            {
                MessageBox.Show("Error!!! You Must Select At Least 1 Offering To Set An Appointment");
            }
            else if (firstNameTxBx.Text == "" || lastNameTxBx.Text == "")
            {
                MessageBox.Show("Error!!! Please Enter Your First And Last Name Before Setting Your Appointment.");
                
            }
            else if (areaCodeTxBx.Text.Length < 3 || prefixTxBx.Text.Length < 3 || postfixTxBx.Text.Length < 4)
            {
                MessageBox.Show("Error!!! You Must Enter A Valid Phone Number To Set Your Appointment");
               
            }
            else
            {
                validPhoneNumber = ValidatePhoneNumber(areaCodeTxBx.Text, out areaCode);

                if (validPhoneNumber == false)
                {
                    MessageBox.Show("Error!!! You Must Enter A Valid Phone Number To Set Your Appointment");
                    
                }

                validPhoneNumber = ValidatePhoneNumber(prefixTxBx.Text, out prefix);

                if (validPhoneNumber == false)
                {
                    MessageBox.Show("Error!!! You Must Enter A Valid Phone Number To Set Your Appointment");
               
                }

                validPhoneNumber = ValidatePhoneNumber(postfixTxBx.Text, out postfix);

                if (validPhoneNumber == false)
                {
                    MessageBox.Show("Error!!! You Must Enter A Valid Phone Number To Set Your Appointment");
                  
                }
            }

            firstName = firstNameTxBx.Text;
            lastName = lastNameTxBx.Text;
            phoneNumber = (areaCode + prefix + postfix);
            adultHairCut = adultRdBtn.Checked;
            chldSrHairCut = childSeniorRdBtn.Checked;
            hairStyling = stylingChkBx.Checked;
            perm = permChkBx.Checked;
            bangNeckBeardTrim = permChkBx.Checked;
            shampoo = shampooChkBx.Checked;
            totalBill = totalBillDoubleValue;

            if (validPhoneNumber == true)
            {
                CreateAppointment();

                if (aptCount < 2 && validPhoneNumber == true)
                {
                    setAptTxBx.AppendText("Waiting List         Client Name\n");
                    setAptTxBx.AppendText("--------------------------------------------\n");
                }

                if (validPhoneNumber == true)
                {
                    positionNum++;
                    setAptTxBx.AppendText("Position #" + Convert.ToString(positionNum) + "          "
                                          + firstNameTxBx.Text + "  " + lastNameTxBx.Text + "\n");
                    ClearScreen();
                    validPhoneNumber = false;
                }
            }
        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }

        private void adultRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (adultRdBtn.Checked)
            {
                totalBill = totalBill + adultPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");   
            }

            if (!adultRdBtn.Checked)
            {
                totalBill = totalBill - adultPrice;
                totalBillDoubleValue = totalBill;
            }
        }

        private void childSeniorRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (childSeniorRdBtn.Checked)
            {
                totalBill = totalBill + cldSrPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }

            if (!childSeniorRdBtn.Checked)
            {
                totalBill = totalBill - cldSrPrice;
                totalBillDoubleValue = totalBill;
            }
        }

        private void permChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (permChkBx.Checked)
            {
                totalBill = totalBill + permPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }

            if (!permChkBx.Checked)
            {
                totalBill = totalBill - permPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }
        }

        private void stylingChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (stylingChkBx.Checked)
            {
                totalBill = totalBill + stylePrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }

            if (!stylingChkBx.Checked)
            {
                totalBill = totalBill - stylePrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }
        }

        private void shampooChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (shampooChkBx.Checked)
            {
                totalBill = totalBill + shampooPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }

            if (!shampooChkBx.Checked)
            {
                totalBill = totalBill - shampooPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }
        }

        private void beardTrimChkBx_CheckedChanged(object sender, EventArgs e)
        {
            if (beardTrimChkBx.Checked)
            {
                totalBill = totalBill + bngBrdNckPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }

            if (!beardTrimChkBx.Checked)
            {
                totalBill = totalBill - bngBrdNckPrice;
                totalBillDoubleValue = totalBill;
                subTotalTxBx.Text = totalBill.ToString("c");
            }
        }

        //------------------------------METHODS----------------------------------------------------------------

        public static void CreateAppointment()
        {
            appointments[aptCount] = new Appointment(firstName, lastName, phoneNumber, adultHairCut,chldSrHairCut, hairStyling, perm, bangNeckBeardTrim, shampoo,totalBill );
            aptCount++;
        }

        public static bool ValidatePhoneNumber(string valueGiven, out int valueTaken)
        {
            int validNumCount = 0;
            bool valid = false;
            valueTaken = 0;

            if (valueGiven.Length <= 4)
            {
                for (int i = 0; i < valueGiven.Length; i++)
                {
                    if (char.IsNumber(valueGiven[i]))
                        ++validNumCount;
                }

                if (validNumCount == valueGiven.Length && validNumCount >= 3)
                {
                    valueTaken = Convert.ToInt32(valueGiven);
                    valid = true;
                }
            }
            return valid;
        }

        public void ClearScreen()
        {
            firstNameTxBx.Clear();
            lastNameTxBx.Clear();
            areaCodeTxBx.Clear();
            prefixTxBx.Clear();
            postfixTxBx.Clear();

            if (adultRdBtn.Checked == true)
            {
                adultRdBtn.Checked = !adultRdBtn.Checked;
            }

            if (childSeniorRdBtn.Checked == true)
            {
                childSeniorRdBtn.Checked = !childSeniorRdBtn.Checked;
            }

            if (permChkBx.Checked == true)
            {
                permChkBx.Checked = !permChkBx.Checked;
            }

            if (stylingChkBx.Checked == true)
            {
                stylingChkBx.Checked = !stylingChkBx.Checked;
            }

            if (shampooChkBx.Checked == true)
            {
                shampooChkBx.Checked = !shampooChkBx.Checked;
            }

            if (beardTrimChkBx.Checked == true)
            {
                beardTrimChkBx.Checked = !beardTrimChkBx.Checked;
            }

            subTotalTxBx.Clear();
            totalBill = 0;
        }
    }

}
