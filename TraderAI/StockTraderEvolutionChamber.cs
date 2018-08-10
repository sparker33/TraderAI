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
                System.Windows.Forms.MessageBox.Show("Market data file access permission denied.");
            }
        }

        // Method to evolve set of traders
        // Saves network weights and records folio results for best trader
        public void RunEvolution(int generations, int genSize, float mutationRate)
        {
            // Initialize population of traders
            traders = new List<StockTrader>(genSize);
            for (int i = 0; i < genSize; i++)
            {
                traders.Add(new StockTrader(10000.00f));
            }

            // Loop through all generations
            for (int i = 0; i < generations; i++)
            {
                Dictionary<int, int> traderToGlobalIndexLegend = new Dictionary<int, int>(stockPrices[0].Length);
                // Run current generation through full market history
                for (int j = 0; j < stockPrices.Count; j++)
                {
                    // Update market with current values
                    List<float> traderInputs = new List<float>(stockPrices[0].Length);
                    for (int k = 0; k < traderToGlobalIndexLegend.Keys.Count; k++)
                    {
                        if (stockPrices[j][traderToGlobalIndexLegend[k]] != 0.0f)
                        {
                            traderInputs.Add(stockPrices[j][traderToGlobalIndexLegend[k]]);
                        }
                        else
                        {
                            traderToGlobalIndexLegend.Remove(k);
                            foreach (StockTrader trader in traders)
                            {
                                trader.RemoveStock(k);
                            }
                        }
                    }
                    for (int k = 0; k < stockPrices[j].Length; k++)
                    {
                        if (stockPrices[j][k] != 0.0f && !traderToGlobalIndexLegend.Values.Contains(k))
                        {
                            traderToGlobalIndexLegend.Add(traderInputs.Count, k);
                            traderInputs.Add(stockPrices[j][k]);
                        }
                    }
                    // Obtain trader behaviors, execute their trades, and apply new learning
                    foreach (StockTrader trader in traders)
                    {
                        trader.Learn(trader.Trade(traderInputs, perTradeFee));
                    }
                }
                // Evaluate performance of all generation members
                EvaluateTraders();
                // Breed traders to generate next generation
                BreedTraders();
            }

            // Identify best trader and record results
            //reserved
        }

        // Method to evaluate fitness of traders
        private void EvaluateTraders()
        {

        }

        // Method to evaluate fitness of traders
        private void BreedTraders()
        {

        }
    }
}
