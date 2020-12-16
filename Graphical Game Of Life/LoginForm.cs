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
            LoginValidity inputValidity = CheckUserInput();
            if (inputValidity == LoginValidity.BadUsername)
            {
                errorMessageLabel.Text = "Bad username!";
                return;
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
                MessageBox.Show(validity.ToString());
            }
        }
        private LoginValidity CheckUserInput()
        {
            if (String.IsNullOrEmpty(usernameTextBox.Text.Trim())) return LoginValidity.BadUsername;
            if (String.IsNullOrEmpty(passwordTextBox.Text.Trim())) return LoginValidity.BadPassword;
            else return LoginValidity.GoodLogin;
        }
    }
}
