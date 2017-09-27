
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSE.Source
{
    [Serializable]
    class Receipt: ISerializable
    {
        private string initialText;
        public float total { get; private set; }
        public Shop shop { get; private set; }
        public List<string> shoppingList { get; private set; } // TO BE REPLACED BY SHOP ITEM LIST
        public DateTime purchaseTime;

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
                        shoppingList.Add(line);
                    }
                }
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("total", total, typeof(float));
            info.AddValue("shop", shop, typeof(Shop));
            info.AddValue("items", shoppingList, typeof(List<string>));
            info.AddValue("date", purchaseTime, typeof(DateTime));
        }
    }
}
