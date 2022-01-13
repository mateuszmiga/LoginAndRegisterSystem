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
    public partial class formRegister : Form
    {
        public formRegister()
        {
            InitializeComponent();
        }

        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb;Jet OLEDB:Database Password=1234;");
        OleDbCommand command = new OleDbCommand();
        OleDbDataAdapter adapter = new OleDbDataAdapter();

        private void formRegister_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textPassword.Text=String.Empty;
            textUsername.Text=String.Empty;
            textConfirmPassword.Text=String.Empty;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == String.Empty || textPassword.Text == String.Empty || textConfirmPassword.Text != textPassword.Text)
            {
                MessageBox.Show("Username or password cannot be blank or passwords does not match!");
            }
            else if (textUsername.Text.Length < 4 || textPassword.Text.Length < 4 || textUsername.Text.Length > 20 ||
                     textPassword.Text.Length > 20)
            {
                MessageBox.Show("Username and Password must be between 4 and 20 characters!");
            }
            else
            {
                connection.Open();
                string register = "INSERT INTO tableUsers VALUES ('"+textUsername.Text+"','"+textPassword.Text+"')";
                command = new OleDbCommand(register, connection);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Account created! You can log in now.", "Registration succes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
