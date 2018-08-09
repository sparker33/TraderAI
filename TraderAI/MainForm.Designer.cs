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
            this.label2 = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.runButton = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ticker Data Column:";
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
            this.endDatePicker.Value = new System.DateTime(2018, 8, 4, 0, 0, 0, 0);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.runButton.Location = new System.Drawing.Point(12, 280);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 12;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 315);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDateLabel);
            this.Controls.Add(this.endDateLabel);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Button runButton;
    }
}

