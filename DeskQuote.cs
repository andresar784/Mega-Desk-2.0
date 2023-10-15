using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk_Rodriguez
{
    public class DeskQuote

    {
        private static double[,] rushOrderPrices;

         public string CustomerName { get; set; }
    public int Depth { get; set; }
    public int Width { get; set; }
    public string Material { get; set; }
    public int Drawers { get; set; }
    public decimal TotalPrice { get; set; }


        public static double[,] GetRushOrders(string filePath)
        {
            try
            {
                string[] allLines = File.ReadAllLines(filePath);

                if (allLines.Length < 9)
                {
                    throw new Exception("Insufficient data in the file for rush order prices." + allLines.Length);
                }
                rushOrderPrices = new double[3, 3];
                int index = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        // Convert the string to a double and assign to the array
                        rushOrderPrices[i, j] = double.Parse(allLines[index]);
                        index++;
                    }
                   
                }
                return rushOrderPrices;
                //Console.WriteLine(rushOrderPrices[1, 1]);
            }
           
            catch (Exception ex)
            {
                Console.WriteLine("Error reading rush order prices: " + ex.Message);
            }
            return null;
        }
        
    }
}

