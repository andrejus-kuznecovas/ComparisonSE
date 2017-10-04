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
            String savingPath = "";
            
            OpenFileDialog fileDialog = new OpenFileDialog(); // create new file selection window
            fileDialog.Title = "Choose a receipt to process";
            fileDialog.Filter = "Image Files(*.png;*.jpg;*.tiff;*tif.)|*.png;*.jpg;*.tiff;*tif;"; // allowed formats
            Cursor = Cursors.WaitCursor;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
               Image photo = Image.FromFile(fileDialog.FileName);
               MyPictureBox myPictureBox = new MyPictureBox();
                myPictureBox.CorrectExifOrientation(photo);
                savingPath = fileDialog.FileName + "fixed";
               photo.Save(savingPath);
               
               this.receiptPreview.Image = photo ; // display image
               
                AnalyseImage(sender, e, savingPath);
               
            }
            Cursor = Cursors.Arrow;
        }


        private void AnalyseImage(object sender, EventArgs e, string imagePath) {
            ImageRecogniser imageRecogniser = new ImageRecogniser();
            string imageText = imageRecogniser.GetText(imagePath);
            //this.receiptTextLabel.Text = imageText;
            Receipt receipt = new Receipt(imageText);
            List<Item> shoppingList = receipt.shoppingList;
            
            this.receiptTextLabel.Text = "Items bought:\n";
            foreach (Item item in shoppingList)
            {
                this.receiptTextLabel.Text += String.Format("* {0}{1:C}\n",item.GetName().PadRight(40), item.getPrice());
                this.receiptTextLabel.Text += String.Format("---Category: {0}\n\n", item.category.ToString());
            }
            this.receiptTextLabel.Text +=
                "\nTotal: " + receipt.total.ToString() 
                + "\nShopping Centre: " + receipt.shop;
            //XmlSerialization.SaveReceipt(receipt);

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
