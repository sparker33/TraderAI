using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraderAI
{
    public partial class MainForm : Form
    {
        // Statics
        const string DEFAULTDIRECTORY = "C:\\";

        // Private fields
        //reserved

       // Public accessors
       //reserved

        public MainForm()
        {
            InitializeComponent();
        }

        // Event handler for browsebutton; gets file to read list of tickers to scrape data for
        private void browseButton_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
        }
    }
}
