
using System.Collections.Generic;

namespace CSE.Source
{
    class Receipt
    {
        private string initialText;
        private float total;
        private Shop shop;
        private List<string> shoppingList = new List<string>(); // TO BE REPLACED BY SHOP ITEM LIST

        public Receipt(string initialText)
        {
            this.initialText = initialText;
            total = 0f;
            Analyse();
        }

        private void Analyse() {
            string[] lines = initialText.Split('\n');

            foreach (string line in lines)
            {
                float priceInLine = Parser.ExtractPriceFloat(line);
                if (priceInLine != -1000f)
                {
                    total += priceInLine;
                    if (priceInLine > 0)
                    {
                        shoppingList.Add(line);
                    }
                    
                }

            }
        }

        public float GetTotal() {
            return total;
        }

        public Shop GetShop()
        {
            return Parser.GetShopName(initialText);        
        }

        public List<string> GetShoppingList() {
            return shoppingList;
        }
    }
}
