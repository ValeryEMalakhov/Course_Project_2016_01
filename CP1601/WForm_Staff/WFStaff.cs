using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CP1601.SQL;
using System.Data.Common;
using CP1601.WForm_Start;
using Npgsql;

namespace CP1601.WForm_Staff
{
    public partial class WFStaff : Form
    {
        // общие переменные
        SQLConnect sqlC = new SQLConnect();

        public WFStaff()
        {
            InitializeComponent();
            //sqlC.OpenConn();

        }

        private void WFStaff_Load(object sender, EventArgs e)
        {
            try
            {
                sqlC.OpenConn();
                dgvUser.Rows.Clear();

                String commPart = "SELECT * FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap WHERE c.client_id = a.client_id AND ap.ap_id = a.ap_id AND a.CheckInDate < \'today\'::date AND a.CheckOutDate > \'today\'::date";
                NpgsqlCommand command = new NpgsqlCommand(commPart,sqlC.conn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        this.dgvUser.Rows.Add(dbDataRecord["FirstName"].ToString(),
                            dbDataRecord["SecondName"].ToString(), dbDataRecord["Gender"].ToString(),
                            dbDataRecord["RoomNumber"].ToString(),
                            dbDataRecord["CheckInDate"].ToString(), dbDataRecord["CheckOutDate"].ToString());
                    }
                }

                sqlC.CloseConn();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        private void WFStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            sqlC.CloseConn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlC.OpenConn();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap WHERE c.client_id = a.client_id AND ap.ap_id = a.ap_id AND a.CheckInDate < \'today\'::date AND a.CheckOutDate > \'today\'::date", sqlC.conn);

            try
            {
                dgvUser.Rows.Clear();

                NpgsqlDataReader readerUserTable = command.ExecuteReader();
                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        this.dgvUser.Rows.Add(dbDataRecord["FirstName"].ToString(),
                            dbDataRecord["SecondName"].ToString(), dbDataRecord["Gender"].ToString(),
                            dbDataRecord["RoomNumber"].ToString(),
                            dbDataRecord["CheckInDate"].ToString(), dbDataRecord["CheckOutDate"].ToString());
                    }
                }
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
            sqlC.CloseConn();
        }
    }
}
