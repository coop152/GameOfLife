using Hashing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphical_Game_Of_Life
{
    public partial class LoginForm : Form
    {
        Database db;
        public LoginForm()
        {
            InitializeComponent();
            db = new Database("passwordTesting.db");

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            errorMessageLabel.Text = String.Empty;
            LoginValidity inputValidity = CheckUserInput();
            if (inputValidity == LoginValidity.BadUsername)
            {
                errorMessageLabel.Text = "Bad username!";
            }
            else if (inputValidity == LoginValidity.BadPassword)
            {
                errorMessageLabel.Text = "Bad password!";
            }
            else //if details good
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                LoginValidity validity = db.CheckPassword(username, password);
                //MessageBox.Show(validity.ToString());
                if (validity == LoginValidity.GoodLogin)
                {
                    OpenGame(username);
                }
                else if (validity == LoginValidity.BadUsername)
                {
                    errorMessageLabel.Text = "User does not exist!";
                }
                else
                {
                    errorMessageLabel.Text = "Incorrect password!";
                }
            }
        }

        private void newAccountButton_Click(object sender, EventArgs e)
        {
            errorMessageLabel.Text = String.Empty;
            LoginValidity inputValidity = CheckUserInput();
            if (inputValidity == LoginValidity.BadUsername)
            {
                errorMessageLabel.Text = "Bad username!";
            }
            else if (inputValidity == LoginValidity.BadPassword)
            {
                errorMessageLabel.Text = "Bad password!";
            }
            else
            {
                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;
                //MessageBox.Show(validity.ToString());
                if (db.UserExists(username))
                {
                    errorMessageLabel.Text = "User already exists!";
                }
                else
                {
                    db.AddUser(username, password);
                    DialogResult dialog = MessageBox.Show("User created successfully. Log into new account?", "New User", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        OpenGame(username);
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private void OpenGame(string username)
        {
            var gameForm = new GameForm(username);
            this.Hide();
            gameForm.ShowDialog();
            this.Show();
        }
        private LoginValidity CheckUserInput()
        {
            if (String.IsNullOrEmpty(usernameTextBox.Text.Trim())) return LoginValidity.BadUsername;
            if (String.IsNullOrEmpty(passwordTextBox.Text.Trim())) return LoginValidity.BadPassword;
            else return LoginValidity.GoodLogin;
        }
    }
}
