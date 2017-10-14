using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;

namespace Login.Assets
{
    class ApiManager
    {
        private static string baseURL = "http://billycse.gearhostpreview.com/";
        public static async void Login(string username, string password)
        {
            var request = HttpWebRequest.Create(
                new Uri (baseURL + 
                    String.Format("login/username/{0}/password/{1}", username, password)
                )
            );

            request.ContentType = "application/json";
            request.Method = "GET";


            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var jsonResponse = await Task.Run(() => JsonObject.Load(stream));
                    var jsonResponseObject = jsonResponse as JsonObject; // End Object
                }
            }
        }
        
    }
}