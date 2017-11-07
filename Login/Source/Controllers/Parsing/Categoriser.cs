using Android.App;
using Android.Content.Res;
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Login
{
    public class Categoriser
    {
        /// <summary>
        /// Detects category in text
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public static Category GetCategory(string itemName)
        {
            // Read the XML file from assets
            AssetManager assets = Application.Context.Assets;
            XDocument productsXml = GetData(assets.Open("products.xml"));


            string categoryString = FilterByName(productsXml, itemName);
            if (categoryString == null)
            {
                return Category.UNKNOWN_CATEGORY;
            }
            else
            {
                return (Category)Enum.Parse(typeof(Category), categoryString);
            }
            
        }

        /// <summary>
        /// Get data from path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static XDocument GetData(Stream path)
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
