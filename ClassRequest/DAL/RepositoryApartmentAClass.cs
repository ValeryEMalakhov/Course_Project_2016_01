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
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

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
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

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

                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

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
            return tableApartmentList;
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