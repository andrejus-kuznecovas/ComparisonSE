using System;
using System.Threading.Tasks;
using System.Json;
using System.Text;
using System.IO;
using Login.Source.Controllers.Auth;

namespace Login.Source.Controllers
{
    public class ReceiptApiManager : ApiManager
    {
        /// <summary>
        /// Creates new receipt in the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="token"></param>
        /// <param name="receiptJSON"></param>
        /// <returns>Formatted Response containig property "success"</returns>
        public static async Task<FormattedResponse> SaveReceiptData(int ID, string token, string receiptJSON)
        {
            var endpoint = String.Format("receipts/add/user/{0}/token/{1}", ID, token, receiptJSON);
            string body = String.Format("user={0}&token={1}&receipt={2}",ID, token, Uri.EscapeUriString(receiptJSON));
            return await MakeAsyncPostRequest(baseUrlDB + endpoint, body);
        }

        
    }
}