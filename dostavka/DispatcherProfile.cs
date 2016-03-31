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
    public partial class DispatcherProfileForm : Form
    {
        String ConnectionString;

        public DispatcherProfileForm()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        private void DispatcherProfile_Load(object sender, EventArgs e)
        {
            textBoxName.Text = Functionality.DispatcherController.ActiveDispatcher.Name;
            labelLogin.Text = Functionality.DispatcherController.ActiveDispatcher.Login;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxOldPassword.Text.Length > 0)
            {
                if (textBoxOldPassword.Text.Replace("\\", "").Replace("'", "").Equals(Functionality.DispatcherController.ActiveDispatcher.Password.Replace("\\", "").Replace("'", "")) == false)
                {
                    MessageBox.Show("Cтарый пароль введен неверно");
                    return;
                }
                if (textBoxNewPassword.Text.Length > 0 || textBoxRepeatNewPassword.Text.Length > 0)
                {
                    if (textBoxNewPassword.Text.Equals(textBoxRepeatNewPassword.Text) == false)
                    {
                        MessageBox.Show("Пароли не совпадают");
                        return;
                    }/*
                    if (textBoxNewPassword.Text.IndexOf('\'') >= 0 || textBoxNewPassword.Text.IndexOf('\\') >= 0)
                    {
                        MessageBox.Show("В пароле нельзя использовать символы ' и \\");
                        return;
                    }*/
                }
            }
            else {
                if (textBoxNewPassword.Text.Length > 0 || textBoxRepeatNewPassword.Text.Length > 0)
                {
                    MessageBox.Show("Вы не ввели старый пароль");
                    return;
                }
            }

            Functionality.DispatcherController.ActiveDispatcher.Name = textBoxName.Text;
            if (textBoxNewPassword.Text.Length > 0) Functionality.DispatcherController.ActiveDispatcher.Password = textBoxNewPassword.Text.Replace("\\", "").Replace("'", "");

            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Functionality.DispatcherController.UpdateDispatcher(conn, Functionality.DispatcherController.ActiveDispatcher);
            conn.Close();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
