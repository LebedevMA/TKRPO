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
    public partial class drivers4 : Form
    {
        String ConnectionString;

        public drivers4()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        void GetDriversList(OracleConnection conn) {
            List<Functionality.Driver> Drivers = Functionality.DriverController.GetDriversList(conn);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Drivers.Count; i++) {
                dataGridView1.Rows.Add(Drivers[i], Drivers[i].Name, "+7 "+(Drivers[i].Phone), (Drivers[i].InState != 0));
            }
        }

        private void drivers4_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetDriversList(conn);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dobavlenVodit AddDriverForm = new dobavlenVodit();
            if (AddDriverForm.ShowDialog() == DialogResult.OK)
            {
                OracleConnection conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.DriverController.AddDriver(conn, AddDriverForm.TheDriver);
                GetDriversList(conn);
                conn.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                dobavlenVodit EditDriverForm = new dobavlenVodit((Functionality.Driver)(dataGridView1.Rows[e.RowIndex].Cells["Tag"].Value));
                if (EditDriverForm.ShowDialog() == DialogResult.OK)
                {
                    OracleConnection conn = new OracleConnection(ConnectionString);
                    conn.Open();
                    Functionality.DriverController.UpdateDriver(conn, EditDriverForm.TheDriver);
                    GetDriversList(conn);
                    conn.Close();
                }
            }catch(System.Exception ee) { }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
