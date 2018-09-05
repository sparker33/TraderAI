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
		public const float NewStockPercent = 99999.9f;

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
						interval = date1 - date2;
						startDate = date2 + interval;
						predictedPrices.Add(historicalPrices.Last());
					}
				}
			}
			catch (Exception)
			{
				System.Windows.Forms.MessageBox.Show("Stock Data History file format incorrect.");
			}

			// Convert price data to percent changes
			List<float[]> percentHistories = new List<float[]>();
			percentHistories.Add(new float[historicalPrices[0].Count()]);
			for (int i = 0; i < historicalPrices[0].Count(); i++)
			{
				if (historicalPrices[0][i] != 0.0f)
				{
					percentHistories.Last()[i] = NewStockPercent;
				}
				else
				{
					percentHistories.Last()[i] = 0.0f;
				}
			}
			for (int i = 1; i < historicalPrices.Count; i++)
			{
				percentHistories.Add(new float[historicalPrices[i].Count()]);
				for (int j = 0; j < historicalPrices[i].Count(); j++)
				{
					if (historicalPrices[i][j] != 0.0f && historicalPrices[i - 1][j] == 0.0f)
					{
						percentHistories.Last()[j] = NewStockPercent;
					}
					else if (historicalPrices[i][j] == 0.0f && historicalPrices[i - 1][j] == 0.0f)
					{
						percentHistories.Last()[j] = 0.0f;
					}
					else
					{
						percentHistories.Last()[j] = (historicalPrices[i][j] - historicalPrices[i - 1][j]) / historicalPrices[i - 1][j];
					}
				}
			}
			// Populate the historical percent change data matrices
			for (int i = 0; i < percentHistories.Count; i++)
			{
				Vector newData = new Vector(percentHistories[i].Count());
				for (int j = 0; j < percentHistories[i].Count(); j++)
				{
					newData.Add(percentHistories[i][order[j]]);
				}
				AddData(newData);
			}
		}

		/// <summary>
		/// Method to add a new data set to this predictor's matrices
		/// </summary>
		/// <param name="newPercentChanges"> Vector of new percent changes.
		/// Vector must be ordered as the existing data (in order of IPO).
		/// </param>
		public void AddData(Vector newPercentChanges)
		{
			// Incorporate any new additions to the market
			if (newPercentChanges.Count > referenceHistories[0][0].Count)
			{
				for (int i = 0; i < referenceHistories.Count; i++)
				{
					for (int j = 0; j < referenceHistories[i].Count; j++)
					{
						referenceHistories[i][j].Add(new Vector(referenceHistories[i][j].ColumnCount));
					}
				}
			}
			else if (newPercentChanges.Count < referenceHistories[0][0].Count)
			{
				System.Windows.Forms.MessageBox.Show("Input newPercentChanges for Predictor's AddData method is too short. Padding with zeros.");
				while (newPercentChanges.Count < referenceHistories[0][0].RowCount)
				{
					newPercentChanges.Add(0.0f);
				}
			}

			// Generate newest set of data matrices
			referenceHistories.Add(new List<Matrix>());
			for (int n = 0; n < referenceHistories.Count; n++)
			{
				referenceHistories[n].Insert(0, new Matrix(newPercentChanges.Count, n + 1));
				for (int k = 0; k < newPercentChanges.Count; k++)
				{
					for (int j = referenceHistories.Count - n; j < referenceHistories.Count; j++)
					{
						referenceHistories[n][0][k][referenceHistories.Count - j] = referenceHistories[referenceHistories.Count - 2][1][k][referenceHistories.Count - j - 1];
					}
					referenceHistories[n][0][k][0] = newPercentChanges[k];
				}
			}
		}

		/// <summary>
		/// Populates this PredictionGenerator's predictions for an input number of time intervals
		/// based on historical data collected on class constructions.
		/// </summary>
		/// <param name="end"> Date of last prediction. </param>
		public void GeneratePredictions(int intervals)
		{
			// *** ADD OPTION TO SWITCH BETWEEN CUMULATIVE PREDICTIONS OR STATIC (do or don't update referenceHistories as predictions are made)? ***
			// Predict percent changes
			//(recursively predict and add data)

			// Convert percent changes to price histories
			//reserved (populate predictedPrices) *** MOVE TO SEPARATE METHOD? ***
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
