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
                System.Windows.Forms.MessageBox.Show("Market data file access permission denied.");
            }
        }

        // Method to evolve set of traders
        // Saves network weights and records folio results for best trader
        public List<float> RunEvolution(int generations, int genSize, float mutationRate)
        {
            // Initialize population of traders
            traders = new List<StockTrader>(genSize);
            for (int i = 0; i < genSize; i++)
            {
                traders.Add(new StockTrader(fundStartValue));
            }

            // Loop through all generations
            for (int i = 0; i < generations; i++)
            {
                // Run current generation through full market history
                Dictionary<int, int> traderToGlobalIndexLegend = new Dictionary<int, int>(stockPrices[0].Length);
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
                // Determine population fitness range and weights
                float popMinFitness = Single.MaxValue;
                float popMaxFitness = Single.MinValue;
                foreach (StockTrader trader in traders)
                {
                    if (popMinFitness < trader.PortfolioValue)
                    {
                        popMinFitness = trader.PortfolioValue;
                    }
                    if (popMaxFitness > trader.PortfolioValue)
                    {
                        popMaxFitness = trader.PortfolioValue;
                    }
                }
                // Evaluate and Breed all generation members
                BreedTraders(popMinFitness, popMaxFitness);
            }

            // Identify best trader and record results
            StockTrader bestTrader = traders[0];
            foreach (StockTrader trader in traders)
            {
                if (trader.PortfolioValue > bestTrader.PortfolioValue)
                {
                    bestTrader = trader;
                }
            }
            // Run bestTrader through full market history
            bestTrader = bestTrader.Breed(bestTrader, fundStartValue);
            List<float> bestTraderValueHistory = new List<float>(stockPrices.Count);
            Dictionary<int, int> bestTraderToGlobalIndexLegend = new Dictionary<int, int>(stockPrices[0].Length);
            for (int j = 0; j < stockPrices.Count; j++)
            {
                bestTraderValueHistory.Add(bestTrader.PortfolioValue);
                // Update market with current values
                List<float> traderInputs = new List<float>(stockPrices[0].Length);
                for (int k = 0; k < bestTraderToGlobalIndexLegend.Keys.Count; k++)
                {
                    if (stockPrices[j][bestTraderToGlobalIndexLegend[k]] != 0.0f)
                    {
                        traderInputs.Add(stockPrices[j][bestTraderToGlobalIndexLegend[k]]);
                    }
                    else
                    {
                        bestTraderToGlobalIndexLegend.Remove(k);
                        foreach (StockTrader trader in traders)
                        {
                            trader.RemoveStock(k);
                        }
                    }
                }
                for (int k = 0; k < stockPrices[j].Length; k++)
                {
                    if (stockPrices[j][k] != 0.0f && !bestTraderToGlobalIndexLegend.Values.Contains(k))
                    {
                        bestTraderToGlobalIndexLegend.Add(traderInputs.Count, k);
                        traderInputs.Add(stockPrices[j][k]);
                    }
                }
                // Obtain trader behavior, execute trades, and apply new learning
                bestTrader.Learn(bestTrader.Trade(traderInputs, perTradeFee));
            }
            bestTraderValueHistory.Add(bestTrader.PortfolioValue);
            return bestTraderValueHistory;
        }

        // Method to evaluate fitness of traders
        private void BreedTraders(float minFitness, float maxFitness)
        {
            List<StockTrader>  childTraders = new List<StockTrader>(traders.Count);
            Random random = new Random();
            List<float> breedChances = new List<float>(traders.Count);
            float t = 0.0f;
            foreach (StockTrader trader in traders)
            {
                breedChances.Add(t + (trader.PortfolioValue - minFitness) / (maxFitness - minFitness));
                t += breedChances.Last();
            }
            for (int i = 0; i < traders.Count; i++)
            {
                float breedticket1 = t * (float)random.NextDouble();
                float breedticket2 = t * (float)random.NextDouble();
                for (int j = 0; j < traders.Count; j++)
                {
                    if (breedChances[j] > breedticket1)
                    {
                        for (int k = 0; k < traders.Count; k++)
                        {
                            if (breedChances[k] > breedticket2)
                            {
                                childTraders.Add(traders[j].Breed(traders[k], fundStartValue));
                                continue;
                            }
                        }
                        continue;
                    }
                }
            }
            traders = childTraders;
        }
    }
}
