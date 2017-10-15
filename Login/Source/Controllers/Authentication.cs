using System;
using System.Collections.Generic;
using System.Json;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Login.Source.Controllers
{
    class Authentication
    {
        public static async Task<bool> Authenticate(string username, string password)
        {
            try
            {
                int id;
                string token;
                var loginInfo = await ApiManager.LoginRequest(username, password);
                id = Int32.Parse(loginInfo["id"]);
                token = loginInfo["token"];
                var succeeded = await InitializeUser(id, token);
                if (succeeded) {
                    return true;
                }
                return false;
            }
            catch (LoginFailedException e)
            {
                return false;
            }
            catch (GetInfoFailedException e)
            {
                return false;
            }
            catch (FormatException e)
            {
                return false;
            }


        }

        public static async Task<bool> Register
            (string name, string surname, string email, string username, string password)
        {
            try
            {
                int id;
                string token;
                System.Diagnostics.Debug.Write("*********************Working up until now******");
                var loginInfo = await ApiManager.RegistrationRequest(name, surname, email, username, password);
                id = Int32.Parse(loginInfo["id"]);
                token = loginInfo["token"];
                bool succeded = await InitializeUser(id, token);
                if (succeded)
                {
                    return true;
                }
                return false;
            }
            catch (RegistrationFailedException e)
            {
                return false;
            }
            catch (GetInfoFailedException e)
            {
                return false;
            }
            catch (FormatException e)
            {
                return false;
            }
        }

        private static async Task<bool> InitializeUser(int id, string token)
        {
            try
            {
                string name;
                string surname;
                JsonObject userInfo = await ApiManager.GetInfo(id, token);
                name = userInfo["name"];
                surname = userInfo["surname"];
                UserController.InitializeUser(id, token, name, surname);
                return true;
            }
            catch(GetInfoFailedException e)
            {
                throw e;
            }
        }

        public static void LogOut()
        {

        }

    }
}