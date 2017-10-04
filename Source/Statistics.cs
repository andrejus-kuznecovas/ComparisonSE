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

        public static Dictionary<string, double> itemListToDictionary(List<Item> shoppingList)
        {
            Dictionary<string, double> groups = new Dictionary<string,double>();
            var values = Enum.GetValues(typeof(Category));
            foreach (Category category in values)
            {
                groups.Add(category.ToString(), 0);
            }

            for (int i = 0; i < shoppingList.Count; i++)
            {
                groups[shoppingList[i].category.ToString()] += shoppingList[i].getPrice();
                
            }
            return groups;
        }
    }


    public enum Period {
        DEFAULT, TODAY, WEEK, MONTH, YEAR 
    }

}

