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
    public partial class InputDialog : Form
    {
        public string Result;
        public bool Cancelled;
        public InputDialog()
        {
            InitializeComponent();
        }
        static public string Show(string prompt, string title)
        {
            InputDialog dialog = new InputDialog();
            dialog.Text = title;
            dialog.promptLabel.Text = prompt;
            dialog.ShowDialog();
            if (dialog.Cancelled) return null;
            else return dialog.Result;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Result = inputTextBox.Text;
            this.Close();
        }
    }
}
