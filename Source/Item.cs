using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    enum Category
    {
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

    class Item
    {
        private int price { get; set; }
        private string name { get; set; }
        private Category category { get; set; }

        public Item(int price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public Category getCategory()
        {
            return category;
        }

        public double getPriceDouble()
        {
            return price / 100;
        }

        public int getPriceInt()
        {
            return price;
        }

        public void setCategory(string name)
        {
            category = (Category)Enum.Parse(typeof(Category), name);
        }

        ~Item()
        {

        }
    }
}
