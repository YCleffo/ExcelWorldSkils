using ExcelWorldSkils.Model;
using ExcelWorldSkils.View.Model;
using System;
using System.Linq;

namespace ExcelWorldSkils.ViewModel
{
    public class UsersViewModel
    {
        Core db = new Core();
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
        public void AddUser(string login)
        {
            Users newUser = new Users()
            {
                //Login = LogInTextBox.Text,
                //Password = PasswordTextBox.Text,
            };

            db.context.Users.Add(newUser);
            db.context.SaveChanges();
        }
    }
}
