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
            Database db = new Database(@"passwordTesting.db");
            (string, string)[] usersToAdd = new (string, string)[]
            { ("BobTheBeholder", "CacodemonFromDoom*&^*&^*&^"),
            ("JimminyCricket", "joeMama123"),
            ("JoeMama", "PleaseImBeggingYou") };
            if (!db.AddUsers(usersToAdd))
            {
                Console.WriteLine("A Record was already present!!!");
            }
            List<Record> records = db.GetRecords();
            Console.ReadLine();
        }
    }
}
