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
    class ItemListViewAdapter : BaseAdapter<Item>
    {
        List<Item> items;
        Context context;

        public ItemListViewAdapter(Context context, List<Item> items)
        {
            this.items = items;
            this.context = context;
        }

        public override int Count
        {
            get {return items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override Item this[int position]
        {
            get { return items[position]; }
        }

        // display one item in itemListView
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
            {
                row = LayoutInflater.From(this.context).Inflate(Resource.Layout.ItemRow, null, false);
            }

            // set text for one item
            TextView name = row.FindViewById<TextView>(Resource.Id.rowName);
            name.Text = items[position].Name;
            TextView price = row.FindViewById<TextView>(Resource.Id.rowPrice);
            price.Text = items[position].Price.ToString();
            TextView category = row.FindViewById<TextView>(Resource.Id.rowCategory);
            category.Text = items[position].Category;

            return row;       
        }


    }
}