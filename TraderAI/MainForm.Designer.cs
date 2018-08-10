namespace TraderAI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tickerListInputLabel = new System.Windows.Forms.Label();
            this.tickerListTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.exchangeColumnDropDown = new System.Windows.Forms.ComboBox();
            this.tickerColumnDropDown = new System.Windows.Forms.ComboBox();
            this.exchangeColLabel = new System.Windows.Forms.Label();
            this.tickerColLabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.downloadButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.genSizeLabel = new System.Windows.Forms.Label();
            this.genCountLabel = new System.Windows.Forms.Label();
            this.mutationLabel = new System.Windows.Forms.Label();
            this.genSizeBox = new System.Windows.Forms.TextBox();
            this.genCountBox = new System.Windows.Forms.TextBox();
            this.mutationRateBox = new System.Windows.Forms.TextBox();
            this.tradeFeeBox = new System.Windows.Forms.TextBox();
            this.tradeFeeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tickerListInputLabel
            // 
            this.tickerListInputLabel.AutoSize = true;
            this.tickerListInputLabel.Location = new System.Drawing.Point(9, 9);
            this.tickerListInputLabel.Name = "tickerListInputLabel";
            this.tickerListInputLabel.Size = new System.Drawing.Size(59, 13);
            this.tickerListInputLabel.TabIndex = 0;
            this.tickerListInputLabel.Text = "Ticker List:";
            // 
            // tickerListTextBox
            // 
            this.tickerListTextBox.Location = new System.Drawing.Point(12, 25);
            this.tickerListTextBox.Name = "tickerListTextBox";
            this.tickerListTextBox.ReadOnly = true;
            this.tickerListTextBox.Size = new System.Drawing.Size(265, 20);
            this.tickerListTextBox.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(13, 53);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(72, 25);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // exchangeColumnDropDown
            // 
            this.exchangeColumnDropDown.FormattingEnabled = true;
            this.exchangeColumnDropDown.Location = new System.Drawing.Point(138, 103);
            this.exchangeColumnDropDown.Name = "exchangeColumnDropDown";
            this.exchangeColumnDropDown.Size = new System.Drawing.Size(139, 21);
            this.exchangeColumnDropDown.TabIndex = 4;
            // 
            // tickerColumnDropDown
            // 
            this.tickerColumnDropDown.FormattingEnabled = true;
            this.tickerColumnDropDown.Location = new System.Drawing.Point(138, 130);
            this.tickerColumnDropDown.Name = "tickerColumnDropDown";
            this.tickerColumnDropDown.Size = new System.Drawing.Size(139, 21);
            this.tickerColumnDropDown.TabIndex = 5;
            // 
            // exchangeColLabel
            // 
            this.exchangeColLabel.AutoSize = true;
            this.exchangeColLabel.Location = new System.Drawing.Point(10, 106);
            this.exchangeColLabel.Name = "exchangeColLabel";
            this.exchangeColLabel.Size = new System.Drawing.Size(122, 13);
            this.exchangeColLabel.TabIndex = 6;
            this.exchangeColLabel.Text = "Exchange Data Column:";
            // 
            // tickerColLabel
            // 
            this.tickerColLabel.AutoSize = true;
            this.tickerColLabel.Location = new System.Drawing.Point(10, 133);
            this.tickerColLabel.Name = "tickerColLabel";
            this.tickerColLabel.Size = new System.Drawing.Size(104, 13);
            this.tickerColLabel.TabIndex = 7;
            this.tickerColLabel.Text = "Ticker Data Column:";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(10, 190);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(55, 13);
            this.endDateLabel.TabIndex = 8;
            this.endDateLabel.Text = "End Date:";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(10, 165);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(58, 13);
            this.startDateLabel.TabIndex = 9;
            this.startDateLabel.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDatePicker.Location = new System.Drawing.Point(71, 159);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(103, 20);
            this.startDatePicker.TabIndex = 10;
            this.startDatePicker.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            // 
            // endDatePicker
            // 
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDatePicker.Location = new System.Drawing.Point(71, 184);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(103, 20);
            this.endDatePicker.TabIndex = 11;
            this.endDatePicker.Value = new System.DateTime(2017, 7, 24, 0, 0, 0, 0);
            // 
            // downloadButton
            // 
            this.downloadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.downloadButton.Location = new System.Drawing.Point(12, 354);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(94, 23);
            this.downloadButton.TabIndex = 12;
            this.downloadButton.Text = "Download Data";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runButton.Location = new System.Drawing.Point(112, 354);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(94, 23);
            this.runButton.TabIndex = 13;
            this.runButton.Text = "Evolve Trader";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // genSizeLabel
            // 
            this.genSizeLabel.AutoSize = true;
            this.genSizeLabel.Location = new System.Drawing.Point(12, 221);
            this.genSizeLabel.Name = "genSizeLabel";
            this.genSizeLabel.Size = new System.Drawing.Size(85, 13);
            this.genSizeLabel.TabIndex = 14;
            this.genSizeLabel.Text = "Generation Size:";
            // 
            // genCountLabel
            // 
            this.genCountLabel.AutoSize = true;
            this.genCountLabel.Location = new System.Drawing.Point(12, 247);
            this.genCountLabel.Name = "genCountLabel";
            this.genCountLabel.Size = new System.Drawing.Size(93, 13);
            this.genCountLabel.TabIndex = 15;
            this.genCountLabel.Text = "Generation Count:";
            // 
            // mutationLabel
            // 
            this.mutationLabel.AutoSize = true;
            this.mutationLabel.Location = new System.Drawing.Point(12, 273);
            this.mutationLabel.Name = "mutationLabel";
            this.mutationLabel.Size = new System.Drawing.Size(77, 13);
            this.mutationLabel.TabIndex = 16;
            this.mutationLabel.Text = "Mutation Rate:";
            // 
            // genSizeBox
            // 
            this.genSizeBox.Location = new System.Drawing.Point(112, 218);
            this.genSizeBox.Name = "genSizeBox";
            this.genSizeBox.Size = new System.Drawing.Size(62, 20);
            this.genSizeBox.TabIndex = 17;
            this.genSizeBox.Text = "1000";
            this.genSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // genCountBox
            // 
            this.genCountBox.Location = new System.Drawing.Point(112, 244);
            this.genCountBox.Name = "genCountBox";
            this.genCountBox.Size = new System.Drawing.Size(62, 20);
            this.genCountBox.TabIndex = 18;
            this.genCountBox.Text = "750";
            this.genCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mutationRateBox
            // 
            this.mutationRateBox.Location = new System.Drawing.Point(112, 270);
            this.mutationRateBox.Name = "mutationRateBox";
            this.mutationRateBox.Size = new System.Drawing.Size(62, 20);
            this.mutationRateBox.TabIndex = 19;
            this.mutationRateBox.Text = "0.01";
            this.mutationRateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tradeFeeBox
            // 
            this.tradeFeeBox.Location = new System.Drawing.Point(112, 296);
            this.tradeFeeBox.Name = "tradeFeeBox";
            this.tradeFeeBox.Size = new System.Drawing.Size(62, 20);
            this.tradeFeeBox.TabIndex = 21;
            this.tradeFeeBox.Text = "5.00";
            this.tradeFeeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tradeFeeLabel
            // 
            this.tradeFeeLabel.AutoSize = true;
            this.tradeFeeLabel.Location = new System.Drawing.Point(12, 299);
            this.tradeFeeLabel.Name = "tradeFeeLabel";
            this.tradeFeeLabel.Size = new System.Drawing.Size(59, 13);
            this.tradeFeeLabel.TabIndex = 20;
            this.tradeFeeLabel.Text = "Trade Fee:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 389);
            this.Controls.Add(this.tradeFeeBox);
            this.Controls.Add(this.tradeFeeLabel);
            this.Controls.Add(this.mutationRateBox);
            this.Controls.Add(this.genCountBox);
            this.Controls.Add(this.genSizeBox);
            this.Controls.Add(this.mutationLabel);
            this.Controls.Add(this.genCountLabel);
            this.Controls.Add(this.genSizeLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.tickerColLabel);
            this.Controls.Add(this.exchangeColLabel);
            this.Controls.Add(this.tickerColumnDropDown);
            this.Controls.Add(this.exchangeColumnDropDown);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.tickerListTextBox);
            this.Controls.Add(this.tickerListInputLabel);
            this.Name = "MainForm";
            this.Text = "TraderAI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tickerListInputLabel;
        private System.Windows.Forms.TextBox tickerListTextBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.ComboBox exchangeColumnDropDown;
        private System.Windows.Forms.ComboBox tickerColumnDropDown;
        private System.Windows.Forms.Label exchangeColLabel;
        private System.Windows.Forms.Label tickerColLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label genSizeLabel;
        private System.Windows.Forms.Label genCountLabel;
        private System.Windows.Forms.Label mutationLabel;
        private System.Windows.Forms.TextBox genSizeBox;
        private System.Windows.Forms.TextBox genCountBox;
        private System.Windows.Forms.TextBox mutationRateBox;
        private System.Windows.Forms.TextBox tradeFeeBox;
        private System.Windows.Forms.Label tradeFeeLabel;
    }
}

