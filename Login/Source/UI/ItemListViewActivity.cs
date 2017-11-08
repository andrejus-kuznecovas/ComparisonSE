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
    [Activity(Label = "Activity1")]
    public class ItemListViewActivity : Activity
    {
        private ListView listView;
        private List<Item> itemList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ItemListViewLayout);
            listView = FindViewById<ListView>(Resource.Id.lvItem);

            itemList = new List<Item>();


            // for testing
            itemList.Add(new Item("viens", 2, "trys"));
            itemList.Add(new Item("keturi", 5, "sesi"));


            // link adapter to listView
            ItemListViewAdapter adapter = new ItemListViewAdapter(this, itemList);
            listView.Adapter = adapter;


        }
    }

    
}