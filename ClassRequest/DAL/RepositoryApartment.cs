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
    public class RepositoryApartment
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryApartment(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableApartment> GetSingleTable()
        {
            TableApartment tableApartment;
            var tableApartmentList = new List<TableApartment>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Apartment\"" +
                    " ORDER BY (Ap_ID) ;";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableApartment = new TableApartment(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString());

                    tableApartmentList.Add(tableApartment);
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

        #region TableUpdate

        public void EditApartment(string textBoxNum, string textBoxNumHotel, string textBoxPlace,
            string textBoxNumClass)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "UPDATE \"hotel\".\"Apartment\"" +
                    " SET Hotel_ID = @textBoxNumHotel," +
                    " PlaceQuantity = @textBoxPlace," +
                    " Class_ID = @textBoxNumClass" +
                    " WHERE Ap_ID = @textBoxNum " +
                    ";";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNumHotel", Convert.ToInt32(textBoxNumHotel));
                command.Parameters.AddWithValue("@textBoxPlace", Convert.ToInt32(textBoxPlace));
                command.Parameters.AddWithValue("@textBoxNumClass", Convert.ToInt32(textBoxNumClass));
                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));

                command.ExecuteNonQuery();
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
        }

        #endregion

        #region TableInsert

        public void AddApartment(string textBoxNum, string textBoxNumHotel, string textBoxPlace,
            string textBoxNumClass)
        {
            // открываем соединение
            //sqlConnect.GetNewSqlConn().OpenConn();
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "INSERT INTO \"hotel\".\"Apartment\"" +
                    " (Ap_ID, Hotel_ID, PlaceQuantity, Class_ID)" +
                    " VALUES" +
                    " (@textBoxNum, @textBoxNumHotel, @textBoxPlace, @textBoxNumClass) ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));
                command.Parameters.AddWithValue("@textBoxNumHotel", Convert.ToInt32(textBoxNumHotel));
                command.Parameters.AddWithValue("@textBoxPlace", Convert.ToInt32(textBoxPlace));
                command.Parameters.AddWithValue("@textBoxNumClass", Convert.ToInt32(textBoxNumClass));

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (NpgsqlException exp)
                {
                    MessageBox.Show(Convert.ToString(exp));
                }
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
        }

        #endregion

        #region TableDelete

        public void DeleteApartment(string textBoxNum)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "DELETE FROM \"hotel\".\"Apartment\"" +
                    " WHERE Ap_ID = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));
                command.ExecuteNonQuery();

                MessageBox.Show(@"Успешно удалено!");
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
        }

        #endregion

        #region Other

        #endregion
    }
}