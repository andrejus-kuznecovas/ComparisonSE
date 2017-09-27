using System;
using System.Collections.Generic;
using System.Linq;

namespace CSE.Source
{
    public class Statistics
    {
        public static DataSet<DateTime, float> GetPriceChangeData(Period period = Period.DEFAULT)
        {
            var data = new DataSet<DateTime, float>();
            data.Add(new DateTime(2017, 9, 26), 1.5f);
            data.Add(new DateTime(2017, 9, 27), 1.7f);
            data.Add(new DateTime(2017, 9, 28), 3.0f);
            //data.Filter(period); // FIX THIS
            return data;
        }

        public static DataSet<string, float> GetProductsData(Period period = Period.DEFAULT)
        {
            var data = new DataSet<string, float>();
            data.Add("Maistas", 7.0f);
            data.Add("Gėrimai", 1.7f);
            data.Add("Namų ruošos prekės", 3.0f);
            data.Add("Kepiniai", 2.7f);
            //data.Filter(period); // FIX THIS
            return data;
        }

    }


    public enum Period {
        DEFAULT, DAY, WEEK, MONTH, YEAR 
    }

}

