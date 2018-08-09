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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.browseButton = new System.Windows.Forms.Button();
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
            this.tickerListTextBox.Size = new System.Drawing.Size(202, 20);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button browseButton;
    }
}

