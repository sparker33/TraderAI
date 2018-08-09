using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace TraderAI
{
    /*
     Credit to Scott Waldron
     TheWayOfCoding.com
     See his terms of use here:
     https://github.com/TheWayOfCoding/tutorialsandsnippets/blob/master/CSharp/WebClientExample/WebClientExample/WebClientForGoogleFinanceHistoric.cs
     */

    public class WebClientForStockFinanceHistory
    {
        WebClient webConnector;
        const string googleAddress =
            "http://www.google.com/finance/historical?q=[-|ticker|-]&startdate=[-|sdate|-]&enddate=[-|edate|-]&num=30&output=csv";

        const string yahooAddress =
            "http://real-chart.finance.yahoo.com/table.csv?s=[-|ticker|-]&[-|sdate|-]&[-|edate|-]&g=d&ignore=.csv";

        public Dictionary<DateTime, StockDataItem> getStockDataFromGoogle(string market, string ticker, DateTime startDate, DateTime endDate)
        {
            return fillDataDictionary(getData(constructGoogleLink(market, ticker, startDate, endDate)));
        }

        string constructGoogleLink(string market, string ticker, DateTime startDate, DateTime endDate)
        {
            string constructedUri = googleAddress;
            constructedUri = constructedUri.Replace("[-|ticker|-]", market + "%3A" + ticker);
            string constructedStartDate = startDate.ToString("MMM") + "+" + startDate.Day.ToString() + "%2C+" + startDate.ToString("yyyy");
            string constructedEndDate = endDate.ToString("MMM") + "+" + endDate.Day.ToString() + "%2C+" + endDate.ToString("yyyy");
            constructedUri = constructedUri.Replace("[-|sdate|-]", constructedStartDate);
            constructedUri = constructedUri.Replace("[-|edate|-]", constructedEndDate);

            return constructedUri;
        }

        public Dictionary<DateTime, StockDataItem> getStockDataFromYahoo(string ticker, DateTime startDate, DateTime endDate)
        {
            return fillDataDictionary(getData(constructYahooLink(ticker, startDate, endDate)));
        }

        string constructYahooLink(string ticker, DateTime startDate, DateTime endDate)
        {
            string constructedUri = yahooAddress;
            constructedUri = constructedUri.Replace("[-|ticker|-]", ticker);
            string constructedStartDate =
                "a=" + (startDate.Month - 1).ToString() +
                "&b=" + startDate.Day.ToString() +
                "&c=" + startDate.Year.ToString();
            string constructedEndDate =
                "d=" + (endDate.Month - 1).ToString() +
                "&e=" + endDate.Day.ToString() +
                "&f=" + endDate.Year.ToString();

            constructedUri = constructedUri.Replace("[-|sdate|-]", constructedStartDate);

            constructedUri = constructedUri.Replace("[-|edate|-]", constructedEndDate);

            return constructedUri;
        }

        string getData(string webpageUriString)
        {
            string tempStorageString = "";

            if (webpageUriString != "")
            {
                using (webConnector = new WebClient())
                {
                    using (Stream responseStream = webConnector.OpenRead(webpageUriString))
                    {
                        using (StreamReader responseStreamReader = new StreamReader(responseStream))
                        {
                            tempStorageString = responseStreamReader.ReadToEnd();

                            tempStorageString = tempStorageString.Replace("\n", Environment.NewLine);
                        }
                    }
                }
            }

            return tempStorageString;
        }

        Dictionary<DateTime, StockDataItem> fillDataDictionary(string csvData)
        {
            Dictionary<DateTime, StockDataItem> parsedStockData = new Dictionary<DateTime, StockDataItem>();

            using (StringReader reader = new StringReader(csvData))
            {
                string csvLine;

                reader.ReadLine();
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] splitLine = csvLine.Split(',');

                    if (splitLine.Length >= 6)
                    {
                        StockDataItem newItem = new StockDataItem();

                        double tempOpen;

                        if (Double.TryParse(splitLine[1], out tempOpen))
                        {
                            newItem.open = tempOpen;
                        }

                        double tempHigh;

                        if (Double.TryParse(splitLine[2], out tempHigh))
                        {
                            newItem.high = tempHigh;
                        }

                        double tempLow;

                        if (Double.TryParse(splitLine[3], out tempLow))
                        {
                            newItem.low = tempLow;
                        }

                        double tempClose;

                        if (Double.TryParse(splitLine[4], out tempClose))
                        {
                            newItem.close = tempClose;
                        }

                        double tempVolume;

                        if (Double.TryParse(splitLine[5], out tempVolume))
                        {
                            newItem.volume = tempVolume;
                        }

                        DateTime tempDate;

                        if (DateTime.TryParse(splitLine[0], out tempDate))
                        {
                            parsedStockData.Add(tempDate, newItem);
                        }
                    }
                }
            }
            return parsedStockData;
        }
    }
}
