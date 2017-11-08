using System;
using System.Collections.Generic;

namespace Login
{
    public class Receipt 
    {
        // Text to get all the info from
        private string initialText;
        // Receipt total
        public float total { get; set; }
        // Shop ID
        public Shop shop { get; set; }
        // List of all the items bought
        public List<Item> shoppingList { get; set; }
        // When the receipt was purchased
        public DateTime purchaseTime;

        public Receipt()
        {

        }

        public Receipt(string initialText)
        {
            this.initialText = initialText;
            shoppingList = new List<Item>();
            // Save the time of purchase
            purchaseTime = DateTime.Now;
            total = 0f;
            Populate();
        }

        /// <summary>
        /// Fill object with information
        /// </summary>
        private void Populate()
        {
            string[] lines = initialText.Split('\n');
            
            // Find shop name in the text
            shop = Parser.GetShopName(initialText);

            for (int i =0; i<lines.Length; i++)
            {
                // Get price, if it exists
                float priceInLine = Parser.ExtractPriceFloat(lines[i]);

                // Some of the items have weight. Weight is written after the item name and price
                if (Parser.FindEurKg(lines[i]))
                {
                    lines[i] = lines[i - 1];
                }

                // If there is a price in the line
                if (priceInLine != -1000f)
                {
                    total += priceInLine;
                    // If it is negative - it is a discount
                    if (priceInLine > 0)
                    {
                        string itemName = lines[i];
                        Item item = new Item(itemName, priceInLine);
                        
                        // When categorising, it is better to remove all lithuanian letters, quotes, dots, commas, etc.
                        Category itemCategory = Categoriser.GetCategory(Parser.RemoveNonLetters(itemName));
                        item.category = itemCategory;
                        shoppingList.Add(item);
                    }
                }
            }
        }
    }
}
