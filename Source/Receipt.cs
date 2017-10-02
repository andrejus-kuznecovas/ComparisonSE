
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
        public List<string> shoppingList { get; set; } // TO BE REPLACED BY SHOP ITEM LIST
        public DateTime purchaseTime;

        public Receipt()
        {

        }

        public Receipt(string initialText)
        {
            this.initialText = initialText;
            shoppingList = new List<string>();
            purchaseTime = DateTime.Today;
            total = 0f;
            Analyse();
        }

        private void Analyse()
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
                        //Item item = new Item();
                        shoppingList.Add(line);
                    }
                }
            }
        }
    }
}
