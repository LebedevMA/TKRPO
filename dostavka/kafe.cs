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
    public partial class kafe : Form
    {
        String ConnectionString;

        public kafe()
        {
            ConnectionString = System.IO.File.ReadAllText("ConnectionString.txt");
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            redaktCafe AddCafeForm = new redaktCafe();
            if (AddCafeForm.ShowDialog() == DialogResult.OK)
            {
                OracleConnection conn = new OracleConnection(ConnectionString);
                conn.Open();
                Functionality.CafeController.AddCafe(conn, AddCafeForm.TheCafe);
                for (int i = 0; i < AddCafeForm.TheDishes.Count; i++) {
                    AddCafeForm.TheDishes[i].PK_Cafe = AddCafeForm.TheCafe.PK_Cafe;
                }
                Functionality.CafeController.UpdateCafeMenu(conn, AddCafeForm.TheCafe, AddCafeForm.TheDishes);
                GetCafesList(conn);
                conn.Close();
            }
        }

        void GetCafesList(OracleConnection conn)
        {
            List<Functionality.Cafe> Cafes = Functionality.CafeController.GetCafeList(conn);
            dataGridView1.Rows.Clear();
            for (int i = 0; i < Cafes.Count; i++)
            {
                dataGridView1.Rows.Add(Cafes[i], Cafes[i].Name, "+7 "+(Cafes[i].Phone), Cafes[i].Address);
            }
        }

        private void kafe_Load(object sender, EventArgs e)
        {
            OracleConnection conn = new OracleConnection(ConnectionString);
            conn.Open();
            GetCafesList(conn);
            conn.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                redaktCafe EditCafeForm = new redaktCafe((Functionality.Cafe)(dataGridView1.Rows[e.RowIndex].Cells["Tag"].Value));
                if (EditCafeForm.ShowDialog() == DialogResult.OK)
                {
                    OracleConnection conn = new OracleConnection(ConnectionString);
                    conn.Open();
                    Functionality.CafeController.UpdateCafe(conn, EditCafeForm.TheCafe);
                    Functionality.CafeController.UpdateCafeMenu(conn, EditCafeForm.TheCafe, EditCafeForm.TheDishes);
                    GetCafesList(conn);
                    conn.Close();
                }
            }
            catch (System.Exception ee) { }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
