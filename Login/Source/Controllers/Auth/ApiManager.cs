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
        private static string baseURL = "http://billycse.gearhostpreview.com/";

        /// <summary>
        /// Makes asynchronous Login request to the server to get User ID and token from server
        /// </summary>
        /// <param name="username">Username to login with</param>
        /// <param name="password">Password to login with</param>
        /// <returns>JSON object containing user data if Login operation was successful</returns>
        public static async Task< JsonObject > LoginRequest(string username, string password)
        {
            var request = HttpWebRequest.Create(
                new Uri (baseURL + 
                    String.Format("login/username/{0}/password/{1}", username, password)
                )
            );

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }

            return null;
        }


        /// <summary>
        /// Makes asynchronous Registration request to the server and gets User ID and token from server
        /// </summary>
        /// <param name="name">Name to register with</param>
        /// <param name="surname">Surname to register with</param>
        /// <param name="email">Email to register with</param>
        /// <param name="username">Username to register with</param>
        /// <param name="password">Password to register with</param>
        /// <returns>JSON object containing user data if Login operation was successful</returns>
        public static async Task<JsonObject> RegistrationRequest
            (string name, string surname, string email, string username, string password)
        {
            // Save all the registration fields in an array of objects
            var parameters = new object[] { name, surname, email, username, password };
            var request = HttpWebRequest.Create(
                
                new Uri(baseURL +
                    String.Format("register/name/{0}/surname/{1}/email/{2}/username/{3}/password/{4}"
                    , parameters)
                )
            );

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }
            return null;
        }
        /// <summary>
        /// Makes asynchronous request to get User information from the server
        /// </summary>
        /// <param name="id">Unique ID of a user</param>
        /// <param name="token">Unique token of a user</param>
        /// <returns>User info JSON object if request was successful</returns>
        public static async Task<JsonObject> GetInfo(int id, string token)
        {
                var request = HttpWebRequest.Create(
                    new Uri(baseURL +
                        String.Format("info/user/{0}/token/{1}", id.ToString(), token)
                    )
                );

                JsonObject userJson = await MakeRequest(request);

                if (CheckForSuccess(userJson))
                {
                    return userJson;
                }
                return null;

        }

        /// <summary>
        /// Performs specified request to the server
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>User data if request was successful</returns>
        private static async Task<JsonObject> MakeRequest(WebRequest request)
        {
            request.ContentType = "application/json";
            request.Method = "GET";
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
        private static bool CheckForSuccess(JsonObject data)
        {
            // Server returns JSON object containing field "success", which indicates
            // whether the request was successful
            bool succeeded = Boolean.Parse(data["success"].ToString());

            return succeeded;
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