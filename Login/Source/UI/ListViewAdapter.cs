using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Login.Source.UI
{
    class ListViewAdapter : BaseAdapter<Item>
    {
        private List<Item> productsList;
        private Context context;

        public ListViewAdapter(List<Item> productsList, Context context)
        {
            this.productsList = productsList;
            this.context = context;
        }

        public override int Count
        {
            get { return productsList.Count; }
        }

        public override long GetItemId(int itemPosition)
        {
            return itemPosition;
        }

        public override Item this[int itemPosition]
        {
            get { return productsList[itemPosition]; }
        }

        public override View GetView(int itemPositon, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if(row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ShowText, null, false);
            }
            TextView nameText = row.FindViewById<TextView>(Resource.Id.productNameTextView);
            TextView priceText = row.FindViewById<TextView>(Resource.Id.productPriceTextView);
            TextView typeText = row.FindViewById<TextView>(Resource.Id.productTypeTextView);
            nameText.Text = productsList[itemPositon].name;
            priceText.Text = productsList[itemPositon].getPrice().ToString();
            typeText.Text = productsList[itemPositon].category.ToString();
            return row;
        }
    }
}