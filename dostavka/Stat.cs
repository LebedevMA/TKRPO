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
    public partial class Stat : Form
    {
        String ConnectionString;

        public Stat()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        void GetCafesStatistics(OracleConnection conn, DateTime beg, DateTime end) {
            List<object[]> stat = Functionality.Statistics.ByCafe(conn,beg,end);
            dataGridViewCafes.Rows.Clear();
            for (int i = 0; i < stat.Count; i++) {
                if (stat[i][0] == null) continue;
                dataGridViewCafes.Rows.Add(Functionality.Cafe.FromPK(conn, (int)(stat[i][0])).Name, stat[i][1], stat[i][2]);
            }
        }

        void GetDishesStatistics(OracleConnection conn, DateTime beg, DateTime end)
        {
            List<object[]> stat = Functionality.Statistics.ByDish(conn, beg, end);
            dataGridViewDishes.Rows.Clear();
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i][0] == null) continue;
                dataGridViewDishes.Rows.Add(Functionality.Dish.FromPK(conn, (int)(stat[i][0])).Name, stat[i][1], stat[i][2]);
            }
        }

        void GetClientsStatistics(OracleConnection conn, DateTime beg, DateTime end)
        {
            List<object[]> stat = Functionality.Statistics.ByClient(conn, beg, end);
            dataGridViewClients.Rows.Clear();
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i][0] == null) continue;
                dataGridViewClients.Rows.Add(Functionality.Client.FromPK(conn, (int)(stat[i][0])).Name, stat[i][1], stat[i][2]);
            }
        }

        void GetDriversStatistics(OracleConnection conn, DateTime beg, DateTime end)
        {
            List<object[]> stat = Functionality.Statistics.ByDriver(conn, beg, end);
            dataGridViewDrivers.Rows.Clear();
            for (int i = 0; i < stat.Count; i++)
            {
                if (stat[i][0] == null) continue;
                dataGridViewDrivers.Rows.Add(Functionality.Driver.FromPK(conn, (int)(stat[i][0])).Name, stat[i][1], stat[i][2]);
            }
        }

        void GetStatistics(OracleConnection conn, DateTime beg, DateTime end)
        {
            labelTotalOrders.Text = Functionality.Statistics.TotalOrders(conn, beg, end).ToString();
            labelAvgOrders.Text = Functionality.Statistics.AvgOrders(conn, beg, end).ToString();
            labelTotalProfit.Text = Functionality.Statistics.TotalProfit(conn, beg, end).ToString();
            labelAvgProfit.Text = Functionality.Statistics.AvgProfit(conn, beg, end).ToString();
            GetCafesStatistics(conn, beg, end);
            GetDishesStatistics(conn, beg, end);
            GetClientsStatistics(conn, beg, end);
            GetDriversStatistics(conn, beg, end);
        }

        private void Stat_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetStatistics(conn, dateTimePickerBeg.Value, dateTimePickerEnd.Value);
            conn.Close();
        }

        private void dateTimePickerBeg_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value < dateTimePickerBeg.Value) dateTimePickerEnd.Value = dateTimePickerBeg.Value;
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetStatistics(conn, dateTimePickerBeg.Value, dateTimePickerEnd.Value);
            conn.Close();
        }

        private void dateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEnd.Value < dateTimePickerBeg.Value) dateTimePickerBeg.Value = dateTimePickerEnd.Value;
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetStatistics(conn, dateTimePickerBeg.Value, dateTimePickerEnd.Value);
            conn.Close();
        }

        private void dataGridViewCafes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewDishes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewClients_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dataGridViewDrivers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
