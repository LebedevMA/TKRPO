using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dostavka
{
    public partial class dobavlenVodit : Form
    {
        public Functionality.Driver TheDriver;

        public dobavlenVodit()
        {
            TheDriver = new Functionality.Driver();
            InitializeComponent();
        }
        public dobavlenVodit(Functionality.Driver editDriver)
        {
            TheDriver = editDriver;
            InitializeComponent();
        }

        private void dobavlenVodit_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = TheDriver.Name;
            maskedTextBox_Phone.Text = TheDriver.Phone;
            checkBoxInState.Checked = (TheDriver.InState != 0);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheDriver.Name.Length == 0)
            {
                MessageBox.Show("Вы не ввели ФИО водителя.");
                return;
            }
            if (maskedTextBox_Phone.MaskCompleted == false)
            {
                MessageBox.Show("Вы не ввели телефон водителя.");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            TheDriver.Name = textBox_Name.Text;
        }

        private void maskedTextBox_Phone_TextChanged(object sender, EventArgs e)
        {
            TheDriver.Phone = maskedTextBox_Phone.Text;
        }

        private void checkBoxInState_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxInState.Checked) TheDriver.InState = 1;
            else TheDriver.InState = 0;
        }
    }
}
