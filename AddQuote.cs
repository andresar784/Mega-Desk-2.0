using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Rodriguez
{
    public partial class AddQuote : Form
    {
        private decimal laminatedPrice = 100; 
        private decimal oakPrice = 200; 
        private decimal rosewoodPrice = 300; 
        private decimal veneerPrice = 150; 
        private decimal pinePrice = 50; 
        private decimal drawerPricePerDrawer = 50; 
        private decimal threeDaysRushSurcharge = 50m; 
        private decimal fiveDaysRushSurcharge = 30m; 
        private decimal sevenDaysRushSurcharge = 20m; 
        private decimal fourteenDaysRushSurcharge = 10m;

        public AddQuote()
        {
            InitializeComponent();

            date.Text = DateTime.Now.ToShortDateString();

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider.ContainerControl = this;

            width.Validating += Width_Validating;
            depth.KeyPress += Depth_KeyPress;
            FormClosing += AddQuote_FormClosing;

            material.DataSource = Enum.GetValues(typeof(Desk.DesktopMaterial));
            for (int i = 1; i <= 7; i++)
            {
                drawers.Items.Add(i);
            }
            
        }
        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                // When the 'Create Order' button is clicked, calculate the total price
                decimal price = CalculateTotalPrice();

                DisplayQuote displayQuote = new DisplayQuote();
                displayQuote.CustomerName = customer.Text;
                displayQuote.Depth = Convert.ToInt32(depth.Text);
                displayQuote.Width = Convert.ToInt32(width.Text);
                displayQuote.Material = material.Text;
                displayQuote.Drawers = Convert.ToInt32(drawers.Text);
                displayQuote.TotalPrice = price;

                displayQuote.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while processing data: " + ex.Message);
            }

        }
      
        private bool isFormClosing = false;
        private void Width_Validating(object sender, CancelEventArgs e)
        {
            if (isFormClosing)
            {
                return;
            }

            if (!int.TryParse(width.Text, out int widthValue))
             {
                MessageBox.Show("Please enter a valid integer for width.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            if (widthValue < Desk.MinWidth || widthValue > Desk.MaxWidth)
            {
                MessageBox.Show($"Width must between {Desk.MinWidth} and {Desk.MaxWidth}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(width, null);
            }

        }
        
        private void AddQuote_FormClosing(object sender, FormClosingEventArgs e)
        {
            isFormClosing = true;
        }
        private void Depth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a control character
            if (char.IsControl(e.KeyChar))
            {
                // Allow control characters (e.g., backspace) to be pressed
                return;
            }

            // Combine the current text without the pressed key with the pressed key to get the full value
            string fullValue = depth.Text.Remove(depth.SelectionStart, depth.SelectionLength) + e.KeyChar;

            // If the TextBox is empty after adding the new character, allow the key press
            if (string.IsNullOrEmpty(fullValue))
            {
                return;
            }

            if (fullValue == "-" && e.KeyChar == '-')
            {
                return;
            }
            if (fullValue.Length == 1)
            {
                return;
            }

            // Try parsing the full value to an integer
            if (!int.TryParse(fullValue, out int depthValue))
            {
                // If parsing fails, suppress the key press
                e.Handled = true;
                ShowValidationMessage("Please enter a valid integer for depth.");
                return;
            }

            // Check if the depth is within the valid range
            if (depthValue < Desk.MinDepth || depthValue > Desk.MaxDepth)
            {
                // If not in range, suppress the key press
                e.Handled = true;
                ShowValidationMessage($"Depth must be between {Desk.MinDepth} and {Desk.MaxDepth}.");
                return;
            }

            // If the input is valid, clear any error messages
            errorProvider.SetError(depth, null);
        }

        private void ShowValidationMessage(string message)
        {
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            errorProvider.SetError(depth, message);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
        }
        private decimal CalculateBasePrice()
        {
            decimal basePrice = 200;

            // Calculate base price based on desk size and material
            Desk.DesktopMaterial selectedMaterial = (Desk.DesktopMaterial)material.SelectedItem;
            int deskWidth = Convert.ToInt32(width.Text); 
            int deskDepth = Convert.ToInt32(depth.Text);
            
            switch (selectedMaterial)
            {
                case Desk.DesktopMaterial.Laminated:
                    basePrice += (deskWidth * deskDepth + laminatedPrice);
                    break;
                case Desk.DesktopMaterial.Oak:
                    basePrice += (deskWidth * deskDepth + oakPrice);
                    break;
                case Desk.DesktopMaterial.Rosewood:
                    basePrice += (deskWidth * deskDepth + rosewoodPrice);
                    break;
                case Desk.DesktopMaterial.Veneer:
                    basePrice += (deskWidth * deskDepth + veneerPrice);
                    break;
                case Desk.DesktopMaterial.Pine:
                    basePrice += (deskWidth * deskDepth + pinePrice);
                    break;
            }

            // Calculate base price based on the number of drawers
            int numDrawers = Convert.ToInt32(drawers.Text); // replace with your actual control
            basePrice += (numDrawers * drawerPricePerDrawer);

            return basePrice;
        }

        private decimal CalculateRushSurcharge()
        {
            // Calculate surcharge based on rush order option
            int rushOrder = Convert.ToInt32(rush.Text);

            switch (rushOrder)
            {
                case 3:
                    return threeDaysRushSurcharge;
                case 5:
                    return fiveDaysRushSurcharge;
                case 7:
                    return sevenDaysRushSurcharge;
                default:
                    return fourteenDaysRushSurcharge;
            }
        }
        //To send data between event

        private decimal CalculateTotalPrice()
        {
            // Calculate the total price of the desk quote
            decimal basePrice = CalculateBasePrice();
            decimal surcharge = CalculateRushSurcharge();

            // Calculate the total price including the rush order surcharge
            decimal totalPrice = basePrice + surcharge;
            //Console.WriteLine(totalPrice);
            return totalPrice;
        }
        
    }
}