﻿namespace Login.Source.Controllers
{
    public class UserController
    {
        #region User
        private class User
        {
            private int id;
            private string name;
            private string surname;
            private string authToken;

            public User(int id, string authToken, string name, string surname)
            {
                this.id = id;
                this.authToken = authToken;
                this.name = name;
                this.surname = surname;
            }

            public string GetName()
            {
                return name;
            }

            public string GetSurname()
            {
                return surname;
            }

            public string GetToken()
            {
                return authToken;
            }

            public int GetID()
            {
                return id;
            }
        }
        #endregion

        private static User currentUser = null;

        public static void InitializeUser(int id, string token, string name, string surname)
        {
            currentUser = new User(id, token, name, surname);
        }

        public static void RemoveUser()
        {
            currentUser = null;
        }

        public static string UserName
        {
            get
            {
                if (currentUser != null)
                {
                    return currentUser.GetName();
                }
                return null; // CAN BE REPLACED WITH EXCEPTION
            }
        }

        public static string UserSurname
        {
            get
            {
                if (currentUser != null)
                {
                    return currentUser.GetSurname();
                }
                return null; // CAN BE REPLACED WITH EXCEPTION
            }
        }

        public static string UserToken
        {
            get
            {
                if (currentUser != null)
                {
                    return currentUser.GetToken();
                }
                return null; // CAN BE REPLACED WITH EXCEPTION
            }
        }

        public static int GetUserID
        {
            get
            {
                if (currentUser != null)
                {
                    return currentUser.GetID();
                }
                return -1; // CAN BE REPLACED WITH EXCEPTION
            }
        }

    }
}