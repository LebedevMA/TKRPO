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
    public partial class Form2 : Form
    {
        String ConnectionString;

        int CityTariff = 100;
        int CountryTariff = 200;

        float OurPart = 0.5f;

        public Functionality.Order TheOrder;

        public Form2()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
            TheOrder = new Functionality.Order();
        }

        public Form2(Functionality.Order editOrder)
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
            TheOrder = editOrder;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        void SetStatus(int Status) {
            TheOrder.Status = Status;
            switch (TheOrder.Status)
            {
                case 0:
                    label_Status.Text = "Ожидание";
                    button_Status1.Visible = true;
                    button_Status2.Visible = true;
                    button_Status3.Visible = false;
                    break;
                case 1:
                    label_Status.Text = "Выполнение";
                    button_Status1.Visible = false;
                    button_Status2.Visible = false;
                    button_Status3.Visible = true;
                    break;
                case 2:
                    label_Status.Text = "Отменен";
                    button_Status1.Visible = false;
                    button_Status2.Visible = false;
                    button_Status3.Visible = false;
                    break;
                case 3:
                    label_Status.Text = "Завершен";
                    button_Status1.Visible = false;
                    button_Status2.Visible = false;
                    button_Status3.Visible = false;
                    break;
            }
            if (TheOrder.LinesChangeAllowed() == false)
            {
                dataGridView1.Enabled = false;
                button_AddLine.Enabled = false;
                button_RemoveLines.Enabled = false;
            }
            if (TheOrder.AddressChangeAllowed() == false)
            {
                textBox_Address.Enabled = false;
                checkBox_Countryside.Enabled = false;
            }
            if (TheOrder.DateTimeChangeAllowed() == false)
            {
                dateTimePicker2.Enabled = false;
            }
            if (TheOrder.DriverChangeAllowed() == false)
            {
                comboBox_Driver.Enabled = false;
            }
            if (TheOrder.ClientChangeAllowed() == false)
            {
                comboBox_Client.Enabled = false;
                button1.Enabled = false;
            }
            if (TheOrder.ClientChangeAllowed() == false) {
                comboBox_Client.Enabled = false;
                button1.Enabled = false;
            }
            if (TheOrder.DriverMoneyChangeAllowed() == false)
            {
                textBox_DriverMoney.Enabled = false;
            }
        }

        void LoadClients() {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();

            List<Functionality.Client> Clients = Functionality.ClientController.GetClientsList(conn);

            for (int i = 0; i < Clients.Count; i++) {
                comboBox_Client.Items.Add(Clients[i]);
                if (Clients[i].PK_Client == TheOrder.PK_Client) {
                    comboBox_Client.SelectedItem = Clients[i];
                }
            }

            conn.Close();
        }

        void LoadDrivers() {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();

            List<Functionality.Driver> Drivers = Functionality.DriverController.GetDriversList(conn);

            for (int i = 0; i < Drivers.Count; i++)
            {
                comboBox_Driver.Items.Add(Drivers[i]);
                if (Drivers[i].PK_Driver == TheOrder.PK_Driver)
                {
                    comboBox_Driver.SelectedItem = Drivers[i];
                }
            }

            conn.Close();
        }

        void LoadDishList(OracleConnection conn, int row, int PK_Cafe) {
            bool IncludeDisabled = false;
            if (!TheOrder.LinesChangeAllowed()) IncludeDisabled = true;
            DataGridViewComboBoxCell cbc = (DataGridViewComboBoxCell)dataGridView1.Rows[row].Cells["Column_Dish"];
            cbc.Value = null;
            cbc.Items.Clear();
            if (PK_Cafe <= 0) return;
            List<Functionality.Dish> Dishes;
            if (PK_Cafe > 0) Dishes = Functionality.DishController.GetDishList(conn, PK_Cafe, IncludeDisabled);
            else Dishes = Functionality.DishController.GetDishList(conn, IncludeDisabled);
            for (int j = 0; j < Dishes.Count; j++)
            {
                cbc.Items.Add(Dishes[j].Name);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (TheOrder.PK_Order > 0) label_PK.Text = TheOrder.PK_Order.ToString();
            
            dateTimePicker2.Value = TheOrder.DateTime;

            label_Sum.Text = TheOrder.Sum.ToString();
            label_Part.Text = TheOrder.Part.ToString();
            textBox_DriverMoney.Text = TheOrder.DriverMoney.ToString();

            textBox_Address.Text = TheOrder.Address;
            checkBox_Countryside.Checked = (TheOrder.Countryside != 0);

            textBox_Comment.Text = TheOrder.Comment;

            SetStatus(TheOrder.Status);

            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();

            List<Functionality.Cafe> Cafes = Functionality.CafeController.GetCafeList(conn);

            for (int i = 0; i < Cafes.Count; i++) {
                ((DataGridViewComboBoxColumn)dataGridView1.Columns["Column_Cafe"]).Items.Add(Cafes[i].Name);
            }

            for (int i = 0; i < TheOrder.Lines.Count; i++)
            {
                Functionality.Dish TheDish = Functionality.Dish.FromPK(conn, TheOrder.Lines[i].PK_Dish);
                int PK_Cafe = -1;
                if (TheDish != null) PK_Cafe = TheDish.PK_Cafe;
                Functionality.Cafe TheCafe = Functionality.Cafe.FromPK(conn, PK_Cafe);
                String CafeName = "";
                if (TheCafe != null) CafeName = TheCafe.Name;
                float DishPrice = 0;
                if (TheDish != null) DishPrice = TheDish.Price;
                dataGridView1.Rows.Add(TheOrder.Lines[i], CafeName,
                    null,
                    DishPrice,
                    TheOrder.Lines[i].Amount,
                    TheOrder.Lines[i].Cost);
                if (TheCafe != null) LoadDishList(conn,i,TheCafe.PK_Cafe);
                else LoadDishList(conn, i, -1);
                if (TheDish != null) dataGridView1.Rows[i].Cells["Column_Dish"].Value = TheDish.Name;
            }


            LoadClients();
            LoadDrivers();

            conn.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Functionality.Client TheClient = new Functionality.Client();
            Form3 f3 = new Form3(TheClient);
            if (f3.ShowDialog() == DialogResult.OK) {
                OracleConnection conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.ClientController.AddClient(conn, TheClient);
                conn.Close();
                comboBox_Client.Items.Add(TheClient);
                comboBox_Client.SelectedItem = TheClient;
                TheOrder.PK_Client = TheClient.PK_Client;
                label_Discount.Text = TheClient.Discount.ToString() + "%";
                SumCount();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            TheOrder.DateTime = dateTimePicker2.Value;
        }

        private void button_Status1_Click(object sender, EventArgs e)
        {
            if (TheOrder.PK_Client <= 0) {
                MessageBox.Show("Вы не выбрали клиента.");
                return;
            }
            if (TheOrder.PK_Driver <= 0)
            {
                MessageBox.Show("Вы не выбрали водителя.");
                return;
            }
            SetStatus(1);
        }

        private void button_Status2_Click(object sender, EventArgs e)
        {
            SetStatus(2);
        }

        private void button_Status3_Click(object sender, EventArgs e)
        {
            if (TheOrder.DriverMoney < TheOrder.Part)
            {
                MessageBox.Show("Деньги от водителя не получены.");
                return;
            }
            SetStatus(3);
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void comboBox_Client_SelectedIndexChanged(object sender, EventArgs e)
        {
            Functionality.Client TheClient = ((Functionality.Client)(comboBox_Client.SelectedItem));
            TheOrder.PK_Client = TheClient.PK_Client;
            label_Discount.Text = TheClient.Discount.ToString() + "%";
            SumCount();
        }

        private void comboBox_Driver_SelectedIndexChanged(object sender, EventArgs e)
        {
            TheOrder.PK_Driver = ((Functionality.Driver)(comboBox_Driver.SelectedItem)).PK_Driver;
        }

        private void textBox_DriverMoney_Leave(object sender, EventArgs e)
        {
            textBox_DriverMoney.Text = textBox_DriverMoney.Text.Replace('.', ',');
            try {
                TheOrder.DriverMoney = (float)(Convert.ToDecimal(textBox_DriverMoney.Text));
            } catch (System.Exception ee) {
                textBox_DriverMoney.Text = TheOrder.DriverMoney.ToString();
            }
        }

        private void textBox_Address_TextChanged(object sender, EventArgs e)
        {
            TheOrder.Address = textBox_Address.Text;
        }

        private void checkBox_Countryside_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Countryside.Checked) TheOrder.Countryside = 1;
            else TheOrder.Countryside = 0;
            SumCount();
        }

        private void textBox_Comment_TextChanged(object sender, EventArgs e)
        {
            TheOrder.Comment = textBox_Comment.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_AddLine_Click(object sender, EventArgs e)
        {
            Functionality.OrderLine TheLine = new Functionality.OrderLine();
            TheOrder.Lines.Add(TheLine);
            dataGridView1.Rows.Add(TheLine, null, null, "", "", "");
        }

        private void button_RemoveLines_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> Rows2Del = new List<DataGridViewRow>();
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++) {
                Rows2Del.Add(dataGridView1.SelectedRows[i]);
            }
            for (int i = 0; i < Rows2Del.Count; i++)
            {
                TheOrder.Lines.Remove((Functionality.OrderLine)(Rows2Del[i].Cells["Column_Tag"].Value));
                dataGridView1.Rows.Remove(Rows2Del[i]);
            }
        }
        
        void SumCount() {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            int Discount = 0;
            Functionality.Client TheClient = Functionality.Client.FromPK(conn, TheOrder.PK_Client);
            if (TheClient != null) {
                Discount = TheClient.Discount;
            }
            conn.Close();
            TheOrder.Sum = Functionality.OrdersController.CountSum(TheOrder,CityTariff,CountryTariff)
                * (float)(1 - 0.01 * Discount);
            TheOrder.Part = Functionality.OrdersController.CountPart(TheOrder.Sum, OurPart);
            

            label_Sum.Text = TheOrder.Sum.ToString();
            label_Part.Text = TheOrder.Part.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Functionality.OrderLine TheLine = null;
            try
            {
                TheLine = (Functionality.OrderLine)(dataGridView1.Rows[e.RowIndex].Cells["Column_Tag"].Value);
            }
            catch (System.Exception ee)
            {
                return;
            }

            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();

            Functionality.Dish TheDish = null;
            Functionality.Cafe TheCafe = null;

            switch (e.ColumnIndex)
            {
                case 1:
                    try
                    {
                        TheCafe = Functionality.Cafe.FromName(conn, dataGridView1.Rows[e.RowIndex].Cells["Column_Cafe"].Value.ToString());
                        LoadDishList(conn, e.RowIndex, TheCafe.PK_Cafe);
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value = null;
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = null;
                    }
                    catch (System.Exception ee) {
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Cafe"].Value = null;
                        LoadDishList(conn, e.RowIndex, -1);
                    }
                    break;
                case 2:
                    try
                    {
                        TheCafe = Functionality.Cafe.FromName(conn, dataGridView1.Rows[e.RowIndex].Cells["Column_Cafe"].Value.ToString());
                        TheDish = Functionality.Dish.FromName(conn, dataGridView1.Rows[e.RowIndex].Cells["Column_Dish"].Value.ToString(),
                            TheCafe.PK_Cafe);
                        TheLine.PK_Dish = TheDish.PK_Dish;

                        try
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value = TheDish.Price.ToString();
                        }
                        catch (System.Exception ee)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value = "";
                        }
                        try
                        {
                            TheLine.Cost = (float)(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Amount"].Value));
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = TheLine.Cost.ToString();
                        }
                        catch (System.Exception ee)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = TheLine.Cost.ToString();
                        }
                    }
                    catch (System.Exception ee)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Dish"].Value = null;
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value = null;
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = null;
                    }
                    break;
                case 3:
                    break;
                case 4:
                    try
                    {
                        TheLine.Amount = (float)(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Amount"].Value));

                        try
                        {
                            TheLine.Cost = (float)(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Price"].Value) * Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Amount"].Value));
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = TheLine.Cost.ToString();
                        }
                        catch (System.Exception ee)
                        {
                            dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = TheLine.Cost.ToString();
                        }
                    }
                    catch (System.Exception ee)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Amount"].Value = TheLine.Amount.ToString();
                    }
                    break;
                case 5:
                    try
                    {
                        TheLine.Cost = (float)(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value));
                    }
                    catch (System.Exception ee)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Column_Cost"].Value = TheLine.Cost.ToString();
                    }
                    break;
            }
            conn.Close();
            SumCount();
        }
    }
}
