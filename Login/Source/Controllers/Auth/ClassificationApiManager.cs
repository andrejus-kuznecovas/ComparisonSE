using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Login.Source.Controllers.Auth
{
    class ClassificationApiManager : ApiManager
    {

        public static FormattedResponse ClassificationRequest(List<string> strings)
        {
            var endpoint = "api/categorise/" + String.Join(",", strings);
            var userJson = MakeSyncGetRequest(baseUrlAI + endpoint);
            return userJson;
        }
    }
}