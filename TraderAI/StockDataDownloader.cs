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
        // pulls data from google
        public StockDataDownloader(string fileName, int exchangesHeaderIndex, int tickersHeaderIndex, DateTime startDate, DateTime endDate)
        {
            // Retrieve data
            WebClientForStockFinanceHistory downloaderClient = new WebClientForStockFinanceHistory();
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    string[] values;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        values = line.Split(',');
                        tickerSymbols.Add(values[tickersHeaderIndex]);
                        stockDataDictionaries.Add(downloaderClient.getStockDataFromGoogle(values[exchangesHeaderIndex], tickerSymbols.Last(), startDate, endDate));
                    }
                }
            }

            // Populate orderedDates
            DateTime dt = startDate;
            while (dt <= endDate)
            {
                orderedDates.Add(dt);
                dt = dt.AddDays(1);
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
                        line[j + 1] = stockDataDictionaries[j][orderedDates[i]].ToString();
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
                        writer.Write(dataLine[i] + ", ");
                    }
                    writer.Write(dataLine[dataLine.Length - 1]);
                    writer.Write("\r\n");
                }
            }
        }
    }
}
