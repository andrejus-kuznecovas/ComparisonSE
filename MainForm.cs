﻿using CSE.Source;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
            fileDialog.Filter = "Image Files(*.png;*.jpg;*.tiff)|*.png;*.jpg;*.tiff"; // allowed formats

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
            string imageText = imageRecogniser.ImageToText(imagePath);
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
        }

    }
}
