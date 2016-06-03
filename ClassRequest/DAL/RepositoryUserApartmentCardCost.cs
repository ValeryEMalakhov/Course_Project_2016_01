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

                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

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
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                //sqlConnect.GetNewSqlConn().CloseConn();
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

                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

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
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
            return userAppartmentCardCostList;
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