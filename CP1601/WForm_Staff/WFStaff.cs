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
    public partial class WfStaff : Form
    {
        private readonly SqlConnect _sql = new SqlConnect();

        public WfStaff()
        {
            InitializeComponent();

        }

        private void WFStaff_Load(object sender, EventArgs e)
        {
            UserOutput();
            
            // найти причину сбоя
            //NumOutput();
        }

        private void WFStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            _sql.CloseConn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserOutput();
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            NumOutput();
        }

        private void NumOutput()
        {
            dgvNum.Rows.Clear();
            try
            {
                _sql.OpenConn();
                String filterDate = dateTPNum.Text;
                String commPart =
                    "SELECT RoomNumber, PlaceQuantity, Class_ID" +
                    " FROM \"hotel\".\"Apartment\"" +
                    " EXCEPT" +
                    " SELECT RoomNumber, PlaceQuantity, Class_ID" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate < '" + filterDate + "'::date" +
                    " AND c.CheckOutDate > '" + filterDate + "'::date" +
                    " ORDER BY (RoomNumber) ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, _sql.Conn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        this.dgvNum.Rows.Add(dbDataRecord["RoomNumber"].ToString(),
                            dbDataRecord["PlaceQuantity"].ToString(), dbDataRecord["Class_ID"].ToString());
                    }
                }
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
            _sql.CloseConn();
        }

        private void UserOutput()
        {
            dgvUser.Rows.Clear();
            try
            {
                _sql.OpenConn();
                String filterDate = dateTPUser.Text;
                String commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                    " WHERE c.client_id = a.client_id" +
                    " AND ap.ap_id = a.ap_id" +
                    " AND a.CheckInDate < '" + filterDate + "'::date" +
                    " AND a.CheckOutDate > '" + filterDate + "'::date ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, _sql.Conn);
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
            _sql.CloseConn();
        }
    }
}
