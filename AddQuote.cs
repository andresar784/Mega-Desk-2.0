using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
       
        private double[,] rushOrderPrices;

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

            List<Desk.DesktopMaterial> materials = Enum.GetValues(typeof(Desk.DesktopMaterial))
                                                .Cast<Desk.DesktopMaterial>()
                                                .ToList();
            material.DataSource = materials;

            //material.DataSource = Enum.GetValues(typeof(Desk.DesktopMaterial));
            for (int i = 1; i <= 7; i++)
            {
                drawers.Items.Add(i);
            }

            rush.Items.AddRange(new object[] { "Normal (14 days)", "Rush 3 days", "Rush 5 days", "Rush 7 days" });
            rush.SelectedIndex = 0;

            string filePath = "C:\\BYU-I\\CSE-325\\MegaDesk Rodriguez\\rushOrderFile.txt";

            DeskQuote deskQuote = new DeskQuote();
            rushOrderPrices = DeskQuote.GetRushOrders(filePath);
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
         private int CalculateSurfaceArea()
        {
            int deskWidth = Convert.ToInt32(width.Text);
            int deskDepth = Convert.ToInt32(depth.Text);

            int area = deskDepth * deskDepth;
            return area;
        }
        private decimal CalculateBasePrice()
        {
            decimal basePrice = 200;
            int area = CalculateSurfaceArea();
            // Calculate base price based on desk size and material
            Desk.DesktopMaterial selectedMaterial = (Desk.DesktopMaterial)material.SelectedItem;
            
            switch (selectedMaterial)
            {
                case Desk.DesktopMaterial.Laminated:
                    basePrice += (area + laminatedPrice);
                    break;
                case Desk.DesktopMaterial.Oak:
                    basePrice += (area + oakPrice);
                    break;
                case Desk.DesktopMaterial.Rosewood:
                    basePrice += (area + rosewoodPrice);
                    break;
                case Desk.DesktopMaterial.Veneer:
                    basePrice += (area + veneerPrice);
                    break;
                case Desk.DesktopMaterial.Pine:
                    basePrice += (area + pinePrice);
                    break;
            }

            // Calculate base price based on the number of drawers
            int numDrawers = Convert.ToInt32(drawers.Text); 
            basePrice += (numDrawers * drawerPricePerDrawer);

            return basePrice;
        }

        private decimal CalculateRushSurcharge()
        {
            try
            {
                string selectedOption = rush.SelectedItem.ToString();
                int rushOrder = ExtractDays(selectedOption);
                int area = CalculateSurfaceArea();

                // Calculate surcharge based on rush order option and area
                if (area < 1000)
                {
                    switch (rushOrder)
                    {
                        case 3:
                            return Convert.ToDecimal(rushOrderPrices[0, 0]); 
                        case 5:
                            return Convert.ToDecimal(rushOrderPrices[1, 0]); 
                        case 7:
                            return Convert.ToDecimal(rushOrderPrices[2, 0]); 
                        default:
                            return Convert.ToDecimal(rushOrderPrices[1, 0]); 
                    }
                }
                else if (area >= 1000 && area <= 2000)
                {
                    switch (rushOrder)
                    {
                        case 3:
                            return Convert.ToDecimal(rushOrderPrices[0, 1]); 
                        case 5:
                            return Convert.ToDecimal(rushOrderPrices[1, 1]); 
                        case 7:
                            return Convert.ToDecimal(rushOrderPrices[2, 1]); 
                        default:
                            return Convert.ToDecimal(rushOrderPrices[2, 1]); 
                    }
                }
                else // Area is greater than 2000
                {
                    switch (rushOrder)
                    {
                        case 3:
                            return Convert.ToDecimal(rushOrderPrices[0, 2]); 
                        case 5:
                            return Convert.ToDecimal(rushOrderPrices[1, 2]); 
                        case 7:
                            return Convert.ToDecimal(rushOrderPrices[1, 0]); 
                        default:
                            return Convert.ToDecimal(rushOrderPrices[0, 0]); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error calculating rush surcharge: " + ex.Message);
                return 0; 
            }
        }

        private int ExtractDays(string option)
        {
            string[] words = option.Split(' ');
            foreach (string word in words)
            {
                if (int.TryParse(word, out int days))
                {
                    return days;
                }
            }
            return 14; // Default  14 
        }

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

        private void saveDesk(object sender, EventArgs e)
        {
            try
            {
                decimal price  = CalculateTotalPrice();
                DeskQuote deskQuote = new DeskQuote()
                {
                    CustomerName = customer.Text,
                    Depth = Convert.ToInt32(depth.Text),
                    Width = Convert.ToInt32(width.Text),
                    Material = material.Text,
                    Drawers = Convert.ToInt32(drawers.Text),
                    TotalPrice = price,
                };
                SaveDeskQuoteToJson(deskQuote);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error while processing data: {ex.Message}");
            }
        }
        private void SaveDeskQuoteToJson(DeskQuote deskQuote)
        {
            try
            {
                // Specify the path for the JSON file
                string filePath = "C:\\BYU-I\\CSE-325\\MegaDesk Rodriguez\\quotes.json";

                // Initialize a new list to store quotes
                List<DeskQuote> allQuotes;

                // Check if the file exists
                if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
                {
                    // Read existing quotes from the file
                    string json = File.ReadAllText(filePath);

                    // Try to deserialize as a list
                    try
                    {
                        allQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(json);
                    }
                    catch (JsonSerializationException)
                    {
                        // If deserialization as a list fails, check if it's an empty object
                        try
                        {
                            var singleQuote = JsonConvert.DeserializeObject<DeskQuote>(json);
                            allQuotes = new List<DeskQuote> { singleQuote };
                        }
                        catch (JsonSerializationException)
                        {
                            // If deserialization as a single object also fails, initialize an empty list
                            allQuotes = new List<DeskQuote>();
                        }
                    }
                }
                else
                {
                    allQuotes = new List<DeskQuote>();
                }

                // Add the new quote to the list
                allQuotes.Add(deskQuote);

                // Serialize the list of quotes and save to the file
                string serializedQuotes = JsonConvert.SerializeObject(allQuotes, Formatting.Indented);
                File.WriteAllText(filePath, serializedQuotes);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving quote to JSON: " + ex.Message);
            }
        }
    }
}
