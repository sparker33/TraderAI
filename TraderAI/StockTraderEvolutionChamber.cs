using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MatrixMath;

namespace TraderAI
{
    public class StockTraderEvolutionChamber
    {
		// Private objects
		private PredictionGenerator predictor;
        private List<StockTrader> traders;
        private List<float[]> stockPrices = new List<float[]>();
		List<int> order = new List<int>();
		private float perTradeFee;
        private const float fundStartValue = 10000.00f;

        // Public objects
        //reserved

        // Default Class Constructor
        public StockTraderEvolutionChamber(string futureMarketDataFilePath, string trainingDataFilePath, float tradeCost)
        {
            perTradeFee = tradeCost;
			try
            {
                using (FileStream stream = new FileStream(futureMarketDataFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
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
								if ((prices[i - 1] != 0.0f) && (!order.Contains(i - 1)))
								{
									order.Add(i - 1);
								}
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

			predictor = new PredictionGenerator(trainingDataFilePath);
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
			for (int i = 1; i < stockPrices.Count; i++)
			{
				Vector currentPctChgs = new Vector(stockPrices[i].Count());
				for (int j = 0; j < stockPrices[i].Count(); j++)
				{
					currentPctChgs[j] = (stockPrices[i][j] - stockPrices[i - 1][j]) / stockPrices[i - 1][j];
				}
				predictor.GetNextPrediction(currentPctChgs);
				predictor.RemoveOldestData();
			}
			predictor.WriteDataToCSV(MainForm.DEFAULTDIRECTORY + "\\PredictorData_" + DateTime.Now.Minute.ToString() + ".csv");
			return new List<float>();
        }
    }
}
