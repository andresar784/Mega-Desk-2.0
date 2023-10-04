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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddQuote ViewAddForm = new AddQuote();
            ViewAddForm.Tag = this;
            ViewAddForm.Show();
            Hide();
           
        }

        private void view_Click(object sender, EventArgs e)
        {
            ViewAllQuotes viewAllQuotes = new ViewAllQuotes();
            viewAllQuotes.Tag = this;
            viewAllQuotes.Show();
            Hide();
        }

        private void search_Click(object sender, EventArgs e)
        {
            SearchQuotes searchQuotes = new SearchQuotes(); 
            searchQuotes.Tag = this;
            searchQuotes.Show();
            Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            // Ask for confirmation before exiting
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // User clicked 'Yes', exit the application
                Application.Exit();
            }
            // If 'No' is clicked, the application will not exit
        }
    }
}
