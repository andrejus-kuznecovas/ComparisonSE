﻿using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;
using System.Collections.Generic;

namespace Login.Source.Controllers
{
    public class ApiManager
    {
        private static string baseURL = "http://billycse.gearhostpreview.com/";

        public static async Task< JsonObject > LoginRequest(string username, string password)
        {
            var request = HttpWebRequest.Create(
                new Uri (baseURL + 
                    String.Format("login/username/{0}/password/{1}", username, password)
                )
            );

            JsonObject userJson = await MakeRequest(request);

            bool succeeded = Boolean.Parse(userJson["success"].ToString());
            if (!succeeded)
            {
                throw new LoginFailedException();
            }

            return userJson;
        }

        public static async Task<JsonObject> GetInfo(int id, string token)
        {
            try
            {
                var request = HttpWebRequest.Create(
                    new Uri(baseURL +
                        String.Format("info/user/{0}/token/{1}", id.ToString(), token)
                    )
                );

                JsonObject userJson = await MakeRequest(request);


                bool succeeded = Boolean.Parse(userJson["success"].ToString());

                if (!succeeded)
                {
                    throw new GetInfoFailedException();
                }

                return userJson;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("{0} {1}",
                    e.Message, e.StackTrace);
                return new JsonObject();
            }

        }

        private static async Task<JsonObject> MakeRequest(WebRequest request)
        {
            request.ContentType = "application/json";
            request.Method = "GET";
            using (WebResponse response = await request.GetResponseAsync())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var jsonResponse = await Task.Run(() => JsonObject.Load(stream));
                    var userJson = jsonResponse as JsonObject; // End Object
                    
                    return userJson;
                }
            }
        }
    }

    public class LoginFailedException : Exception
    {

    }

    public class GetInfoFailedException : Exception
    {

    }
}