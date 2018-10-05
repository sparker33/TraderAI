using System;
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
        public static string DEFAULTDIRECTORY = "C:\\111\\Periphery";

        // Private fields
        private string outputFilePath;
		private BackgroundWorker evolveBackgroundWorker = new BackgroundWorker();
		private BackgroundWorker predictionBackgroundWorker = new BackgroundWorker();
		private string stockDataPrintoutFile;
		private string trainingDataPrintoutFile;

		// Public accessors
		//reserved

		public MainForm()
        {
            InitializeComponent();

			evolveBackgroundWorker.DoWork += new DoWorkEventHandler(evolveWorker_DoWork);
			evolveBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(evolveWorker_RunWorkerCompleted);
			predictionBackgroundWorker.DoWork += new DoWorkEventHandler(predictionWorker_DoWork);
			predictionBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(predictionWorker_RunWorkerCompleted);
		}

		// Method to handle clicking the Evolve button
		private void evolveButton_Click(object sender, EventArgs e)
		{
			if (stockDataPrintoutFile == null)
			{
				System.Windows.Forms.MessageBox.Show("Please select a formatted future stock data file.");
				OpenFileDialog selectFileDialog = new OpenFileDialog();
				if (DEFAULTDIRECTORY == String.Empty)
				{
					selectFileDialog.InitialDirectory = "C:\\";
				}
				else
				{
					selectFileDialog.InitialDirectory = DEFAULTDIRECTORY;
				}
				selectFileDialog.Filter = "sdp files (*.sdp)|*.sdp";
				selectFileDialog.FilterIndex = 1;

				if (selectFileDialog.ShowDialog() == DialogResult.OK)
				{
					stockDataPrintoutFile = selectFileDialog.FileName;
					DEFAULTDIRECTORY = stockDataPrintoutFile.Trim().Remove(stockDataPrintoutFile.LastIndexOf(@"\"));
					outputFilePath = DEFAULTDIRECTORY;
				}
				else
				{
					return;
				}
			}
			if (trainingDataPrintoutFile == null)
			{
				System.Windows.Forms.MessageBox.Show("Please select a formatted stock training data file.");
				OpenFileDialog selectFileDialog = new OpenFileDialog();
				if (DEFAULTDIRECTORY == String.Empty)
				{
					selectFileDialog.InitialDirectory = "C:\\";
				}
				else
				{
					selectFileDialog.InitialDirectory = DEFAULTDIRECTORY;
				}
				selectFileDialog.Filter = "sdp files (*.sdp)|*.sdp";
				selectFileDialog.FilterIndex = 1;

				if (selectFileDialog.ShowDialog() == DialogResult.OK)
				{
					trainingDataPrintoutFile = selectFileDialog.FileName;
					DEFAULTDIRECTORY = trainingDataPrintoutFile.Trim().Remove(trainingDataPrintoutFile.LastIndexOf(@"\"));
					outputFilePath = DEFAULTDIRECTORY;
				}
				else
				{
					return;
				}
			}

			StockTraderEvolutionChamber chamber = new StockTraderEvolutionChamber(stockDataPrintoutFile, trainingDataPrintoutFile, Single.Parse(tradeFeeBox.Text));
			evolveButton.Enabled = false;

			evolveBackgroundWorker.RunWorkerAsync(chamber);
		}

		// Method to handle clicking the Prediction button
		private void predictionButton_Click(object sender, EventArgs e)
		{
			if (trainingDataPrintoutFile == null)
			{
				System.Windows.Forms.MessageBox.Show("Please select a formatted stock data training file.");
				OpenFileDialog selectFileDialog = new OpenFileDialog();
				if (DEFAULTDIRECTORY == String.Empty)
				{
					selectFileDialog.InitialDirectory = "C:\\";
				}
				else
				{
					selectFileDialog.InitialDirectory = DEFAULTDIRECTORY;
				}
				selectFileDialog.Filter = "sdp files (*.sdp)|*.sdp";
				selectFileDialog.FilterIndex = 1;

				if (selectFileDialog.ShowDialog() == DialogResult.OK)
				{
					trainingDataPrintoutFile = selectFileDialog.FileName;
					DEFAULTDIRECTORY = trainingDataPrintoutFile.Trim().Remove(trainingDataPrintoutFile.LastIndexOf(@"\"));
					outputFilePath = DEFAULTDIRECTORY;
				}
				else
				{
					return;
				}
			}

			PredictionGenerator predictor = new PredictionGenerator(trainingDataPrintoutFile);
			predictionButton.Enabled = false;

			predictionBackgroundWorker.RunWorkerAsync(predictor);
		}
		
		#region RunBackgroundworkerInstructions
		// Async DoWork function
		private void evolveWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			e.Result = EvolveTrader((StockTraderEvolutionChamber)e.Argument, worker);
		}

		// Async run completed function
		private void evolveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else
			{
				MessageBox.Show("Completed Run");
			}
			evolveButton.Enabled = true;
		}

		// Async run helper function
		public bool EvolveTrader(StockTraderEvolutionChamber chamber, BackgroundWorker worker)
		{
			List<float> bestTraderData = new List<float>(chamber.RunEvolution(Int32.Parse(genCountBox.Text), Int32.Parse(genSizeBox.Text), Single.Parse(mutationRateBox.Text)));
			// Write bestTrader history results to file
			using (StreamWriter writer = new StreamWriter(DEFAULTDIRECTORY + "\\BestTraderPerformance_" + DateTime.Now.Month.ToString() + "-" +
					DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() +
					DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".csv"))
			{
				writer.Write("PortfolioValue\r\n");
				foreach (float d in bestTraderData)
				{
					writer.Write(d.ToString() + "\r\n");
				}
			}
			return true;
		}
		#endregion

		#region PredictionBackgroundworkerInstructions
		// Async DoWork function
		private void predictionWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker worker = sender as BackgroundWorker;

			e.Result = GeneratePrediction((PredictionGenerator)e.Argument, worker);
		}

		// Async run completed function
		private void predictionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				MessageBox.Show(e.Error.Message);
			}
			else
			{
				MessageBox.Show("Completed Predictions");
			}
			predictionButton.Enabled = true;
		}

		// Async run helper function
		public bool GeneratePrediction(PredictionGenerator predictor, BackgroundWorker worker)
		{
			predictor.RecursiveGetPredictions(Int32.Parse(predictIntervalsBox.Text));
			string predictionDataPrintoutFile = DEFAULTDIRECTORY + "\\PredictionData_" + DateTime.Now.Month.ToString() + "-" +
					DateTime.Now.Day.ToString() + "-" + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Hour.ToString() +
					DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + ".csv";
			predictor.WriteDataToCSV(predictionDataPrintoutFile);
			return true;
		}
		#endregion

		private void dataFormatButton_Click(object sender, EventArgs e)
		{
			string selectedFolder;
			System.Windows.Forms.MessageBox.Show("Please select a folder with raw stock data files.");
			FolderBrowserDialog selectFolderDialog = new FolderBrowserDialog();
			if (DEFAULTDIRECTORY == String.Empty)
			{
				selectFolderDialog.SelectedPath = "C:\\";
			}
			else
			{
				selectFolderDialog.SelectedPath = DEFAULTDIRECTORY;
			}

			if (selectFolderDialog.ShowDialog() == DialogResult.OK)
			{
				selectedFolder = selectFolderDialog.SelectedPath;
				DEFAULTDIRECTORY = selectedFolder.Remove(selectedFolder.LastIndexOf(@"\"));
				outputFilePath = DEFAULTDIRECTORY;
			}
			else
			{
				return;
			}

			StockDataDownloader dataFormatter = new StockDataDownloader(selectedFolder);
			dataFormatter.WriteDataToCSV(outputFilePath + "\\RawData_" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + ".sdp");
			System.Windows.Forms.MessageBox.Show("Data formatting completed.");
		}
	}
}
