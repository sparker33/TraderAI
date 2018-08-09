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
            "http://www.google.com/finance/historical?q=[-|ticker|-]&startdate=[-|sdate|-]&enddate=[-|edate|-]&output=csv";

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

                        float tempOpen;

                        if (Single.TryParse(splitLine[1], out tempOpen))
                        {
                            newItem.open = tempOpen;
                        }

                        float tempHigh;

                        if (Single.TryParse(splitLine[2], out tempHigh))
                        {
                            newItem.high = tempHigh;
                        }

                        float tempLow;

                        if (Single.TryParse(splitLine[3], out tempLow))
                        {
                            newItem.low = tempLow;
                        }

                        float tempClose;

                        if (Single.TryParse(splitLine[4], out tempClose))
                        {
                            newItem.close = tempClose;
                        }

                        float tempVolume;

                        if (Single.TryParse(splitLine[5], out tempVolume))
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
