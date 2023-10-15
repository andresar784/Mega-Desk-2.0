using Newtonsoft.Json;
using System;
using System.IO;
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
    public partial class SearchQuotes : Form
    {
        public SearchQuotes()
        {
            InitializeComponent();

            List<Desk.DesktopMaterial> materials = Enum.GetValues(typeof(Desk.DesktopMaterial))
                                                .Cast<Desk.DesktopMaterial>()
                                                .ToList();
            searchComboBox.DataSource = materials;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            this.Close();
        }

        private void searchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Desk.DesktopMaterial selectedMaterial = (Desk.DesktopMaterial)searchComboBox.SelectedItem;

            // Load all quotes
            string jsonFilePath = @"quotes.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            List<DeskQuote> allQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(jsonData);

            // Filter quotes based on selected surface material
            var filteredQuotes = allQuotes.Where(q => q.Material == selectedMaterial.ToString()).ToList();

            // Display the filtered quotes in DataGridView
            searchDataGridView.DataSource = filteredQuotes;
        }
    }
}
