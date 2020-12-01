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
        static Random random = new Random();
        static void Main(string[] args)
        {
            (string name, string password)[] register = { ("jeffry123", "abc123"),
                                                        ("GeoffrieMcLargeTesticles", "passwordpasswordpasswordpassword")};
            bool DbExists = File.Exists("passwordTesting.db");
            using (var conn = new SqliteConnection("Data Source = passwordTesting.db"))
            {
                conn.Open();
                if(!DbExists) InitialiseDatabase(conn);
                PopulateDatabase(conn, register);
            }
        }

        private static void PopulateDatabase(SqliteConnection conn, (string name, string password)[] newUsers)
        {
            foreach (var user in newUsers)
            {
                var command = conn.CreateCommand();
                command.CommandText = "INSERT INTO Users(Username, Hashed, Salt) " +
                    "VALUES($name, $hash, $salt)";
                (byte[] hash, byte[] salt) = CalculateSaltedHash(user.password);
                command.Parameters.AddWithValue("$name", user.name);
                command.Parameters.AddWithValue("$hash", hash);
                command.Parameters.AddWithValue("$salt", salt);
                command.ExecuteNonQuery();
            }
        }

        private static void InitialiseDatabase(SqliteConnection conn)
        {
            var command = conn.CreateCommand();
            command.CommandText = 
                "CREATE TABLE Users(" +
                "Username TEXT PRIMARY KEY," +
                "Hashed TEXT," +
                "Salt TEXT)";
            command.ExecuteNonQuery();
        }
        private static bool IsPasswordCorrect(string input)
        {
            byte[] file = File.ReadAllBytes("hash.sha256");
            byte[] hash = file.Take(32).ToArray();
            byte[] salt = file.Skip(32).ToArray();
            SHA256 alg = SHA256.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] foundHash = alg.ComputeHash(ConcatenateByteArrays(inputBytes, salt));
            if (hash.SequenceEqual(foundHash)) return true;
            else return false;

        }
        private static (byte[] hash, byte[] salt) CalculateSaltedHash(string password, byte[] salt = null)
        {
            SHA256 alg = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            if (salt == null || salt.Length != 32)
            {
                salt = new byte[32];
                random.NextBytes(salt);
            }
            byte[] hash = alg.ComputeHash(ConcatenateByteArrays(passwordBytes, salt));
            File.WriteAllBytes("hash.sha256", ConcatenateByteArrays(hash, salt));
            return (hash, salt);
        }
        private static byte[] ConcatenateByteArrays(byte[] arr1, byte[] arr2)
        {
            byte[] combined = new byte[arr1.Length + arr2.Length];
            for (int i = 0; i < arr1.Length; i++)
            {
                combined[i] = arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                combined[i + arr1.Length] = arr2[i];
            }
            return combined;
        }
    }
}
