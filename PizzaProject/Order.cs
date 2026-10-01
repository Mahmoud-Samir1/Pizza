using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Order : Form
    {
        public Order()
        {
            InitializeComponent();
           
        }

        float GetSelectedSize()
        {
            if (rbSmall.Checked)
                return Convert.ToSingle(rbSmall.Tag);
            else if (rbMeduim.Checked)
                return Convert.ToSingle(rbMeduim.Tag);
            else 
                return Convert.ToSingle(rbLarg.Tag);
        }

        float GetSelectedCrustType()
        {
            if (rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag);
            else
                return Convert.ToSingle(rbThinkCrust.Tag);
        }

        float CalculateToppingsPrice()
        {
            float totalToppings = 0;
            if (chkExtraChees.Checked)
                totalToppings += Convert.ToSingle(chkExtraChees.Tag);
            if (chkMushrooms.Checked)
                totalToppings += Convert.ToSingle(chkMushrooms.Tag);
            if (chkTomatoes.Checked)
                totalToppings += Convert.ToSingle(chkTomatoes.Tag);
            if (chkOnion.Checked)
                totalToppings += Convert.ToSingle(chkOnion.Tag);
            if (chkOlives.Checked)
                totalToppings += Convert.ToSingle(chkOlives.Tag);
            return totalToppings;
        }

        decimal CalculateTotalPrice()
        {
            decimal Total = ((decimal)GetSelectedSize() + (decimal)CalculateToppingsPrice() + (decimal)GetSelectedCrustType()) * (nudHowMuch.Value);
            return Total;
        }

        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";
            if (chkExtraChees.Checked)
                sToppings = "Extra Chees";
            if (chkOnion.Checked)
                sToppings += ", Onion";
            if (chkMushrooms.Checked)
                sToppings += ", Mushrooms";
            if(chkTomatoes.Checked)
                sToppings +=", Tomatoes";
            if( chkOlives.Checked)
                sToppings +=", Olives";
            if(chkGreenPeppers.Checked)
                sToppings += ", Green Peppers";
            if(sToppings.StartsWith(","))
                sToppings = sToppings.Substring(1,sToppings.Length-1).Trim();
            if(sToppings=="")
                sToppings = "No Toppings";

            lblToppings.Text = sToppings;
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }
        }

        void UpdateCrustType()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }
            if (rbThinkCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }
        }

        void UpdateSize()
        {
            UpdateTotalPrice();
            if(rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if(rbMeduim.Checked)
            {
               lblSize.Text = "Medium";
                return;
            }

            if(rbLarg.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }

        void ResetForm()
        {
            
            chkExtraChees.Checked = false;
            chkMushrooms.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;
            chkOlives.Checked = false;
            chkGreenPeppers.Checked = false;
            btnOrderPizza.Enabled = true;
            gbCrustType.Enabled = true;
            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            rbMeduim.Checked = true;
            rbThinCrust.Checked = true;
            rbEatIn.Checked = true;
            nudHowMuch.Value = nudHowMuch.Minimum;
            UpdateTotalPrice();

        }

        void UpdateOrederSummery()
        {
            UpdateSize();
            UpdateCrustType();
            UpdateToppings();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rbLarg_Changed(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to place the order?",
                 "Order Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Your order has been placed successfully!", "Order Confirmation",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
               btnOrderPizza.Enabled=false;
                gbCrustType.Enabled = false;
                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbWhereToEat.Enabled = false;
            }
            else
            {
                MessageBox.Show("Your order has been canceled.", "Order Canceled",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

              
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
           UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            UpdateOrederSummery();
        }

        private void nudHowMuch_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }
    }
}
