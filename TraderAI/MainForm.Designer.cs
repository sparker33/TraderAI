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
			this.evolveButton = new System.Windows.Forms.Button();
			this.genSizeLabel = new System.Windows.Forms.Label();
			this.genCountLabel = new System.Windows.Forms.Label();
			this.mutationLabel = new System.Windows.Forms.Label();
			this.genSizeBox = new System.Windows.Forms.TextBox();
			this.genCountBox = new System.Windows.Forms.TextBox();
			this.mutationRateBox = new System.Windows.Forms.TextBox();
			this.tradeFeeBox = new System.Windows.Forms.TextBox();
			this.tradeFeeLabel = new System.Windows.Forms.Label();
			this.predictionButton = new System.Windows.Forms.Button();
			this.predictIntervalsBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dataFormatButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// evolveButton
			// 
			this.evolveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.evolveButton.Location = new System.Drawing.Point(12, 176);
			this.evolveButton.Name = "evolveButton";
			this.evolveButton.Size = new System.Drawing.Size(94, 23);
			this.evolveButton.TabIndex = 13;
			this.evolveButton.Text = "Evolve Trader";
			this.evolveButton.UseVisualStyleBackColor = true;
			this.evolveButton.Click += new System.EventHandler(this.evolveButton_Click);
			// 
			// genSizeLabel
			// 
			this.genSizeLabel.AutoSize = true;
			this.genSizeLabel.Location = new System.Drawing.Point(12, 9);
			this.genSizeLabel.Name = "genSizeLabel";
			this.genSizeLabel.Size = new System.Drawing.Size(85, 13);
			this.genSizeLabel.TabIndex = 14;
			this.genSizeLabel.Text = "Generation Size:";
			// 
			// genCountLabel
			// 
			this.genCountLabel.AutoSize = true;
			this.genCountLabel.Location = new System.Drawing.Point(12, 35);
			this.genCountLabel.Name = "genCountLabel";
			this.genCountLabel.Size = new System.Drawing.Size(93, 13);
			this.genCountLabel.TabIndex = 15;
			this.genCountLabel.Text = "Generation Count:";
			// 
			// mutationLabel
			// 
			this.mutationLabel.AutoSize = true;
			this.mutationLabel.Location = new System.Drawing.Point(12, 61);
			this.mutationLabel.Name = "mutationLabel";
			this.mutationLabel.Size = new System.Drawing.Size(77, 13);
			this.mutationLabel.TabIndex = 16;
			this.mutationLabel.Text = "Mutation Rate:";
			// 
			// genSizeBox
			// 
			this.genSizeBox.Location = new System.Drawing.Point(112, 6);
			this.genSizeBox.Name = "genSizeBox";
			this.genSizeBox.Size = new System.Drawing.Size(62, 20);
			this.genSizeBox.TabIndex = 17;
			this.genSizeBox.Text = "1000";
			this.genSizeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// genCountBox
			// 
			this.genCountBox.Location = new System.Drawing.Point(112, 32);
			this.genCountBox.Name = "genCountBox";
			this.genCountBox.Size = new System.Drawing.Size(62, 20);
			this.genCountBox.TabIndex = 18;
			this.genCountBox.Text = "750";
			this.genCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// mutationRateBox
			// 
			this.mutationRateBox.Location = new System.Drawing.Point(112, 58);
			this.mutationRateBox.Name = "mutationRateBox";
			this.mutationRateBox.Size = new System.Drawing.Size(62, 20);
			this.mutationRateBox.TabIndex = 19;
			this.mutationRateBox.Text = "0.01";
			this.mutationRateBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tradeFeeBox
			// 
			this.tradeFeeBox.Location = new System.Drawing.Point(112, 84);
			this.tradeFeeBox.Name = "tradeFeeBox";
			this.tradeFeeBox.Size = new System.Drawing.Size(62, 20);
			this.tradeFeeBox.TabIndex = 21;
			this.tradeFeeBox.Text = "5.00";
			this.tradeFeeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tradeFeeLabel
			// 
			this.tradeFeeLabel.AutoSize = true;
			this.tradeFeeLabel.Location = new System.Drawing.Point(12, 87);
			this.tradeFeeLabel.Name = "tradeFeeLabel";
			this.tradeFeeLabel.Size = new System.Drawing.Size(59, 13);
			this.tradeFeeLabel.TabIndex = 20;
			this.tradeFeeLabel.Text = "Trade Fee:";
			// 
			// predictionButton
			// 
			this.predictionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.predictionButton.Location = new System.Drawing.Point(112, 176);
			this.predictionButton.Name = "predictionButton";
			this.predictionButton.Size = new System.Drawing.Size(94, 23);
			this.predictionButton.TabIndex = 22;
			this.predictionButton.Text = "Run Predictor";
			this.predictionButton.UseVisualStyleBackColor = true;
			this.predictionButton.Click += new System.EventHandler(this.predictionButton_Click);
			// 
			// predictIntervalsBox
			// 
			this.predictIntervalsBox.Location = new System.Drawing.Point(112, 110);
			this.predictIntervalsBox.Name = "predictIntervalsBox";
			this.predictIntervalsBox.Size = new System.Drawing.Size(62, 20);
			this.predictIntervalsBox.TabIndex = 23;
			this.predictIntervalsBox.Text = "270";
			this.predictIntervalsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 113);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 24;
			this.label1.Text = "Prediction Range:";
			// 
			// dataFormatButton
			// 
			this.dataFormatButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dataFormatButton.Location = new System.Drawing.Point(12, 147);
			this.dataFormatButton.Name = "dataFormatButton";
			this.dataFormatButton.Size = new System.Drawing.Size(94, 23);
			this.dataFormatButton.TabIndex = 25;
			this.dataFormatButton.Text = "Format Data";
			this.dataFormatButton.UseVisualStyleBackColor = true;
			this.dataFormatButton.Click += new System.EventHandler(this.dataFormatButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 211);
			this.Controls.Add(this.dataFormatButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.predictIntervalsBox);
			this.Controls.Add(this.predictionButton);
			this.Controls.Add(this.tradeFeeBox);
			this.Controls.Add(this.tradeFeeLabel);
			this.Controls.Add(this.mutationRateBox);
			this.Controls.Add(this.genCountBox);
			this.Controls.Add(this.genSizeBox);
			this.Controls.Add(this.mutationLabel);
			this.Controls.Add(this.genCountLabel);
			this.Controls.Add(this.genSizeLabel);
			this.Controls.Add(this.evolveButton);
			this.Name = "MainForm";
			this.Text = "TraderAI";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button evolveButton;
        private System.Windows.Forms.Label genSizeLabel;
        private System.Windows.Forms.Label genCountLabel;
        private System.Windows.Forms.Label mutationLabel;
        private System.Windows.Forms.TextBox genSizeBox;
        private System.Windows.Forms.TextBox genCountBox;
        private System.Windows.Forms.TextBox mutationRateBox;
        private System.Windows.Forms.TextBox tradeFeeBox;
        private System.Windows.Forms.Label tradeFeeLabel;
		private System.Windows.Forms.Button predictionButton;
		private System.Windows.Forms.TextBox predictIntervalsBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button dataFormatButton;
	}
}

