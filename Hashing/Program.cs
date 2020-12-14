using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace Hashing
{
    class Program
    {
        static void Main()
        {
            //(string, string)[] usersToAdd = new (string, string)[]
            //{ ("BobTheBeholder", "CacodemonFromDoom*&^*&^*&^"),
            //("JimminyCricket", "joeMama123"),
            //("JoeMama", "PleaseImBeggingYou") };
            //if (!db.AddUsers(usersToAdd))
            //{
            //    Console.WriteLine("Username already taken. ");
            //}
            Database db = new Database(@"passwordTesting.db");
            List<Record> records = db.GetRecords();
            while (true)
            {
                Console.Write("Username: ");
                string inputUsername = Console.ReadLine();
                Console.Write("Password: ");
                string inputPassword = Console.ReadLine();
                var result = db.CheckPassword(inputUsername, inputPassword);
                switch (result)
                {
                    case Database.PasswordCheck.Correct:
                        {
                            Console.WriteLine("Password Correct");
                            break;
                        }
                    case Database.PasswordCheck.Incorrect:
                        {
                            Console.WriteLine("Password Incorrect");
                            break;
                        }
                    case Database.PasswordCheck.WrongUsername:
                        {
                            Console.WriteLine("Username Nonexistent");
                            break;
                        }
                }
            }
        }
    }
}
