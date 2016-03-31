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
    public partial class Form1 : Form
    {
        String ConnectionString;

        string[] StatusLabels = {"ожидание","выполнение","отменен","завершен"};

        public Form1()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Functionality.Order TheOrder = new Functionality.Order();
            conn.Close();
            Form2 f2 = new Form2(TheOrder);
            DialogResult dr = f2.ShowDialog();

            if (dr == DialogResult.OK) {
                conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.OrdersController.AddOrder(conn,TheOrder);
                conn.Close();

                ShowOrders();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
        }

        void ShowOrders() {
            dataGridView1.Rows.Clear();
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            List<Functionality.Order> Orders = Functionality.OrdersController.GetOrdersList(conn, false, (comboBox2.SelectedIndex - 1));
            for (int i = 0; i < Orders.Count; i++)
            {
                Functionality.Client TheClient = Functionality.Client.FromPK(conn, Orders[i].PK_Client);
                Functionality.Driver TheDriver = Functionality.Driver.FromPK(conn, Orders[i].PK_Driver);
                String ClientPhone="", DriverName="";
                if (TheClient != null) ClientPhone = TheClient.Phone;
                if (TheDriver != null) DriverName = TheDriver.Name;
                dataGridView1.Rows.Add(Orders[i].PK_Order,
                    Orders[i].DateTime.ToString("dd/MM/yyyy HH:mm"),
                    Orders[i].Address,
                    ClientPhone,
                    DriverName,
                    StatusLabels[Orders[i].Status],
                    Orders[i].Sum,
                    Orders[i].Part,
                    Orders[i].DriverMoney);
                Color RowColor = Color.White;
                switch (Orders[i].Status) {
                    case 0:
                        RowColor = Color.White;
                        break;
                    case 1:
                        RowColor = Color.FromArgb(255,255,200);
                        break;
                    case 2:
                        RowColor = Color.FromArgb(200, 200, 200);
                        break;
                    case 3:
                        RowColor = Color.FromArgb(200, 255, 200);
                        break;
                }
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = RowColor;
            }
            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowOrders();
        }

        void OrderEditOpen(int PK_Order) {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Functionality.Order TheOrder = Functionality.Order.FromPK(conn, PK_Order, true);
            conn.Close();
            Form2 f2 = new Form2(TheOrder);
            DialogResult dr = f2.ShowDialog();

            if (dr == DialogResult.OK)
            {
                conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.OrdersController.UpdateOrder(conn, TheOrder, true);
                conn.Close();

                ShowOrders();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int PK_Order = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Column_PK_Order"].Value);

                OrderEditOpen(PK_Order);
            }
            catch (System.Exception ee) {
            }
        }

        private void DriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drivers4 DriversForm = new drivers4();
            DriversForm.ShowDialog();
            ShowOrders();
        }

        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            klients KlientsForm = new klients();
            KlientsForm.ShowDialog();
            ShowOrders();
        }

        private void CafesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kafe CafesForm = new kafe();
            CafesForm.ShowDialog();
            ShowOrders();
        }

        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stat StatisticsForm = new Stat();
            StatisticsForm.ShowDialog();
            ShowOrders();
        }

        private void DispatcherLogoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            Functionality.DispatcherController.LogOut(conn);
            conn.Close();
            this.Close();
        }

        private void DispatcherProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DispatcherProfileForm ProfileForm = new DispatcherProfileForm();
            ProfileForm.ShowDialog();
        }
    }
}
