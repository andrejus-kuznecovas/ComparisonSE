using Android.App;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Json;
using System.Net;
using System.Threading.Tasks;

namespace Login.Source.Controllers.Auth
{
    public class StatisticsApiManager : ApiManager
    {
        public static EventHandler<StatisticsEventArgs> OnDataRetrieved;
        /// <summary>
        /// Returns total spendings on each category
        /// </summary>
        /// <returns></returns>
        public static async Task TotalSpendings(int id, string token)
        {
            var endpoint = String.Format("statistics/spendings/user/{0}/token/{1}", id, token);
            var request = FormRequest(endpoint, "GET");

            dynamic userJson;
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonTextReader jsonReader = new JsonTextReader(new StreamReader(stream));
                    var serializer = new JsonSerializer();
                    userJson = serializer.Deserialize(jsonReader);
                }
            }
            
            if (userJson != null)
            {
                System.Diagnostics.Debug.WriteLine((string)userJson.success);
                if (OnDataRetrieved != null)
                {
                    OnDataRetrieved(new Object(), new StatisticsEventArgs(userJson));
                }
            }
            else
            {
                if (OnDataRetrieved != null)
                {
                    OnDataRetrieved(new Object(), new StatisticsEventArgs(null));
                }
            }


        }

        public static async Task PriceChange(Category category)
        {
            var endpoint = String.Format("statistics/price_change/category/{0}", (int)category);
            var request = FormRequest(endpoint, "GET");

            dynamic userJson;
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonTextReader jsonReader = new JsonTextReader(new StreamReader(stream));
                    var serializer = new JsonSerializer();
                    userJson = serializer.Deserialize(jsonReader);
                }
            }

            if (userJson != null)
            {
                
                if (OnDataRetrieved != null)
                {
                    OnDataRetrieved(new Object(), new StatisticsEventArgs(userJson));
                }
            }
            else
            {
                if (OnDataRetrieved != null)
                {
                    OnDataRetrieved(new Object(), new StatisticsEventArgs(null));
                }
            }

        }
    }

    public class StatisticsEventArgs : EventArgs
    {
        public StatisticsEventArgs(dynamic data)
        {
            this.statistics = data;
        }
        public dynamic statistics;
    }
}