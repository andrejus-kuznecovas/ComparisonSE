using System;

namespace CSE.Source
{
    public class StatisticsManager
    {
        public static DataSet GetPriceChangeData(Period period = Period.DEFAULT)
        {
            var data = new DataSet();
            return data;
        }

        public static DataSet GetProductsData(Period period = Period.DEFAULT)
        {
            var data = new DataSet();
            //data.Filter(Period.WEEK);
            return data;
        }

    }


    public enum Period {
        DEFAULT, DAY, WEEK, MONTH, YEAR 
    }

}

