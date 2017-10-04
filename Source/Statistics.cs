using System;
using System.Collections.Generic;

namespace CSE.Source
{
    public class Statistics
    {
        public static DataSet GetPriceChangeData(Period period = Period.DEFAULT)
        {
            var data = new DataSet();
            data.Filter(period);
            return data;
        }

        public static DataSet GetProductsData(Period period = Period.DEFAULT)
        {
            var data = new DataSet();
            //data.Filter(Period.WEEK);

            return data;
        }

        public static Dictionary<string, int> itemListToDictionary(List<Item> shoppingList)
        {
            Dictionary<string, int> groups = new Dictionary<string, int>();
            var values = Enum.GetValues(typeof(Category));
            foreach (Category a in values)
            {
                groups.Add(a.ToString(), 0);
            }

            for (int i = 0; i < shoppingList.Count; i++)
            {
                groups[shoppingList[i].Category.ToString()] += (int)shoppingList[i].Price;
                
            }
            return groups;
        }
    }


    public enum Period {
        DEFAULT, TODAY, WEEK, MONTH, YEAR 
    }

}

