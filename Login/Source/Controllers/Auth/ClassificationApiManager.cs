using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login.Source.Controllers.Auth
{
    class ClassificationApiManager : ApiManager
    {
        /// <summary>
        /// Sends list of string to the server to categorise them
        /// </summary>
        /// <param name="strings"></param>
        /// <returns>Formatted Response containing "categories" Property with all the categories in the same order as in
        /// argument list</returns>
        public static FormattedResponse ClassificationRequest(List<string> strings)
        {
            var endpoint = "api/categorise/" + String.Join(",", strings);
            var userJson = MakeSyncGetRequest(baseUrlAI + endpoint);
            return userJson;
        }
    }
}