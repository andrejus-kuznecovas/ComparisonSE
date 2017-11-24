using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Login.Source.Controllers.Auth;

namespace Login.Source.Controllers
{
    public class ApiManager
    {
        // Save server name to avoid repetition
        protected static string baseUrlDB = "http://billycse.gearhostpreview.com/";
        protected static string baseUrlAI = "https://serene-fortress-77904.herokuapp.com/";


        protected static async Task<FormattedResponse> MakeAsyncPostRequest(string endpoint, string body = "")
        {
            WebRequest request = FormRequest(endpoint, RequestType.POST);
            AddBody(request, body);
            JObject result = await MakeAsyncRequest(request);
            return FormattedResponseFactory.FromDynamicJObject(result);
        }

        protected static async Task<FormattedResponse> MakeAsyncGetRequest(string endpoint)
        {
            WebRequest request = FormRequest(endpoint, RequestType.GET);
            JObject result = await MakeAsyncRequest(request);
            FormattedResponse response = FormattedResponseFactory.FromDynamicJObject(result);
            return response;
        }

        protected static FormattedResponse MakeSyncPostRequest(string endpoint, string body = "")
        {
            WebRequest request = FormRequest(endpoint, RequestType.POST);
            AddBody(request, body);
            JObject result = MakeRequest(request);
            return FormattedResponseFactory.FromDynamicJObject(result);
        }

        protected static FormattedResponse MakeSyncGetRequest(string endpoint)
        {
            WebRequest request = FormRequest(endpoint, RequestType.GET);
            JObject result = MakeRequest(request);
            FormattedResponse response = FormattedResponseFactory.FromDynamicJObject(result);
            return response;
        }


        private static void AddBody(WebRequest request, string body)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(Uri.EscapeUriString(body));
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();
        }

        /// <summary>
        /// Performs specified request to the server
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>User data if request was successful</returns>
        protected static async Task<dynamic> MakeAsyncRequest(WebRequest request)
        {
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
            return userJson;
        }

        protected static dynamic MakeRequest(WebRequest request)
        {
            dynamic userJson;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    JsonTextReader jsonReader = new JsonTextReader(new StreamReader(stream));
                    var serializer = new JsonSerializer();
                    userJson = serializer.Deserialize(jsonReader);
                }
            }
            return userJson;
        }


        /// <summary>
        /// Forms request with specified endpoint and method
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        internal static WebRequest FormRequest(string endpoint, RequestType type)
        {
            var request = HttpWebRequest.Create(
                new Uri(endpoint)
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
}