using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    enum Category
    {
        Pieno_produktai,
        Duonos_gaminiai,
        Gėrimai,
        Bakalėjos_prekės,
        Namų_apyvokos_prekės,
        Prekės_augintiniams,
        Mėsos_ir_žuvies_produktai,
        Vaisiai_ir_daržovės,
        Saldumynai,
        Buitinė_chemija,
        Higienos_prekės,
        Kitos_prekės
    };

    class Item
    {
        private static uint itemCount = 0;

        private double Price { get; set; }
        private string Name { get; set; }
        private uint TypeId { get;  set; }
        private Category Category { get; set; }

        public Item(double price, string name, uint typeId)
        {
            this.Price = price;
            this.Name = name;
            this.TypeId = typeId;
        }

        ~Item()
        {

        }
    }
}
