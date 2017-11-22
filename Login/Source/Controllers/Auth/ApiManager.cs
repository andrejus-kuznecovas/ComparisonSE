using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;
using System.Text;

namespace Login.Source.Controllers
{
    public class ApiManager
    {
        // Save server name to avoid repetition
        protected static string baseUrlDB = "http://billycse.gearhostpreview.com/";


        protected static async void MakePostRequest(string endpoint, string body = "")
        {
            WebRequest request = FormRequest(endpoint, RequestType.POST);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(Uri.EscapeUriString(body));
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();


            JsonObject result = await MakeRequest(request);
        }

        protected static void MakeGetRequest(string endpoint)
        {

        }


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
        internal static WebRequest FormRequest(string url, RequestType type)
        {
            var request = HttpWebRequest.Create(
                new Uri(baseUrlDB + url)
            );
            
            switch (type)
            {
                case RequestType.GET:
                    request.Method = "GET";
                    break;
                case RequestType.POST:
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    break;
            }

            return request;
            
        }
    }

    public enum RequestType
    {
        GET, POST
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