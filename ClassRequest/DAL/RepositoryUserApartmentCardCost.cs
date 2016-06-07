using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryUserApartmentCardCost
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryUserApartmentCardCost(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableUserAppartmentCardCost> GetSingleLogList(string loginId)
        {
            TableUserAppartmentCardCost userAppartmentCardCost;
            var userAppartmentCardCostList = new List<TableUserAppartmentCardCost>();
            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap, \"hotel\".\"AClass\" ac" +
                    " WHERE c.client_id = a.client_id" +
                    " AND c.client_id = @loginId" +
                    " AND ap.ap_id = a.ap_id" +
                    " AND ap.class_id = ac.class_id ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                command.Parameters.AddWithValue("@loginId", loginId);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    userAppartmentCardCost = new TableUserAppartmentCardCost(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    userAppartmentCardCostList.Add(userAppartmentCardCost);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return userAppartmentCardCostList;
        }
        public List<TableUserAppartmentCardCost> GetSingleNewList(string loginId)
        {
            TableUserAppartmentCardCost userAppartmentCardCost;
            var userAppartmentCardCostList = new List<TableUserAppartmentCardCost>();
            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap, \"hotel\".\"AClass\" ac" +
                    " WHERE c.client_id = a.client_id" +
                    " AND c.client_id = @loginId" +
                    " AND ap.ap_id = a.ap_id" +
                    " AND ap.class_id = ac.class_id" +
                    " AND a.CheckInDate >= @filterDate::timestamp with time zone;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                command.Parameters.AddWithValue("@loginId", loginId);
                command.Parameters.AddWithValue("@filterDate", DateTime.Today);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    userAppartmentCardCost = new TableUserAppartmentCardCost(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    userAppartmentCardCostList.Add(userAppartmentCardCost);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return userAppartmentCardCostList;
        }

        #endregion
    }
}