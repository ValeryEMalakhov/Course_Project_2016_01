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
    class StaffReq : WfStaff
    {
        public static void UserOutput(DataGridView dgvUser, DateTimePicker dateTPUser)
        {
            dgvUser.Rows.Clear();
            try
            {
                SqlConnect.GetInstance().OpenConn();
                string filterDate = dateTPUser.Text;
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                    " WHERE c.client_id = a.client_id" +
                    " AND ap.ap_id = a.ap_id" +
                    " AND a.CheckInDate < '" + filterDate + "'::date" +
                    " AND a.CheckOutDate > '" + filterDate + "'::date ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, SqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        dgvUser.Rows.Add(dbDataRecord["FirstName"].ToString(),
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
            SqlConnect.GetInstance().CloseConn();
        }

        public static void NumOutput(DataGridView dgvNum, DateTimePicker dateTPNum)
        {
            dgvNum.Rows.Clear();
            try
            {
                SqlConnect.GetInstance().OpenConn();
                string filterDate = dateTPNum.Text;
                string commPart =
                    "SELECT RoomNumber, PlaceQuantity, Class_ID" +
                    " FROM \"hotel\".\"Apartment\"" +
                    " EXCEPT" +
                    " SELECT RoomNumber, PlaceQuantity, Class_ID" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate < '" + filterDate + "'::date" +
                    " AND c.CheckOutDate > '" + filterDate + "'::date" +
                    " ORDER BY (RoomNumber) ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, SqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        dgvNum.Rows.Add(dbDataRecord["RoomNumber"].ToString(),
                            dbDataRecord["PlaceQuantity"].ToString(), dbDataRecord["Class_ID"].ToString());
                    }
                }
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
            SqlConnect.GetInstance().CloseConn();
        }

    }
}
