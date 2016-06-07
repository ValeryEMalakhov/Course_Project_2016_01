using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryUserApartmentCard
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryUserApartmentCard(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableUserAppartmentCard> GetUserList(string filterDate)
        {
            TableUserAppartmentCard userAppartmentCard;
            var userAppartmentCardList = new List<TableUserAppartmentCard>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                    " WHERE c.client_id = a.client_id" +
                    " AND ap.ap_id = a.ap_id" +
                    " AND a.CheckInDate <= @filterDate::timestamp with time zone" +
                    " AND a.CheckOutDate > @filterDate::timestamp with time zone " +
                    " ORDER BY a.CheckInDate ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                command.Parameters.AddWithValue("@filterDate", filterDate);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    userAppartmentCard = new TableUserAppartmentCard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["mToPay"].ToString());

                    userAppartmentCardList.Add(userAppartmentCard);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return userAppartmentCardList;
        }
        public List<TableUserAppartmentCard> GetUserListFull()
        {
            TableUserAppartmentCard userAppartmentCard;
            var userAppartmentCardList = new List<TableUserAppartmentCard>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                    " WHERE c.client_id = a.client_id" +
                    " AND ap.ap_id = a.ap_id" +
                    " ORDER BY a.CheckInDate;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                NpgsqlDataReader readerTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    userAppartmentCard = new TableUserAppartmentCard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["mToPay"].ToString());

                    userAppartmentCardList.Add(userAppartmentCard);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return userAppartmentCardList;
        }


        #endregion
    }
}