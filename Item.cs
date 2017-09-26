using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class Item
    {
        private static uint itemCount = 0;

        private double price;
        private string name;
        private string typeName;
        private uint typeId;


        public Item(double price, string name, string typeName)
        {
            this.price = price;
            this.name = name;
            this.typeName = typeName;
        }

        public Item(double price, string name, uint typeId)
        {
            this.price = price;
            this.name = name;
            this.typeId = typeId;
        }

        public double getPrice()
        {
            return this.price;
        }

        public string getName()
        {
            return this.name;
        }

        public string getTypeName()
        {
            return this.typeName;
        }

        public double getTypeID()
        {
            return this.typeId;
        }

        ~Item()
        {

        }
    }
}
