using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace dostavka
{
    public partial class LoginForm : Form
    {
        String ConnectionString;

        public LoginForm()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            List<Functionality.Dispatcher> Dispatchers = Functionality.DispatcherController.GetDispatcherList(conn);
            for (int i = 0; i < Dispatchers.Count; i++) {
                comboBoxLogin.Items.Add(Dispatchers[i].Login);
            }
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Functionality.DispatcherController.LogIn(conn, comboBoxLogin.Text, textBoxPassword.Text);
            conn.Close();
            if (Functionality.DispatcherController.ActiveDispatcher != null)
            {
                Form1 MainForm = new Form1();
                this.Visible = false;
                MainForm.ShowDialog();
                Functionality.DispatcherController.ActiveDispatcher = null;
                textBoxPassword.Text = "";
                this.Visible = true;
            }
            else {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }
    }
}
