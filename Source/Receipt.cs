
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSE.Source
{
    public class Receipt
    {
        private string initialText;
        public float total { get; set; }
        public Shop shop { get; set; }
        public List<Item> shoppingList { get; set; } // TO BE REPLACED BY SHOP ITEM LIST

        public DateTime purchaseTime;

        public Receipt()
        {

        }

        public Receipt(string initialText)
        {
            this.initialText = initialText;
            shoppingList = new List<Item>();
            purchaseTime = DateTime.Today;
            total = 0f;
            Populate();
        }

        private void Populate()
        {
            string[] lines = initialText.Split('\n');
            shop = Parser.GetShopName(initialText);

            foreach (string line in lines)
            {
                float priceInLine = Parser.ExtractPriceFloat(line);
                if (priceInLine != -1000f)
                {
                    total += priceInLine;
                    if (priceInLine > 0)
                    {
                        Item item = new Item(Parser.RemoveNonLetters(line), (int)(priceInLine *100));
                        Category itemCategory = Categoriser.GetCategory(item);
                        item.category = itemCategory;
                        shoppingList.Add(item);
                    }
                }
            }
        }
    }
}
