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
    // to be replaced
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public Item(string name, int price, string category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
    }
}