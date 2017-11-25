using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Login.Source.Controllers.OCR;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Login.Source.Controllers;
using Login.Source.Controllers.Receipts;

namespace Login.Source.UI
{
    [Activity(Theme = "@style/Theme.Brand")]
    class ItemDisplayer:Activity
    {
        private TextView textView;

        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.ShowText);

            textView = FindViewById<TextView>(Resource.Id.showTxt);
            
            var image = SnapingCamera.Image;

            ProgressDialog recognitionDialog = ProgressDialog.Show(this, "",
                Resources.GetString(Resource.String.item_displayer_receipt_being_recognized), true);

            //ITextRecognizer imageRecognizer = new ImageRecognitionScanbot(this);
            //imageRecognizer.AddOnCompleteHandler(SetText);


            //Task.Run( () => imageRecognizer.GetTextFromImage(image) );
            recognitionDialog.Dismiss();

            ProgressDialog categorisationDialog = ProgressDialog.Show(this, "",
                Resources.GetString(Resource.String.item_displayer_items_being_categorised), true);
            SetText();
            categorisationDialog.Dismiss();
        }

        protected void SetText(/*object sender, OCRText result*/)
        {
            textView = FindViewById<TextView>(Resource.Id.showTxt);

            // Should be replaced by fake item generator for now
            //string text = result.text;
            ItemGenerator.Initialize();
            string text = ItemGenerator.GenerateItems();
            if (!String.IsNullOrEmpty(text))
            {
                Receipt receipt = new Receipt(text);
                string receiptJSON = JsonConvert.SerializeObject(receipt);
                System.Diagnostics.Debug.WriteLine("ID: " + UserController.GetUserID + " Token: " + UserController.UserToken + " json: " +receiptJSON);
                
                textView.Text = "Shop:" + receipt.shop.ToString() + "\n\n";
                textView.Text += "Items bought:\n";
                foreach (Item item in receipt.shoppingList)
                {
                    textView.Text += "* " + item.name + " " + item.getPrice() + "\nCategory: "+ item.category + "\n\n";
                }
                textView.Text += "Total : " + receipt.total+"\n";
                Task.Run(() => ReceiptApiManager.SaveReceiptData(UserController.GetUserID, UserController.UserToken, receiptJSON));

            }
        }
    }
    
}