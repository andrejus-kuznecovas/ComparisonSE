using System;
using System.Collections.Generic;
using System.Linq;

namespace CSE.Source
{
    public class DataSet : Dictionary<float, DateTime>
    {
        public void Filter(Period period)
        {
            IEnumerable<KeyValuePair<float, DateTime>> filteredData;
            switch (period)
            {
            #region Filter By Day
                case Period.DAY:
                    filteredData = this.Where(
                        item =>
                            item.Value == DateTime.Today
                    );
                    break;
                #endregion
            #region Filter By Week
                case Period.WEEK:
                    int delta = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
                    DateTime monday = DateTime.Today.AddDays(delta);
                    DateTime sunday = monday.AddDays(6);

                    filteredData = this.Where(
                        item =>
                            item.Value >= monday &&
                            item.Value <= sunday
                    );
                    break;
                #endregion
            #region Filter By Month
                case Period.MONTH:
                    filteredData = this.Where(
                        item =>
                            item.Value.Month == DateTime.Today.Month &&
                            item.Value.Year == DateTime.Today.Year
                    );
                    break;

                #endregion
            #region Filter By Year
                case Period.YEAR:
                    filteredData = this.Where(
                        item =>
                            item.Value.Month == DateTime.Today.Month &&
                            item.Value.Year == DateTime.Today.Year
                    );
                    break;
                #endregion
            #region Default Filter
                case Period.DEFAULT:
                default:
                    filteredData = this.AsEnumerable<KeyValuePair<float, DateTime>>();
                    break;
            }
            #endregion

            this.Clear();
            foreach (KeyValuePair<float, DateTime> item in filteredData)
            {
                this.Add(item.Key, item.Value);
            }
            
        }
    }
}
