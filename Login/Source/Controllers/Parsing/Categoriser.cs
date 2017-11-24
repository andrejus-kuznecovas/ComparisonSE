using Login.Source.Controllers.Auth;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login
{
    public class Categoriser
    {
        /// <summary>
        /// Detects category in text
        /// </summary>
        /// <param name="itemNames"></param>
        /// <returns></returns>
        public static List<Category> GetCategories(List<string> itemNames)
        {
            FormattedResponse response = ClassificationApiManager.ClassificationRequest(itemNames);

            if (response.HasProperty("categories"))
            {
                List<Category> itemCategories = new List<Category>();
                var categories = response.GetProperty("categories");
                if (categories.IsArray)
                {
                    
                    foreach (var category in (JToken)categories.Value)
                    {
                        itemCategories.Add((Category)Enum.Parse(typeof(Category), category.ToString()));
                    }
                    return itemCategories;
                }
                return null;
            }
            return null;
        }


    }
}
