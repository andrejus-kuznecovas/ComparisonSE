using System;
using System.Collections.Generic;
using System.Linq;

namespace CSE.Source
{
    public class DataSet
    {
        public List<Receipt> receipts;

        public DataSet()
        {
            receipts = XmlSerialization.GetReceipts();
        }

        public void Filter(Period period)
        {
            IEnumerable<Receipt> filteredData;
            switch (period)
            {
                #region Filter By Day
                case Period.TODAY:
                    filteredData = this.receipts.Where(
                        receipt =>
                            receipt.purchaseTime.Day == DateTime.Today.Day
                    );
                    break;
                #endregion
                #region Filter By Week

                case Period.WEEK:
                    int delta = DayOfWeek.Monday - DateTime.Today.DayOfWeek;
                    DateTime monday = DateTime.Today.AddDays(delta);
                    DateTime sunday = monday.AddDays(6);

                    filteredData = this.receipts.Where(
                        receipt =>
                            receipt.purchaseTime >= monday &&
                            receipt.purchaseTime <= sunday
                    );
                    break;
                #endregion
                #region Filter By Month
                case Period.MONTH:
                    filteredData = this.receipts.Where(
                        receipt =>
                            receipt.purchaseTime.Month == DateTime.Today.Month &&
                            receipt.purchaseTime.Year == DateTime.Today.Year
                    );
                    break;
                #endregion
                #region Filter By Year
                case Period.YEAR:
                    filteredData = this.receipts.Where(
                        receipt =>
                            receipt.purchaseTime.Month == DateTime.Today.Month &&
                            receipt.purchaseTime.Year == DateTime.Today.Year
                    );
                    break;
                #endregion
                #region Default Filter

                case Period.DEFAULT:
                default:
                    filteredData = this.receipts;
                    break;
                    #endregion
            }


            this.receipts = filteredData.ToList<Receipt>();         
        }
    }
}
