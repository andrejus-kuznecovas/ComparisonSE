using System;
using System.Collections.Generic;
using System.Linq;

namespace CSE.Source
{
    public class Statistics
    {
        public static DataSet GetData(Period period = Period.DEFAULT)
        {
            DataSet data = new DataSet();
            data.Add(1.5f, new DateTime(2017, 9, 26));
            data.Add(1.7f, new DateTime(2017, 9, 27));
            data.Add(1.9f, new DateTime(2017, 9, 28));
            data.Filter(period);
            return data;
        }

    }


    public enum Period {
        DEFAULT, DAY, WEEK, MONTH, YEAR 
    }

}

