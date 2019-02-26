using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TraderAI
{
    public class StockDataDownloader
    {
        // Private objects
        private List<string> tickerSymbols = new List<string>();
        private List<DateTime> orderedDates = new List<DateTime>();
        private List<Dictionary<DateTime, StockDataItem>> stockDataDictionaries = new List<Dictionary<DateTime, StockDataItem>>();

        // Public objects
        // res

        // Default class constructor (should not be used)
        private StockDataDownloader()
        {
        }

        // Class constructor with file and column heading inputs
        public StockDataDownloader(string folderName)
        {
			string[] files = Directory.GetFiles(folderName, "*.csv", SearchOption.TopDirectoryOnly);
			foreach (string file in files)
			{
				Dictionary<DateTime, StockDataItem> tempDict = new Dictionary<DateTime, StockDataItem>();
				using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						string line = reader.ReadLine();
						string[] values;
						while (!reader.EndOfStream)
						{
							line = reader.ReadLine();
							values = line.Split(',');
							StockDataItem stockDataItem = new StockDataItem();
							stockDataItem.close = Single.Parse(values[5]);
							stockDataItem.low = Single.Parse(values[4]);
							stockDataItem.high = Single.Parse(values[3]);
							stockDataItem.open = Single.Parse(values[2]);
							stockDataItem.volume = Single.Parse(values[6]);
							//DateTime date = new DateTime(Int32.Parse(values[0].Remove(4)), Int32.Parse(values[0].Substring(4).Remove(2)), Int32.Parse(values[0].Substring(6)));
							DateTime date = DateTime.Parse(values[0]);
							tempDict.Add(date, stockDataItem);
						}
						//tickerSymbols.Add(file.Split('_')[1].Split('.')[0]);
						tickerSymbols.Add(file.Split('\\').Last().Split('.')[0]);
						stockDataDictionaries.Add(tempDict);
					}
				}
			}

			// Populate orderedDates
			using (FileStream stream = new FileStream(files[0], FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					string line = reader.ReadLine();
					string[] values;
					//temp code for generating file with only first 500 data entries
					//int temp = 0;
					//while (temp < 500 && !reader.EndOfStream)
					//{
					//	line = reader.ReadLine();
					//	values = line.Split(',');
						//DateTime date = new DateTime(Int32.Parse(values[0].Remove(4)), Int32.Parse(values[0].Substring(4).Remove(2)), Int32.Parse(values[0].Substring(6)));
						//orderedDates.Add(date);
					//	temp++;
					//}
					//end temp code

					while (!reader.EndOfStream)
					{
						line = reader.ReadLine();
						values = line.Split(',');
						//DateTime date = new DateTime(Int32.Parse(values[0].Remove(4)), Int32.Parse(values[0].Substring(4).Remove(2)), Int32.Parse(values[0].Substring(6)));
						DateTime date = DateTime.Parse(values[0]);
						orderedDates.Add(date);
					}
				}
			}

			// Remove extra data
			for (int i = 0; i < orderedDates.Count; i++)
			{
				int j = 0;
				while (j < tickerSymbols.Count)
				{
					if (!stockDataDictionaries[j].ContainsKey(orderedDates[i]))
					{
						tickerSymbols.RemoveAt(j);
						stockDataDictionaries.RemoveAt(j);
					}
					else
					{
						j++;
					}
				}
			}
		}
        
        // Method enabling data writeout to csv
        public void WriteDataToCSV(string path)
        {
            // Set up list of data to write
            List<string[]> dataToWrite = new List<string[]>();

            // Create list of output strings in csv format
            // Add header line
            string[] headerLine = new string[tickerSymbols.Count + 1];
            headerLine[0] = "Date";
            for (int i = 0; i < tickerSymbols.Count; i++)
            {
                headerLine[i + 1] = tickerSymbols[i];
            }
            dataToWrite.Add(headerLine);
            // Add data lines
            for (int i = 0; i < orderedDates.Count; i++)
            {
                string[] line = new string[tickerSymbols.Count + 1];
                line[0] = orderedDates[i].ToShortDateString();

                for (int j = 0; j < tickerSymbols.Count; j++)
                {
                    if (stockDataDictionaries[j].ContainsKey(orderedDates[i]))
                    {
                        line[j + 1] = stockDataDictionaries[j][orderedDates[i]].close.ToString();
                    }
                    else
                    {
                        line[j + 1] = "0.00";
                    }
                }
                dataToWrite.Add(line);
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
