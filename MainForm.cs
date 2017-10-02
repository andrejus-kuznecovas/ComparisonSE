using CSE.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tesseract.ConsoleDemo;
using System.Windows.Forms.DataVisualization.Charting;

namespace CSE
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.receiptPreview.SizeMode = PictureBoxSizeMode.StretchImage; // make image fit to the picture box
            this.receiptPreview.BorderStyle = BorderStyle.FixedSingle; // apply basic border
        }

        private void ChooseImage(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); // create new file selection window
            fileDialog.Title = "Choose a receipt to process";
            fileDialog.Filter = "Image Files(*.png;*.jpg;*.tiff;*tif.)|*.png;*.jpg;*.tiff;*tif;"; // allowed formats

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.receiptPreview.ImageLocation = fileDialog.FileName; // display image
                this.fileInputButton.Text = "Analyse receipt";
                this.fileInputButton.Click -= ChooseImage; // remove event
                this.fileInputButton.Click += new EventHandler((s, eargs) => AnalyseImage(s, e, fileDialog.FileName)); // add new event to analyse text

            }
        }

        private void AnalyseImage(object sender, EventArgs e, string imagePath) {
            ImageRecogniser imageRecogniser = new ImageRecogniser();
            string imageText = imageRecogniser.GetText(imagePath);
            this.receiptTextLabel.Text = imageText;
            Receipt receipt = new Receipt(imageText);
            List<string> shoppingList = receipt.shoppingList;
            this.receiptTextLabel.Text = "Items bought:\n";
             foreach (string item in shoppingList)
            {
                this.receiptTextLabel.Text += "* " + item + "\n";
            }

            this.receiptTextLabel.Text +=
                "\nTotal: " + receipt.total.ToString() 
                + "\nShopping Centre: " + receipt.shop;
            XmlSerialization.SaveReceipt(receipt);
        }

        private void DisplayStatistics(object sender, EventArgs e)
        {
            var data = StatisticsManager.GetPriceChangeData();
            this.statisticsChart.Series.Clear();
            this.statisticsChart.ChartAreas.Clear();
            

            this.statisticsChart.ChartAreas.Add(new ChartArea());
            this.statisticsChart.Series.Add(new Series("Data"));
           
            this.statisticsChart.Series["Data"]["PieLabelStyle"] = "Outside";
            this.statisticsChart.Series["Data"].ChartType = SeriesChartType.Pie;
            this.statisticsChart.Series["Data"].IsVisibleInLegend = false;
            //this.statisticsChart.Series["Data"].Points.DataBindXY(
            //    data.receipts.Select(item => item.Key).ToArray(),
            //    data.receipts.Select(item => item.Value).ToArray()
            //);
        }
    }
}
