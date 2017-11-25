using System;
using System.Threading.Tasks;
using Login.Source.Controllers.Auth;

namespace Login.Source.Controllers
{
    public class AuthApiManager : ApiManager
    {

        /// <summary>
        /// Makes asynchronous Login request to the server to get User ID and token from server
        /// </summary>
        /// <param name="username">Username to login with</param>
        /// <param name="password">Password to login with</param>
        /// <returns>Formatted Response containing properties "id" and "token"</returns>
        public static async Task< FormattedResponse > LoginRequest(string username, string password)
        {
            
            var endpoint = String.Format("login/username/{0}/password/{1}", username, password);
            return await MakeAsyncGetRequest(baseUrlDB + endpoint);
        }


        /// <summary>
        /// Makes asynchronous Registration request to the server and gets User ID and token from server
        /// </summary>
        /// <param name="name">Name to register with</param>
        /// <param name="surname">Surname to register with</param>
        /// <param name="email">Email to register with</param>
        /// <param name="username">Username to register with</param>
        /// <param name="password">Password to register with</param>
        /// <returns>Formatted Response containing properties "id" and "token"</returns>
        public static async Task<FormattedResponse> RegistrationRequest
            (string name, string surname, string email, string username, string password)
        {
            // Save all the registration fields in an array of objects
            var parameters = new object[] { name, surname, email, username, password };
            var endpoint = String.Format("register/name/{0}/surname/{1}/email/{2}/username/{3}/password/{4}", parameters);
            return await MakeAsyncGetRequest(baseUrlDB + endpoint);
        }


        /// <summary>
        /// Makes asynchronous request to get User information from the server
        /// </summary>
        /// <param name="id">Unique ID of a user</param>
        /// <param name="token">Unique token of a user</param>
        /// <returns>Formatted Response containing properties "name", "surname", "email"</returns>
        public static async Task< FormattedResponse > GetInfo(int id, string token)
        {
            var endpoint = String.Format("info/user/{0}/token/{1}", id.ToString(), token);
            return await MakeAsyncGetRequest(baseUrlDB + endpoint);
        }

        
    }
}