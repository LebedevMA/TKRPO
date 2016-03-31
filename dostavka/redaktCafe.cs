using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class redaktCafe : Form
    {
        String ConnectionString;
        public Functionality.Cafe TheCafe;
        public List<Functionality.Dish> TheDishes; 

        public redaktCafe()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            TheCafe = new Functionality.Cafe();
            InitializeComponent();
        }
        
        public redaktCafe(Functionality.Cafe editCafe)
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            TheCafe = editCafe;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void GetDishesList()
        {
            if (TheCafe.PK_Cafe > 0)
            {
                OracleConnection conn = new OracleConnection(ConnectionString);
                conn.Open();
                TheDishes = Functionality.DishController.GetDishList(conn, TheCafe.PK_Cafe, true);
                dataGridView1.Rows.Clear();
                for (int i = 0; i < TheDishes.Count; i++)
                {
                    dataGridView1.Rows.Add(TheDishes[i], TheDishes[i].Name, TheDishes[i].Price, TheDishes[i].Disabled);
                }
                conn.Close();
            }
            else {
                TheDishes = new List<Functionality.Dish>();
            }
        }

        private void redaktCafe_Load(object sender, EventArgs e)
        {
            textBox_Name.Text = TheCafe.Name;
            maskedTextBox_Phone.Text = TheCafe.Phone;
            textBox_Address.Text = TheCafe.Address;
            GetDishesList();
        }

        private void textBox_Name_TextChanged(object sender, EventArgs e)
        {
            TheCafe.Name = textBox_Name.Text;
        }

        private void maskedTextBox_Phone_TextChanged(object sender, EventArgs e)
        {
            TheCafe.Phone = maskedTextBox_Phone.Text;
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            TheCafe.Address = textBox_Address.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Name.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели название кафе.");
                return;
            }
            if (maskedTextBox_Phone.MaskCompleted == false)
            {
                MessageBox.Show("Вы не ввели телефон.");
                return;
            }
            if (textBox_Address.Text.Length == 0)
            {
                MessageBox.Show("Вы не ввели адрес.");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Functionality.Dish TheDish = new Functionality.Dish();
            TheDish.PK_Cafe = TheCafe.PK_Cafe;
            TheDishes.Add(TheDish);
            dataGridView1.Rows.Add(TheDish, TheDish.Name, TheDish.Price, TheDish.Disabled);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Functionality.Dish TheDish = (Functionality.Dish)(dataGridView1.Rows[e.RowIndex].Cells["Tag"].Value);
            switch (e.ColumnIndex) {
                case 0:
                    break;
                case 1:
                    TheDish.Name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    break;
                case 2:
                    try
                    {
                        TheDish.Price = (float)(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[2].Value));
                    }
                    catch (System.Exception ee) {
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = TheDish.Price;
                    }
                    break;
                case 3:
                    TheDish.Disabled = (bool)(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                    break;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
