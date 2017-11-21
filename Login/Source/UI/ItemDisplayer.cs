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
        String shopInfo;
        private string tempName = null;
        private float tempPrice;
        private Category tempCategory;
        

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            products = new List<Item>();

            SetContentView(Resource.Layout.ItemDisplayerLayout);

            productsListView = FindViewById<ListView>(Resource.Id.productsListView);
        
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
             SetText(shopInfo);
            
            ListViewAdapter listViewAdapter = new ListViewAdapter(products, this);

            productsListView.Adapter = listViewAdapter;
            productsListView.ItemClick += ProductsListView_ItemClick;
       
        }

        private void ProductsListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            EditItemDialog editItem = new EditItemDialog(products[e.Position].name, products[e.Position].getPrice().ToString());
            editItem.Show(transaction, "Dialog frag");
            //kazkaip reikia padaryti kad kviestu editComplete su papildomu argumentu AdapterView.itemclickeventargs kad galetume 
            //paduot viska ko reikia i sit metoda
            editItem.EditDone += editComplete;
            
            products[e.Position].name = tempName;
            products[e.Position].price = tempPrice;
            products[e.Position].category = tempCategory;
         
        }

        private void editComplete(object sender, OnEditText e)
        {
            tempName = e.ItemName;
            tempPrice = Convert.ToSingle(e.ItemPrice);
            Category givenCategory = (Category)Enum.Parse(typeof(Category), e.Category);
            tempCategory = givenCategory;

            
        }

        protected void SetText(String shopInfo)
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

                shopInfo = "Shop:" + receipt.shop.ToString() + " Items bought:";
                foreach (Item item in receipt.shoppingList)
                {
                    products.Add(new Item()
                    {
                        name = item.name,
                        price = item.getPrice(),
                        category = item.category
                    });
                }
                //textView.Text += "Total : " + receipt.total+"\n";
                Task.Run(() => ReceiptApiManager.SaveReceiptData(UserController.GetUserID, UserController.UserToken, receiptJSON));

            }
        }
    }
    
}