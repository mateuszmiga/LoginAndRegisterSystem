using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace LoginAndRegisterSystem
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb;Jet OLEDB:Database Password=1234;");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void buttonRegister_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new formRegister().Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            connection.Open();
            string login = "SELECT * FROM tableUsers WHERE username='"+textUsername.Text+"'and password='"+textPassword.Text+"'";
            command = new OleDbCommand(login, connection);
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read() == true)
            {
                new dashboard().Show();
                this.Hide();
                connection.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login failed!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                connection.Close();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textPassword.Text = String.Empty;
            textUsername.Text = String.Empty;
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textPassword.PasswordChar = '\0';
                
            }
            else
            {
                textPassword.PasswordChar = '*';
                
            }
        }
    }
}
