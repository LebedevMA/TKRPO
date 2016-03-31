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
    public partial class klients : Form
    {
        String ConnectionString;

        public klients()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }


        void GetClientsList(OracleConnection conn)
        {
            List<Functionality.Client> Clients = Functionality.ClientController.GetClientsList(conn);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Clients.Count; i++)
            {
                dataGridView1.Rows.Add(Clients[i], Clients[i].Name, "+7 "+Clients[i].Phone, Clients[i].Discount.ToString()+"%");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void klients_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetClientsList(conn);
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 AddClientForm = new Form3();
            if (AddClientForm.ShowDialog() == DialogResult.OK) {
                OracleConnection conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.ClientController.AddClient(conn, AddClientForm.TheClient);
                GetClientsList(conn);
                conn.Close();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Form3 EditClientForm = new Form3((Functionality.Client)(dataGridView1.Rows[e.RowIndex].Cells["Tag"].Value));
                if (EditClientForm.ShowDialog() == DialogResult.OK)
                {
                    OracleConnection conn = new OracleConnection(ConnectionString);
                    conn.Open();
                    Functionality.ClientController.UpdateClient(conn, EditClientForm.TheClient);
                    GetClientsList(conn);
                    conn.Close();
                }
            }
            catch (System.Exception ee) { }
        }
    }
}
