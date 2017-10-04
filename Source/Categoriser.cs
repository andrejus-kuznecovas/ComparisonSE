using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace CSE.Source
{
    public class Categoriser
    {
        public static Category GetCategory(Item item)
        {
            XDocument productsXml = GetData("../../Source/Data/products.xml");
            string categoryString = FilterByName(productsXml, item.GetName());
            if (categoryString == null)
            {
                return Category.UNKNOWN_CATEGORY;
            }
            else
            {
                return (Category)Enum.Parse(typeof(Category), categoryString);
            }
            
        }

        private static XDocument GetData(string path)
        {
            XDocument productCategories = XDocument.Load(path);
            return productCategories;                
        }

        private static string FilterByName(XDocument document, string name)
        {
            Console.WriteLine(name);
            var categoryName = from product in document.Descendants("Product")
                               where (string)product.Element("Name") == name
                               select (string)product.Parent.Parent.Attribute("name");
            try
            {
                return categoryName.First();
            }
            catch (Exception e)
            {
                return null;
            }
            
        }
    }
}
