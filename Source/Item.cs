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
        private int price;
        public int Price { get { return price; } set { price = value; } }

        private string name;
        public string Name { get { return name; } set { name = value; } }

        private Category category;
        public Category Category { get { return category; } set { category = value; } }

        public Item(int price, string name)
        {
            this.price = price;
            this.name = name;
        }

        public double GetPrice()
        {
            return price / 100;
        }

        ~Item()
        {

        }
    }
}
