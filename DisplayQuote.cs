using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Rodriguez
{
    public partial class DisplayQuote : Form
    {
        public string CustomerName { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public string Material { get; set; }
        public int Drawers { get; set; }
        public decimal TotalPrice { get; set; }
        
        public DisplayQuote()
        {
            InitializeComponent();
        }
        private void DisplayQuote_Load(object sender, EventArgs e)
        {
            
            // Access properties and display information
            customer.Text = $"Customer Name: {CustomerName}";
            depth.Text = $"Depth: {Depth}";
            width.Text = $"Width: {Width}";
            material.Text = $"Material: {Material}";
            drawers.Text = $"Drawers: {Drawers}";
            price.Text = $"Total Price: {TotalPrice:C}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
