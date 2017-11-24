﻿using System;
using System.Threading.Tasks;

namespace Login.Source.Controllers
{
    class Authentication
    {
        /// <summary>
        /// Authenticate (Log in) user using provided credentials
        /// </summary>
        /// <param name="username">Username to login with</param>
        /// <param name="password">Password to login with</param>
        /// <returns></returns>
        public static async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                // User credentials
                int id;
                string token;

                // Make Login request to the server with provided credentials
                var loginInfo = await AuthApiManager.LoginRequest(username, password);
                if (loginInfo != null)
                {
                    if (loginInfo.HasProperty("id") && loginInfo.HasProperty("token"))
                    {
                        id = Int32.Parse((string)loginInfo.GetProperty("id").Value);
                        token = (string)loginInfo.GetProperty("token").Value;
                    }
                    else
                    {
                        return false;
                    }

                    

                    // Check if initialization was performed correctly
                    var succeeded = await InitializeUser(id, token);
                    if (succeeded)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            //catch (LoginFailedException e)
            //{
            //    return false;
            //}
            //catch (GetInfoFailedException e)
            //{
            //    return false;
            //}
            catch (FormatException e)
            {
                return false;
            }


        }

        /// <summary>
        /// Register new User using provided credentials
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<bool> Register
            (string name, string surname, string email, string username, string password)
        {
            try
            {
                // Credentials
                int id;
                string token;
                
                // Make registration request using credentials
                var loginInfo = await AuthApiManager.RegistrationRequest(name, surname, email, username, password);

                if (loginInfo.HasProperty("id") && loginInfo.HasProperty("token"))
                {
                    id = Int32.Parse((string)loginInfo.GetProperty("id").Value);
                    token = (string)loginInfo.GetProperty("token").Value;
                }
                else
                {
                    return false;
                }

                bool succeded = await InitializeUser(id, token);
                if (succeded)
                {
                    return true;
                }
                return false;
            }
            //catch (RegistrationFailedException e)
            //{
            //    return false;
            //}
            //catch (GetInfoFailedException e)
            //{
            //    return false;
            //}
            catch (FormatException e)
            {
                return false;
            }
        }

        /// <summary>
        /// Get data about User and save it
        /// </summary>
        /// <param name="id">Unique ID of a </param>
        /// <param name="token"></param>
        /// <returns></returns>
        private static async Task<bool> InitializeUser(int id, string token)
        {
            try
            {
                // Credentials
                string name;
                string surname;

                // Get info about the user using provided credentials
                var userInfo = await AuthApiManager.GetInfo(id, token);

                if (userInfo.HasProperty("name") && userInfo.HasProperty("surname"))
                {
                    name = (string)userInfo.GetProperty("name").Value;
                    surname = (string)userInfo.GetProperty("surname").Value;
                }
                else
                {
                    return false;
                }


                // Create new User instance
                UserController.InitializeUser(id, token, name, surname);
                return true;
            }
            //catch(GetInfoFailedException e)
            //{
            //    throw e;
            //}
            catch (Exception e)
            {
                return false;
            }
        }

        public static void LogOut()
        {
            // TODO: To be implemented
        }

    }
}