using ExcelWorldSkils.Model;
using ExcelWorldSkils.View.Model;
using System;
using System.Linq;

namespace ExcelWorldSkils.ViewModel
{
    public class UsersViewModel
    {
       static Core db = new Core();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool LoginCheck(string login)
        {
            string correctSymbols = "abcdefghijklmnoprstuvwyz0123456789-_.";
            login = login.ToLower();
            if (!login.All(x => correctSymbols.Contains(x)))
            {
                throw new Exception("Логин содержит недопустимые символы");
            }
            if (login == string.Empty)
            {
                throw new Exception("Вы не ввели логин");
            }
            if (login.EndsWith("."))
            {
                throw new Exception("Логин не может заканчиваться символом 'точка'");
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool AddUser(string login,string pass)
        {
            Users newUser = new Users()
            {
                Login = login,
                Password = pass,
            };

            db.context.Users.Add(newUser);
            if (db.context.SaveChanges()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
