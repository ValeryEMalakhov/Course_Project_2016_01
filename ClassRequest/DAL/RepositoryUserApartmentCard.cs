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

            //MessageBox.Show(filterDate);

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                " WHERE c.client_id = a.client_id" +
                " AND ap.ap_id = a.ap_id" +
                " AND a.CheckInDate <= @filterDate::timestamp with time zone" +
                " AND a.CheckOutDate > @filterDate::timestamp with time zone ;";
            try
            {
                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                command.Parameters.AddWithValue("@filterDate", filterDate);

                NpgsqlDataReader readerUserTable = command.ExecuteReader();
                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    userAppartmentCard = new TableUserAppartmentCard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString());

                    userAppartmentCardList.Add(userAppartmentCard);
                }
                readerUserTable.Close();
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                //sqlConnect.GetInstance().CloseConn();
            }
            return userAppartmentCardList;
        }
        #endregion
        #region TableInsert

        #endregion
        #region TableDelete

        #endregion
        #region Other

        #endregion
    }
}
