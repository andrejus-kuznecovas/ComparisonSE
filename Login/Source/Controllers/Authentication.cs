using System;
using System.Collections.Generic;
using System.Json;
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
                string name;
                string surname;
                var loginInfo = await ApiManager.LoginRequest(username, password);
                id = Int32.Parse(loginInfo["id"]);
                token = loginInfo["token"];
                JsonObject userInfo = await ApiManager.GetInfo(id, token);
                name = userInfo["name"];
                surname = userInfo["surname"];
                UserController.InitializeUser(id, token, name, surname);
                return true;
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

        public static void LogOut()
        {

        }

    }
}