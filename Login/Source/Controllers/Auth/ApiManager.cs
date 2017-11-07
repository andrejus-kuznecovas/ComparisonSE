using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;

namespace Login.Source.Controllers
{
    public class ApiManager
    {
        // Save server name to avoid repetition
        protected static string baseURL = "http://billycse.gearhostpreview.com/";



        /// <summary>
        /// Performs specified request to the server
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>User data if request was successful</returns>
        protected static async Task<JsonObject> MakeRequest(WebRequest request)
        {

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    // Save server response to JSON object
                    var jsonResponse = await Task.Run(() => JsonObject.Load(stream));
                    var userJson = jsonResponse as JsonObject; // End Object
                    
                    return userJson;
                }
            }
        }

        /// <summary>
        /// Used to check whether request data is correct
        /// </summary>
        /// <param name="data">JSON Object - data from the server</param>
        /// <returns></returns>
        protected static bool CheckForSuccess(JsonObject data)
        {
            // Server returns JSON object containing field "success", which indicates
            // whether the request was successful
            bool succeeded = Boolean.Parse(data["success"].ToString());

            return succeeded;
        }


        /// <summary>
        /// Forms request with specified endpoint and method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        internal static WebRequest FormRequest(string url, string method)
        {
            var request = HttpWebRequest.Create(
                new Uri(baseURL + url)
            );
            
            switch (method)
            {
                case "GET":
                    request.Method = "GET";
                    break;
                case "POST":
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
                case "PUT":
                    request.Method = "PUT";
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
            }

            return request;
            
        }
    }

    public enum RequestType
    {
        LOGIN, REGISTER, GET_INFO
    }

    public class LoginFailedException : Exception
    {

    }

    public class RegistrationFailedException : Exception
    {

    }

    public class GetInfoFailedException : Exception
    {

    }
}