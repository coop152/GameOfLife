﻿using Graphical_Game_Of_Life;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hashing
{
    public class Database
    {
        // Fields
        private SqliteConnection Connection;
        private readonly string FileName;
        // Public Methods
        public Database(string fileName)
        {
            FileName = fileName;
            Connection = new SqliteConnection($@"Data Source = {fileName}");
            Connection.Open();
            if (!File.Exists(fileName)) InitialiseDatabase(); //If db file doesnt exist
        }
        public bool AddUser(string userName, string password)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO User(Username, Hashed, Salt) " +
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
            foreach (var (userName, password) in users)
            {
                successful &= AddUser(userName, password);
            }
            return successful;
        }
        public LoginValidity CheckPassword(string inputUsername, string inputPassword)
        {
            SqliteCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT Hashed, Salt FROM User WHERE Username = $name";
            command.Parameters.AddWithValue("$name", inputUsername);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read()) //if user present
                {
                    byte[] generatedHash = PasswordGen.GenerateHash(inputPassword, (byte[])reader["Salt"]);
                    if (generatedHash.SequenceEqual( (byte[])reader["Hashed"] ))
                        return LoginValidity.GoodLogin;
                    else
                        return LoginValidity.BadPassword;
                }
                else
                {
                    return LoginValidity.BadUsername;
                }
            }
        }
        public string[] ListSavegames(string username)
        {
            List<string> saveNames = new List<string>();
            SqliteCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT Save.SaveName FROM Save, User, UserSave WHERE " +
                "Save.SaveID = UserSave.SaveID AND User.Username = UserSave.Username " +
                "AND User.Username = $name";
            command.Parameters.AddWithValue("$name", username);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read()) //while saves still left
                {
                    string retrievedName = (string)reader["SaveName"];
                    saveNames.Add(retrievedName);
                }
            }
            return saveNames.ToArray();
        }
        public bool AddSavegame(Savegame save, string username)
        {
            //insert new Save
            var command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO Save(SaveName, Field, Columns, Rows) " +
                "VALUES ($name, $field, $cols, $rows)";
            try
            {
                command.Parameters.AddWithValue("$name", save.Name);
                command.Parameters.AddWithValue("$field", save.Serialised);
                command.Parameters.AddWithValue("$cols", save.Columns);
                command.Parameters.AddWithValue("$rows", save.Rows);
                command.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                return false;
            }
            //Get auto-incremented SaveID
            long newSaveID;
            command = Connection.CreateCommand();
            command.CommandText = "SELECT last_insert_rowid()";
            try
            {
                newSaveID = (long)command.ExecuteScalar();
            }
            catch (SqliteException)
            {
                return false;
            }
            //connect save and user in Link Table
            command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO UserSave(Username, SaveID) " +
                "VALUES($name, $saveID)";
            try
            {
                command.Parameters.AddWithValue("$name", username);
                command.Parameters.AddWithValue("$saveID", newSaveID);
                command.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                return false;
            }
            return true;
        }
        public bool UpdateSavegame(Savegame save, string username)
        {
            var command = Connection.CreateCommand();
            command.CommandText = "UPDATE Save SET Field = $field, Columns = $cols, Rows = $rows " +
                "WHERE SaveName = $name";
            try
            {
                command.Parameters.AddWithValue("$field", save.Serialised);
                command.Parameters.AddWithValue("$cols", save.Columns);
                command.Parameters.AddWithValue("$rows", save.Rows);
                command.Parameters.AddWithValue("$name", save.Name);
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqliteException)
            {
                return false;
            }
        }
        public Savegame LoadSavegame(string username, string saveName)
        {
            SqliteCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT Save.Field, Save.Columns, Save.Rows " +
                "FROM Save, User, UserSave WHERE " +
                "Save.SaveID = UserSave.SaveID AND User.Username = UserSave.Username " +
                "AND User.Username = $name AND Save.SaveName = $saveName";
            command.Parameters.AddWithValue("$name", username);
            command.Parameters.AddWithValue("$saveName", saveName);
            using (var reader = command.ExecuteReader())
            {
                reader.Read();
                string field = (string)reader["Field"];
                long columns = (long)reader["Columns"];
                long rows = (long)reader["Rows"];
                return new Savegame(columns, rows, field, saveName);
            }
        }
        public bool DeleteSavegame(string saveName, string username)
        {
            SqliteCommand command;
            //Get SaveID
            long saveID;
            command = Connection.CreateCommand();
            command.CommandText = "SELECT SaveID FROM Save WHERE Save.SaveName = $saveName";
            try
            {
                command.Parameters.AddWithValue("$saveName", saveName);
                saveID = (long)command.ExecuteScalar();
            }
            catch (SqliteException)
            {
                return false;
            }
            //delete in link table
            command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM UserSave WHERE SaveID = $saveID";
            try
            {
                command.Parameters.AddWithValue("$saveID", saveID);
                command.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                return false;
            }
            //delete save
            command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM Save WHERE SaveID = $saveID";
            try
            {
                command.Parameters.AddWithValue("$saveID", saveID);
                command.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                return false;
            }
            return true;
        }
        public bool ShareSavegame(string saveName, string username)
        {
            // get SaveID
            var command = Connection.CreateCommand();
            long saveID;
            command.CommandText = "SELECT SaveID FROM Save WHERE Save.SaveName = $saveName";
            try
            {
                command.Parameters.AddWithValue("$saveName", saveName);
                saveID = (long)command.ExecuteScalar();
            }
            catch (SqliteException)
            {
                return false;
            }
            // add new link to link table
            command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO UserSave(Username, SaveID) VALUES ($name, $saveID)";
            try
            {
                command.Parameters.AddWithValue("$name", username);
                command.Parameters.AddWithValue("$saveID", saveID);
                command.ExecuteNonQuery();
            }
            catch (SqliteException)
            {
                return false;
            }
            return true;
        }
        public bool UserExists(string inputUsername)
        {
            SqliteCommand command = Connection.CreateCommand();
            command.CommandText = "SELECT * FROM User WHERE Username = $name";
            command.Parameters.AddWithValue("$name", inputUsername);
            using (var reader = command.ExecuteReader())
            {
                return reader.Read(); //reader.Read returns true if there is a matching row
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
        public void DebugExecute(string command)
        {
            SqliteCommand cmd = Connection.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
        }

        // Private Methods
        private void InitialiseDatabase()
        {
            string[] commands = new string[]
            {
                "CREATE TABLE User(" +
                "Username TEXT PRIMARY KEY," +
                "Hashed TEXT," +
                "Salt TEXT)",

                "CREATE TABLE Save(" +
                "SaveID INTEGER PRIMARY KEY AUTOINCREMENT," +
                "SaveName TEXT," +
                "Columns INTEGER," +
                "Rows INTEGER," +
                "Field TEXT)",

                "CREATE TABLE UserSave(" +
                "SaveID INTEGER REFERENCES Save(SaveID)," +
                "Username TEXT REFERENCES User(Username)," +
                "PRIMARY KEY (SaveID, Username))"
            };
            foreach (var text in commands)
            {
                var command = Connection.CreateCommand();
                command.CommandText = text;
                command.ExecuteNonQuery();
            }
        }
    }
}
