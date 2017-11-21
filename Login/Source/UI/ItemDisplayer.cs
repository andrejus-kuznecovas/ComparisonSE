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
using System.Collections.Generic;

namespace Login.Source.UI
{
    [Activity(Theme = "@style/Theme.Brand")]
    class ItemDisplayer:Activity
    {
        
        private TextView textView;
        private ListView productsListView;
        private List<Item> products;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            products = new List<Item>();

            SetContentView(Resource.Layout.ItemDisplayerLayout);

            productsListView = FindViewById<ListView>(Resource.Id.productsListView);
            String shopInfo;
            // textView = FindViewById<TextView>(Resource.Id.showTxt);


            // var image = SnapingCamera.Image;

            //ITextRecognizer imageRecognizer = new ImageRecognitionScanbot(this);
            //imageRecognizer.AddOnCompleteHandler(SetText);


            //Task.Run( () => imageRecognizer.GetTextFromImage(image) );
            /*
            products.Add(new Product()
            {
                productName = "agurkas",
                productPrice = "50",
                productType = "darzove"
            });
            */
            // SetText();
            ItemGenerator.Initialize();
            string text = ItemGenerator.GenerateItems();
            if (!String.IsNullOrEmpty(text))
            {
                Receipt receipt = new Receipt(text);

                shopInfo = "Shop:" + receipt.shop.ToString() + " items bought:";
               
                foreach (Item item in receipt.shoppingList)
                {
                    products.Add(new Item()
                    {
                        name = item.name,
                        price = item.getPrice(),
                        category = item.category
                    });
                }
            }
            ListViewAdapter listViewAdapter = new ListViewAdapter(products, this);

            productsListView.Adapter = listViewAdapter;
            productsListView.ItemClick += ProductsListView_ItemClick;
       
        }

        private void ProductsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
           // productsListView. = true;
           // products[e.Position].name = "pakeista";
        }

        protected void SetText(/*object sender, OCRText result*/)
        {
          //  textView = FindViewById<TextView>(Resource.Id.showTxt);

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