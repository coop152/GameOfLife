using Hashing;
using System;
using System.Windows.Forms;

namespace Graphical_Game_Of_Life
{
    public partial class LoginForm : Form
    {
        readonly Database db;
        public LoginForm()
        {
            InitializeComponent();
            db = new Database("passwordTesting.db");
        }
        void EnableDatabaseDebug()
        {
            void exec(object sender, KeyEventArgs e)
            {
                Control tb = sender as Control;
                if (e.KeyCode == Keys.Enter)
                {
                    db.DebugExecute(tb.Text);
                }
            }
            TextBox dbDebugBox = new TextBox();
            dbDebugBox.KeyDown += exec;
            tableLayoutPanel.Controls.Remove(errorMessageLabel);
            tableLayoutPanel.Controls.Add(dbDebugBox, 0, 2);
            tableLayoutPanel.SetColumnSpan(dbDebugBox, 2);
            dbDebugBox.Dock = DockStyle.Fill;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "debug")
            {
                EnableDatabaseDebug();
                return;
            }
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
            var gameForm = new GameForm(username, db);
            this.Hide();
            gameForm.ShowDialog();
            this.Show(); //do .Close instead if you want the entire program to close
        }
        private LoginValidity CheckUserInput()
        {
            if (String.IsNullOrEmpty(usernameTextBox.Text.Trim())) return LoginValidity.BadUsername;
            if (String.IsNullOrEmpty(passwordTextBox.Text.Trim())) return LoginValidity.BadPassword;
            else return LoginValidity.GoodLogin;
        }

        private void TitleLabel_DoubleClick(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) == Keys.Shift) OpenGame("Testing");
            else if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                DialogResult result = MessageBox.Show("Reset the database? This will erase all user accounts, saved games and rulesets!", 
                    "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) 
                { 
                    db.ResetDatabase();
                    MessageBox.Show("The database has been reset.");
                }
            }
        }
    }
}
