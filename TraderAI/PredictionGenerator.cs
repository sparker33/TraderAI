using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MatrixMath;

namespace TraderAI
{
	public class PredictionGenerator
	{
		// Private and Protected objects
		private List<string> printoutHeaderData = new List<string>();
		private List<List<Matrix>> referenceHistories = new List<List<Matrix>>();
		private DateTime startDate;
		private TimeSpan interval;
		private List<float[]> predictedPrices = new List<float[]>();

		// Public objects
		//reserved

		/// <summary>
		/// Default class constructor; not intended for general use.
		/// </summary>
		private PredictionGenerator()
		{
		}

		/// <summary>
		/// Class constructor with path to reference data.
		/// </summary>
		public PredictionGenerator(string stockDataFilePath)
		{
			List<float[]> historicalPrices = new List<float[]>();
			List<int> order = new List<int>();
			try
			{
				using (FileStream stream = new FileStream(stockDataFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						// Initialize the full market
						string[] rawHeaderData;
						string line = reader.ReadLine();
						rawHeaderData = line.Split(',');
						printoutHeaderData.Add(rawHeaderData[0]);
						// Populate the history of market values that will be used
						DateTime date1 = new DateTime();
						DateTime date2 = new DateTime();
						string[] values;
						while (!reader.EndOfStream)
						{
							line = reader.ReadLine();
							values = line.Split(',');
							date2 = date1;
							date1 = DateTime.Parse(values[0].ToString());
							float[] prices = new float[values.Length - 1];
							for (int i = 1; i < values.Length; i++)
							{
								prices[i - 1] = Single.Parse(values[i]);
								if ((prices[i - 1] != 0.0f) && (!printoutHeaderData.Contains(rawHeaderData[i])))
								{
									order.Add(i - 1);
									printoutHeaderData.Add(rawHeaderData[i]);
								}
							}
							historicalPrices.Add(prices);
						}
						interval = date2 - date1;
					}
				}
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Stock Data History file format incorrect.");
			}

			// Populate the historic percent change data matrices from historic price data
			for (int i = 0; i < historicalPrices.Count; i++)
			{
				referenceHistories.Add(new List<Matrix>());
				for (int n = 0; n < referenceHistories.Count(); n++)
				{
					referenceHistories[n].Insert(0, new Matrix(order.Count(), n + 1));
					for (int j = i - n; j < i + 1; j++)
					{
						for (int k = 0; k < order.Count(); k++)
						{
							referenceHistories[n][0][k][i - j] = historicalPrices[j][order[k]];
						}
					}
				}
			}
		}

		/// <summary>
		/// Populates this PredictionGenerator's predictions from start Date to end Date
		/// based on historical data collected on class constructions.
		/// </summary>
		/// <param name="start"> Date of first prediction. </param>
		/// <param name="end"> Date of last prediction. </param>
		public void GeneratePredictions(DateTime start, DateTime end)
		{
			startDate = start;

			// run proceedural generation of predictions.
		}

		/// <summary>
		/// Method enabling data writeout to csv
		/// </summary>
		/// <param name="path"> File path to write into. </param>
		public void WriteDataToCSV(string path)
		{
			// Set up list of data to write
			List<string[]> dataToWrite = new List<string[]>();

			// Create list of output strings in csv format
			// Add header line
			dataToWrite.Add(printoutHeaderData.ToArray());
			// Add data lines
			DateTime predictionDate = startDate;
			for (int i = 0; i < predictedPrices.Count; i++)
			{
				string[] line = new string[printoutHeaderData.Count()];
				line[0] = predictionDate.ToShortDateString();

				for (int j = 0; j < printoutHeaderData.Count() - 1; j++)
				{
					try
					{
						line[j + 1] = predictedPrices[i][j].ToString();
					}
					catch (ArgumentOutOfRangeException)
					{
						line[j + 1] = "0.00";
					}
				}
				dataToWrite.Add(line);
				predictionDate.Add(interval);
			}

			// Write to file
			using (StreamWriter writer = new StreamWriter(path))
			{
				foreach (string[] dataLine in dataToWrite)
				{
					for (int i = 0; i < dataLine.Length - 1; i++)
					{
						writer.Write(dataLine[i] + ",");
					}
					writer.Write(dataLine[dataLine.Length - 1]);
					writer.Write("\r\n");
				}
			}
		}
	}
}
