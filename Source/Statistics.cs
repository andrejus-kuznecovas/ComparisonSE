using System;
using System.Collections.Generic;

namespace CSE.Source
{
    public class StatisticsManager
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
            return data;
        }

    }


    public enum Period {
        DEFAULT, TODAY, WEEK, MONTH, YEAR 
    }

}

