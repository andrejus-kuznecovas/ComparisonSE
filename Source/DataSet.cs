using System;
using System.Collections.Generic;
using System.Linq;

namespace CSE.Source
{
    public class DataSet
    {
        private List<Receipt> receipts;

        public DataSet()
        {
            receipts = new List<Receipt>();
        }

        public void Filter(Period period)
        {
            IEnumerable<Receipt> filteredData;
            switch (period)
            {
                #region Filter By Day
                case Period.DAY:
                    filteredData = this.receipts.Where(
                        receipt =>
                            receipt.purchaseTime == DateTime.Today
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


            this.receipts.Clear();
            foreach (Receipt receipt in filteredData)
            {
                this.receipts.Add(receipt);
            }

        }
    }
}
