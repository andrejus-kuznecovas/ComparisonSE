using System;
using System.Collections.Generic;

namespace Login
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
            purchaseTime = DateTime.Now;
            total = 0f;
            Populate();
        }

        private void Populate()
        {
            string[] lines = initialText.Split('\n');
            
            shop = Parser.GetShopName(initialText);

            for (int i =0; i<lines.Length; i++)
            {
                
                float priceInLine = Parser.ExtractPriceFloat(lines[i]);
                if (Parser.FindEurKg(lines[i]))
                {
                    lines[i] = lines[i - 1];
                   
                }
                if (priceInLine != -1000f)
                {
                    total += priceInLine;
                    if (priceInLine > 0)
                    {
                   
                       Item item = new Item(Parser.RemoveNonLetters(lines[i]), priceInLine);
                        Category itemCategory = Categoriser.GetCategory(item);
                        item.category = itemCategory;
                        shoppingList.Add(item);
                    }
                }
            }
        }
    }
}
