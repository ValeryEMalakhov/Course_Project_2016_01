using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryApartmentAClass
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryApartmentAClass(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableApartmentAClass> GetNumList(string filterDate)
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            try
            {
                string commPart =
                    "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                    " WHERE a.Class_ID = s.Class_ID" +
                    " EXCEPT" +
                    " SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate <= @filterDate::timestamp with time zone" +
                    " AND c.CheckOutDate > @filterDate::timestamp with time zone" +
                    " ORDER BY (Ap_ID) ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                command.Parameters.AddWithValue("@filterDate", filterDate);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableApartmentList;
        }

        public List<TableApartmentAClass> GetNumList(string filterDateIn, string filterDateOut)
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            try
            {
                string commPart =
                    "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                    " WHERE a.Class_ID = s.Class_ID" +
                    " EXCEPT" +
                    " SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate <= @filterDateIn::timestamp with time zone" +
                    " AND c.CheckOutDate > @filterDateIn::timestamp with time zone" +
                    " EXCEPT" +
                    " SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                    " WHERE a.ap_id = c.ap_id" +
                    " AND c.CheckInDate <= @filterDateOut::timestamp with time zone" +
                    " AND c.CheckOutDate > @filterDateOut::timestamp with time zone" +
                    " ORDER BY (Ap_ID) ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                command.Parameters.AddWithValue("@filterDateIn", filterDateIn);
                command.Parameters.AddWithValue("@filterDateOut", filterDateOut);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableApartmentList;
        }

        public List<TableApartmentAClass> GetNumListFull()
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            try
            {
                string commPart =
                    "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                    " WHERE a.Class_ID = s.Class_ID" +
                    " ORDER BY (Ap_ID) ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableApartmentList;
        }

        public List<TableApartmentAClass> UpdateStatAdd()
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            try
            {
                string commPart =
                    "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                    " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                    " WHERE a.Class_ID = s.Class_ID";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableApartmentList;
        }

        #endregion
    }
}