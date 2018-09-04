using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraderAI
{
    public class StockTraderEvolutionChamber
    {
        // Private objects
        private List<StockTrader> traders;
        private List<float[]> stockPrices = new List<float[]>();
        private float perTradeFee;
        private const float fundStartValue = 10000.00f;

        // Public objects
        //reserved

        // Default Class Constructor
        public StockTraderEvolutionChamber(string marketDataFilePath, float tradeCost)
        {
            perTradeFee = tradeCost;
            try
            {
                using (FileStream stream = new FileStream(marketDataFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        // Initialize the full market
                        string line = reader.ReadLine();
                        string[] values = line.Split(',');
                        // Populate the history of market values that will be used
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            values = line.Split(',');
                            float[] prices = new float[values.Length - 1];
                            for (int i = 1; i < values.Length; i++)
                            {
                                prices[i - 1] = Single.Parse(values[i]);
                            }
                            stockPrices.Add(prices);
                        }
                    }
                }
            }
            catch (Exception)
            {
				System.Windows.Forms.MessageBox.Show("Stock Data History file format incorrect.");
            }
        }

		/// <summary>
		/// Method to evolve set of traders. 
		/// </summary>
		/// <param name="generations"> Number of generations to evolve over. </param>
		/// <param name="genSize"> Number of traders in each generation. </param>
		/// <param name="mutationRate"> Decimal random mutation rate. </param>
		/// <returns> List of portfolio values over time for the most successful trader of the final generation. </returns>
		public List<float> RunEvolution(int generations, int genSize, float mutationRate)
        {
			return new List<float>();
        }
    }
}
