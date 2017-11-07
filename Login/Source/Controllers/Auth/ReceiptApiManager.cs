using System;
using System.Threading.Tasks;
using System.Json;
using System.Text;
using System.IO;

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
        /// <returns></returns>
        public static async Task<JsonObject> SaveReceiptData(int ID, string token, string receiptJSON)
        {
            var endpoint = String.Format("receipts/add/user/{0}/token/{1}", ID, token, receiptJSON);
            var request = FormRequest(endpoint,"POST");
            
            UTF8Encoding encoding = new UTF8Encoding();
            string body = String.Format("user={0}&token={1}&receipt={2}",ID, token, Uri.EscapeUriString(receiptJSON));
            byte[] bytes = encoding.GetBytes(Uri.EscapeUriString(body));
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }

            return null;
        }

        
    }
}