using System;
using System.Collections.Generic;

namespace Login.Source.Controllers.Receipts
{
    public class ItemGenerator
    {
        private static List<String> _items;

        /// <summary>
        /// Populate list of fake items
        /// </summary>
        public static void Initialize()
        {
            _items = new List<string>();
            _items.Add("Sūrelis");
            _items.Add("Pienas \"Dvaro\"");
            _items.Add("Duona");
            _items.Add("Batonėlis \"Twix\"");
            _items.Add("Šunų ėdalas");
            _items.Add("Sausainiai \"Belvita\"");
            _items.Add("Sausainiai \"Du gaideliai\"");
            _items.Add("Tušinkas");
            _items.Add("Morkos");
            _items.Add("Obuoliai");
            _items.Add("Rūkyta lydeka");
            _items.Add("Pieniškos dešrelės \"IKI\"");
            _items.Add("Vanduo \"Tichė\"");
        }

        /// <summary>
        /// Generate fake list of items, formatted for our parser
        /// </summary>
        /// <returns></returns>
        public static string GenerateItems()
        {
            // List that contains all the randomly generated items
            List<string> itemList = new List<string>();

            // Random number generator
            Random random = new Random();

            // Amount of items (between 2 and 8)
            int length = random.Next(2,8);
            for (int i = 0; i < length; i++)
            {
                // Generate random index of string list
                int itemIndex = random.Next(_items.Count);
                // Add randomly chosen item string to our item list
                itemList.Add(_items[itemIndex]);
            }
            string shoppingList = "";
            foreach (string itemName in itemList) {
                // Merge all the strings, also format them accordingly
                // Random price from 0.5 to 10
                shoppingList += String.Format("{0} {1:F2}A\n",itemName, (random.NextDouble() * (10.0 - 0.5) + 0.5));
            }
            return shoppingList ;
        }
    }
}