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
            this.receiptPreview.Location = new System.Drawing.Point(13, 2);
            this.receiptPreview.Name = "receiptPreview";
            this.receiptPreview.Size = new System.Drawing.Size(183, 291);
            this.receiptPreview.TabIndex = 1;
            this.receiptPreview.TabStop = false;
            // 
            // fileInputButton
            // 
            this.fileInputButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fileInputButton.Location = new System.Drawing.Point(234, 220);
            this.fileInputButton.Name = "fileInputButton";
            this.fileInputButton.Size = new System.Drawing.Size(143, 35);
            this.fileInputButton.TabIndex = 2;
            this.fileInputButton.Text = "Choose receipt...";
            this.fileInputButton.UseVisualStyleBackColor = true;
            this.fileInputButton.Click += new System.EventHandler(this.ChooseImage);
            // 
            // receiptTextLabel
            // 
            this.receiptTextLabel.AutoSize = true;
            this.receiptTextLabel.Location = new System.Drawing.Point(10, 317);
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
            this.statisticsChart.Location = new System.Drawing.Point(201, 46);
            this.statisticsChart.Name = "statisticsChart";
            this.statisticsChart.Size = new System.Drawing.Size(213, 168);
            this.statisticsChart.TabIndex = 4;
            this.statisticsChart.Text = "chart1";
            // 
            // statisticsButton
            // 
            this.statisticsButton.Location = new System.Drawing.Point(234, 261);
            this.statisticsButton.Name = "statisticsButton";
            this.statisticsButton.Size = new System.Drawing.Size(143, 32);
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
            this.periodDropDown.Location = new System.Drawing.Point(203, 2);
            this.periodDropDown.Name = "periodDropDown";
            this.periodDropDown.Size = new System.Drawing.Size(211, 24);
            this.periodDropDown.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(420, 640);
            this.Controls.Add(this.periodDropDown);
            this.Controls.Add(this.statisticsButton);
            this.Controls.Add(this.statisticsChart);
            this.Controls.Add(this.receiptTextLabel);
            this.Controls.Add(this.fileInputButton);
            this.Controls.Add(this.receiptPreview);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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

