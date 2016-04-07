using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data.Common;
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ClassRequest.DAL;
using ClassRequest.StaffReq;
using Npgsql;

namespace ClassRequest
{
    public class StaffRequest
    {

        // вывод списка посетителей
        public static void UserOutput(DataGridView dgvUser, DateTimePicker dateTPUser)
        {
            dgvUser.Rows.Clear();
            try
            {
                SqlConnect.GetInstance().OpenConn();

                string filterDate = dateTPUser.Text;
                foreach (var v in StaffSql.GetUserList(filterDate))
                {
                    dgvUser.Rows.Add(v.GetFirstName(), v.GetSecondName(), v.GetGender(), v.GetAp_Id(),
                        v.GetCheckInDate(), v.GetCheckOutDate(), v.GetClient_Id());
                }

                SqlConnect.GetInstance().CloseConn();
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                SqlConnect.GetInstance().CloseConn();
            }
        }





        // вывод списка свободных номеров
        public static void NumOutput(DataGridView dgvNum, DateTimePicker dateTPNum)
        {
            dgvNum.Rows.Clear();
            try
            {
                SqlConnect.GetInstance().OpenConn();
                string filterDate = dateTPNum.Text;
                string commPart =
                    "SELECT a.Ap_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                    " WHERE a.Class_ID = s.Class_ID" +
                    " EXCEPT" +
                    " SELECT a.Ap_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate < '" + filterDate + "'::date" +
                    " AND c.CheckOutDate > '" + filterDate + "'::date" +
                    " ORDER BY (Ap_ID) ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, SqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                if (readerUserTable.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in readerUserTable)
                    {
                        dgvNum.Rows.Add(dbDataRecord["Ap_ID"].ToString(), dbDataRecord["PlaceQuantity"].ToString(),
                            dbDataRecord["Class_ID"].ToString(), dbDataRecord["ClassCost"].ToString());
                    }
                }
            }
            catch (NpgsqlException exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
            SqlConnect.GetInstance().CloseConn();
        }

        // добавление посетителя
        public static void AddUser()
        {

        }


        // сам запрос в user




    }
}
