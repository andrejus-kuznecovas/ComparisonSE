using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    public enum Category
    {
        UNKNOWN_CATEGORY,
        DAIRY_PRODUCTS,
        BREAD_PRODUCTS,
        DRINKS,
        HOUSEHOLD_GOODS,
        PET_PRODUCTS,
        MEAT_AND_FISH,
        FRUIT_AND_VEGETABLES,
        SWEETS,
        HOUSEHOLD_CHEMICALS,
        HYGIENE_PRODUCTS,
        OTHER_GOODS
    };


    public class Item
    {
        public int price { get; set; }
        public string name { get; set; }
        public Category category { get; set; }

        // Required for XML serialization
        public Item()
        {

        }

        public Item(string name, int price)
        {
            this.price = price;
            this.name = name.ToLower();
        }

        public double getPrice()
        {
            return price / (double)100;
        }

        public string GetName()
        {
            return this.name;

        }

        ~Item()
        {

        }
    }
}
