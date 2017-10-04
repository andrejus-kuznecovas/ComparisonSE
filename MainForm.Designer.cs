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
            this.fileInputButton = new System.Windows.Forms.Button();
            this.receiptTextLabel = new System.Windows.Forms.Label();
            this.statisticsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statisticsButton = new System.Windows.Forms.Button();
            this.periodDropDown = new System.Windows.Forms.ComboBox();
            this.sortByLabel = new System.Windows.Forms.Label();
            this.receiptPreview = new CSE.Source.MyPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.statisticsChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // fileInputButton
            // 
            this.fileInputButton.Location = new System.Drawing.Point(52, 258);
            this.fileInputButton.Margin = new System.Windows.Forms.Padding(2);
            this.fileInputButton.Name = "fileInputButton";
            this.fileInputButton.Size = new System.Drawing.Size(142, 35);
            this.fileInputButton.TabIndex = 2;
            this.fileInputButton.Text = "Choose receipt...";
            this.fileInputButton.UseVisualStyleBackColor = true;
            this.fileInputButton.Click += new System.EventHandler(this.ChooseImage);
            // 
            // receiptTextLabel
            // 
            this.receiptTextLabel.AutoSize = true;
            this.receiptTextLabel.Location = new System.Drawing.Point(9, 318);
            this.receiptTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.receiptTextLabel.Name = "receiptTextLabel";
            this.receiptTextLabel.Size = new System.Drawing.Size(404, 17);
            this.receiptTextLabel.TabIndex = 3;
            this.receiptTextLabel.Text = "Upload a receipt and click \"Choose receipt\" button to analyse it";
            // 
            // statisticsChart
            // 
            chartArea1.Name = "ChartArea1";
            this.statisticsChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.statisticsChart.Legends.Add(legend1);
            this.statisticsChart.Location = new System.Drawing.Point(201, 62);
            this.statisticsChart.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsChart.Name = "statisticsChart";
            this.statisticsChart.Size = new System.Drawing.Size(270, 231);
            this.statisticsChart.TabIndex = 4;
            this.statisticsChart.Text = "d";
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(330, 258);
            this.statisticsButton.Margin = new System.Windows.Forms.Padding(2);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(141, 35);
            this.statisticsButton.TabIndex = 5;
            this.statisticsButton.Text = "Show statistics";
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
            this.periodDropDown.Location = new System.Drawing.Point(201, 34);
            this.periodDropDown.Margin = new System.Windows.Forms.Padding(2);
            this.periodDropDown.Name = "periodDropDown";
            this.periodDropDown.Size = new System.Drawing.Size(270, 24);
            this.periodDropDown.TabIndex = 6;
            // 
            // sortByLabel
            // 
            this.sortByLabel.AutoSize = true;
            this.sortByLabel.Location = new System.Drawing.Point(199, 9);
            this.sortByLabel.Name = "sortByLabel";
            this.sortByLabel.Size = new System.Drawing.Size(57, 17);
            this.sortByLabel.TabIndex = 7;
            this.sortByLabel.Text = "Sort by:";
            this.sortByLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // receiptPreview
            // 
            this.receiptPreview.Image = null;
            this.receiptPreview.Location = new System.Drawing.Point(12, 2);
            this.receiptPreview.Margin = new System.Windows.Forms.Padding(2);
            this.receiptPreview.Name = "receiptPreview";
            this.receiptPreview.Size = new System.Drawing.Size(182, 291);
            this.receiptPreview.TabIndex = 1;
            this.receiptPreview.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(482, 640);
            this.Controls.Add(this.sortByLabel);
            this.Controls.Add(this.periodDropDown);
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
            ((System.ComponentModel.ISupportInitialize)(this.statisticsChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receiptPreview)).EndInit();
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
        private System.Windows.Forms.Label sortByLabel;
    }
}

