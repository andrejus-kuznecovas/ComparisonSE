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
            this.typeId = typeId;
        }

        public int getItemCount()
        {
            return itemCount;
        }

        public double getPrice()
        {
            return price / 100;
        }

        ~Item()
        {

        }
    }
}
