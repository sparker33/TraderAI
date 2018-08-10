﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TraderAI
{
    public partial class MainForm : Form
    {
        // Statics
        static string DEFAULTDIRECTORY = "C:\\111\\Periphery";

        // Private fields
        private string selectedFileName;
        private string outputFilePath;
        private BackgroundWorker downloadBackgroundWorker = new BackgroundWorker();
        private BackgroundWorker runBackgroundWorker = new BackgroundWorker();
        private string stockDataPrintoutFile;

        // Public accessors
        //reserved

        public MainForm()
        {
            InitializeComponent();

            downloadBackgroundWorker.DoWork += new DoWorkEventHandler(donwloadWorker_DoWork);
            downloadBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(downloadWorker_RunWorkerCompleted);
            runBackgroundWorker.DoWork += new DoWorkEventHandler(runWorker_DoWork);
            runBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorker_RunWorkerCompleted);
        }

        // Event handler for browsebutton; gets file to read list of tickers to scrape data for
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFileDialog = new OpenFileDialog();
            if (DEFAULTDIRECTORY == String.Empty)
            {
                selectFileDialog.InitialDirectory = "C:\\";
            }
            else
            {
                selectFileDialog.InitialDirectory = DEFAULTDIRECTORY;
            }
            selectFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            selectFileDialog.FilterIndex = 1;

            if (selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFileName = selectFileDialog.FileName;
                tickerListTextBox.Text = selectedFileName;
                DEFAULTDIRECTORY = selectedFileName.Trim().Remove(selectedFileName.LastIndexOf(@"\"));
                outputFilePath = DEFAULTDIRECTORY;

                try
                {
                    using (FileStream stream = new FileStream(selectedFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            string line = reader.ReadLine();
                            string[] values = line.Split(',');
                            exchangeColumnDropDown.Items.AddRange(values);
                            tickerColumnDropDown.Items.AddRange(values);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Access file permission denied.");
                }
            }
        }

        // Method that runs when "Run" button is clicked
        private void downloadButton_Click(object sender, EventArgs e)
        {
            StockDataDownloader downloader = new StockDataDownloader(selectedFileName,
                exchangeColumnDropDown.SelectedIndex,
                tickerColumnDropDown.SelectedIndex,
                startDatePicker.Value,
                endDatePicker.Value);
            downloadButton.Enabled = false;

            downloadBackgroundWorker.RunWorkerAsync(downloader);
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            StockTraderEvolutionChamber chamber = new StockTraderEvolutionChamber(stockDataPrintoutFile, Single.Parse(tradeFeeBox.Text));
            runButton.Enabled = false;

            runBackgroundWorker.RunWorkerAsync(chamber);
        }

        #region DonwloadBackgroundworkerInstructions
        // Async DoWork function
        private void donwloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = DownloadStockData((StockDataDownloader)e.Argument, worker);
        }

        // Async run completed function
        private void downloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Completed Download");
            }
            downloadButton.Enabled = true;
        }

        // Async run helper function
        public bool DownloadStockData(StockDataDownloader downloader, BackgroundWorker worker)
        {
            stockDataPrintoutFile = DEFAULTDIRECTORY + "\\StockData_" + DateTime.Now.Month.ToString() + "-" +
                    DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() +
                    DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".csv";
            downloader.WriteDataToCSV(stockDataPrintoutFile);
            return true;
        }
        #endregion

        #region RunBackgroundworkerInstructions
        // Async DoWork function
        private void runWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            e.Result = EvolveTrader((StockTraderEvolutionChamber)e.Argument, worker);
        }

        // Async run completed function
        private void runWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Completed Run");
            }
            downloadButton.Enabled = true;
        }

        // Async run helper function
        public bool EvolveTrader(StockTraderEvolutionChamber chamber, BackgroundWorker worker)
        {
            chamber.RunEvolution(Int32.Parse(genCountBox.Text), Int32.Parse(genSizeBox.Text), Single.Parse(mutationRateBox.Text));
            return true;
        }
        #endregion
    }
}
