using System.Drawing;
using CSE.Source;

namespace CSE
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.receiptPreview = new MyPictureBox();
            this.fileInputButton = new System.Windows.Forms.Button();
            this.receiptTextLabel = new System.Windows.Forms.Label();
            this.statisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.periodDropDown = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.receiptPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsChart)).BeginInit();
            this.SuspendLayout();
            // 
            // receiptPreview
            // 
            this.receiptPreview.Location = new System.Drawing.Point(10, 2);
            this.receiptPreview.Margin = new System.Windows.Forms.Padding(2);
            this.receiptPreview.Name = "receiptPreview";
            this.receiptPreview.Size = new System.Drawing.Size(146, 233);
            this.receiptPreview.TabIndex = 1;
            this.receiptPreview.TabStop = false;
            // 
            // fileInputButton
            // 

            this.fileInputButton.Location = new System.Drawing.Point(187, 176);
            this.fileInputButton.Margin = new System.Windows.Forms.Padding(2);
            this.fileInputButton.Name = "fileInputButton";
            this.fileInputButton.Size = new System.Drawing.Size(114, 28);
            this.fileInputButton.TabIndex = 2;
            this.fileInputButton.Text = "Choose receipt...";
            this.fileInputButton.UseVisualStyleBackColor = true;
            this.fileInputButton.Click += new System.EventHandler(this.ChooseImage);
            // 
            // receiptTextLabel
            // 
            this.receiptTextLabel.AutoSize = true;
            this.receiptTextLabel.Location = new System.Drawing.Point(8, 254);
            this.receiptTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.receiptTextLabel.Name = "receiptTextLabel";
            this.receiptTextLabel.Size = new System.Drawing.Size(307, 13);
            this.receiptTextLabel.TabIndex = 3;
            this.receiptTextLabel.Text = "Upload a receipt and click \"Choose receipt\" button to analyse it";
            // 
            // statisticsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.statisticsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.statisticsChart.Legends.Add(legend1);
            this.statisticsChart.Location = new System.Drawing.Point(161, 37);
            this.statisticsChart.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsChart.Name = "statisticsChart";
            this.statisticsChart.Size = new System.Drawing.Size(170, 134);
            this.statisticsChart.TabIndex = 4;
            this.statisticsChart.Text = "d";
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(187, 209);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(114, 26);
            this.statisticsButton.TabIndex = 5;
            this.statisticsButton.Text = "Statistics";
            this.statisticsButton.UseVisualStyleBackColor = true;
            this.statisticsButton.Click += new System.EventHandler(this.DisplayStatistics);
            // 
            // periodDropDown
            // 
            this.periodDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.periodDropDown.FormattingEnabled = true;
            this.periodDropDown.Items.AddRange(new object[] {
            "Total",
            "Today",
            "This week",
            "This month",
            "This year"});

            this.comboBox1.Location = new System.Drawing.Point(162, 2);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(336, 512);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.statisticsChart);
            this.Controls.Add(this.receiptTextLabel);
            this.Controls.Add(this.fileInputButton);
            this.Controls.Add(this.receiptPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Billy";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.receiptPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyPictureBox receiptPreview;
        private System.Windows.Forms.Button fileInputButton;
        private System.Windows.Forms.Label receiptTextLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart statisticsChart;
        private System.Windows.Forms.Button statisticsButton;
        private System.Windows.Forms.ComboBox periodDropDown;
    }
}

