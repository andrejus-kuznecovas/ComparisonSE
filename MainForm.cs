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
            this.receiptTextLabel.Text = imageText;
            
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
            XmlSerialization.SaveReceipt(receipt);
            
        }

        private void DisplayStatistics(object sender, EventArgs e)
        {
            this.statisticsChart.Series.Clear();
            this.statisticsChart.Series.Add("Category");
            this.statisticsChart.Series[0].ChartType = SeriesChartType.Pie;
            this.statisticsChart.Series[0].IsVisibleInLegend = false;
            string selectedPeriod = periodDropDown.SelectedItem.ToString();
            Console.WriteLine(selectedPeriod);
            DataSet data = new DataSet();
            switch (selectedPeriod)
            {
                case "This year":
                    data.Filter(Period.YEAR);
                    break;
                case "Today":
                    data.Filter(Period.TODAY);
                    break;
                case "This week":
                    data.Filter(Period.WEEK);
                    break;
                case "This month":
                    data.Filter(Period.MONTH);
                    break;
                case "Total":
                    data.Filter(Period.DEFAULT);
                    break;
            }
           
            AddChartSeries(data.GetAllItems());

        }

        private void AddChartSeries(List<Item> shoppingList)
        {
            var groups = Statistics.itemListToDictionary(shoppingList);

            for (int i = 0; i < groups.Keys.Count; i++)
            {
                if (groups.Values.ElementAt(i) != 0)
                {
                    this.statisticsChart.Series["Category"].Points.AddXY(groups.Keys.ElementAt(i).ToString(), groups.Values.ElementAt(i));
                }
            }
            this.statisticsChart.Visible = true;
        }

        
       
    }
}
