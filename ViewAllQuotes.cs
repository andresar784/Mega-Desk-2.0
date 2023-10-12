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
    public partial class ViewAllQuotes : Form
    {

        public ViewAllQuotes()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }
    }
}
