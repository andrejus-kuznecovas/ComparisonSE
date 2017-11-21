using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Linq;
using Android.Content;

namespace Login.Source.UI
{
    public class OnEditText : EventArgs
    {
        private string itemName;
        private string itemPrice;
        private string category;


        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public string ItemPrice
        {
            get { return itemPrice; }
            set { itemPrice = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }


        public OnEditText(string itemName, string itemPrice, string category) : base()
        {
            this.itemName = itemName;
            this.itemPrice = itemPrice;
            this.category = category;

        }
    }

    public class EditItemDialog : DialogFragment
        {
            public EditText itemName;
            public EditText itemPrice;
            public Spinner category;
            private Button editProduct;
            private AlertDialog.Builder alertDialog;
        private String stringProductName;
        private String stringProductPrice;

            public EditItemDialog(string productName, string productPrice)
        {
            stringProductName = productName;
            stringProductPrice = productPrice;
        }
            
            public EventHandler<OnEditText> EditDone;
            
            public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
            {
                base.OnCreateView(inflater, container, savedInstanceState);
                var view = inflater.Inflate(Resource.Layout.dialogEditText, container, false);

                itemName = view.FindViewById<EditText>(Resource.Id.productName);
                itemPrice = view.FindViewById<EditText>(Resource.Id.productPrice);
                category = view.FindViewById<Spinner>(Resource.Id.productTypes);
            var enumValues = Enum.GetValues(typeof(Category));
            var arrayForAdapter = enumValues.Cast<Category>().Select(e => e.ToString()).ToArray();
            var adapter = new ArrayAdapter<string>(Context, Resource.Layout.support_simple_spinner_dropdown_item, arrayForAdapter);
            category.Adapter = adapter;
           
            itemName.Text = stringProductName;
            itemPrice.Text = stringProductPrice;



                editProduct = view.FindViewById<Button>(Resource.Id.editItemButton);

                editProduct.Click += EditButton_Click ;

                return view;
            }

            private void EditButton_Click(object sender, EventArgs e)
            {
               
                EditDone.Invoke(this, new OnEditText(itemName.Text, itemPrice.Text, category.GetItemAtPosition(Convert.ToInt32(category.SelectedItemId)).ToString()));
                this.Dismiss();
            }
            public override void OnActivityCreated(Bundle savedInstanceState)
            {
                Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
                base.OnActivityCreated(savedInstanceState);
                Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim;
        }

        }
    }

