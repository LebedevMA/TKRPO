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
    public partial class Form3 : Form
    {
        public Functionality.Client TheClient;
        public Form3()
        {
            InitializeComponent();
            TheClient = new Functionality.Client();
        }
        public Form3(Functionality.Client editClient)
        {
            InitializeComponent();
            TheClient = editClient;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = TheClient.Name;
            maskedTextBox_Phone.Text = TheClient.Phone;
            numericUpDown_Discount.Value = (decimal)(TheClient.Discount);
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            TheClient.Name = textBox_Name.Text;
        }

        private void numericUpDown_Discount_ValueChanged(object sender, EventArgs e)
        {
            TheClient.Discount = (int)(numericUpDown_Discount.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TheClient.Name.Length == 0) {
                MessageBox.Show("Вы не ввели ФИО клиента.");
                return;
            }
            if (maskedTextBox_Phone.MaskCompleted == false)
            {
                MessageBox.Show("Вы не ввели телефон клиента.");
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

        private void maskedTextBox_Phone_TextChanged(object sender, EventArgs e)
        {
            TheClient.Phone = maskedTextBox_Phone.Text;
        }
    }
}
