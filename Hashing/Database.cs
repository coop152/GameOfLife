using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hashing
{
    class Database
    {
        // Fields
        private SqliteConnection Connection;
        private string FileName;
        private bool IsNew;
        // Public Methods
        public Database(string fileName)
        {
            FileName = fileName;
            IsNew = !File.Exists(fileName);
            Connection = new SqliteConnection($@"Data Source = {fileName}");
            Connection.Open();
            if (IsNew) InitialiseDatabase();
        }
        public bool AddUser(string userName, string password)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO Users(Username, Hashed, Salt) " +
                "VALUES($name, $hash, $salt)";
            (byte[] hash, byte[] salt) = PasswordGen.NewSaltedHash(password);
            try
            {
                command.Parameters.AddWithValue("$name", userName);
                command.Parameters.AddWithValue("$hash", hash);
                command.Parameters.AddWithValue("$salt", salt);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqliteException)
            {
                return false;
            }
        }
        public bool AddUsers((string userName, string password)[] users)
        {
            bool successful = true;
            foreach (var user in users)
            {
                successful &= AddUser(user.userName, user.password);
            }
            return successful;
        }

        public enum PasswordCheck
        {
            Correct,
            Incorrect,
            WrongUsername
        }
        public PasswordCheck CheckPassword(string inputUsername, string inputPassword)
        {
            SqliteCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT Hashed, Salt FROM Users WHERE Username = $name";
            command.Parameters.AddWithValue("$name", inputUsername);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read()) //if user present
                {
                    byte[] generatedHash = PasswordGen.GenerateHash(inputPassword, (byte[])reader["Salt"]);
                    if (generatedHash.SequenceEqual( (byte[])reader["Hashed"] ))
                        return PasswordCheck.Correct;
                    else
                        return PasswordCheck.Incorrect;
                }
                else
                {
                    return PasswordCheck.WrongUsername;
                }
            }
        }

        public void ResetDatabase()
        {
            Connection.Close();
            File.Delete(FileName);
            Connection = new SqliteConnection($@"Data Source = {FileName}");
            Connection.Open();
            InitialiseDatabase();
        }
        public List<Record> GetRecords()
        {
            List<Record> records = new List<Record>();
            var command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM Users";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Record record = new Record();
                    record.Username = (string)reader["Username"];
                    record.Hashed = (byte[])reader["Hashed"];
                    record.Salt = (byte[])reader["Salt"];
                    records.Add(record);
                }
            }
            return records;
        }
        // Private Methods
        private void InitialiseDatabase()
        {
            var command = Connection.CreateCommand();
            command.CommandText =
                "CREATE TABLE Users(" +
                "Username TEXT PRIMARY KEY," +
                "Hashed TEXT," +
                "Salt TEXT)";
            command.ExecuteNonQuery();
        }

    }
}
