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
    public class RepositoryStaffPosition
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryStaffPosition(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableStaffPosition> GetSingleTable()
        {
            TableStaffPosition tableStaffPosition;
            var tableStaffPositionList = new List<TableStaffPosition>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"StaffPosition\"" +
                    " ORDER BY SvacantKey ;";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaffPosition = new TableStaffPosition(
                        dbDataRecord["SvacantKey"].ToString(),
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Salary"].ToString());
                    tableStaffPositionList.Add(tableStaffPosition);
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
            return tableStaffPositionList;
        }

        #endregion

        #region TableUpdate

        public void EditStaffVacant(string textBoxSvacantId, string textBoxSvacantName, string textBoxSvacantPay)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "UPDATE \"hotel\".\"StaffPosition\"" +
                    " SET SVacant = @textBoxSvacantName," +
                    " Salary = @textBoxSvacantPay" +
                    " WHERE SvacantKey = @textBoxSvacantId " +
                    ";";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxSvacantName", textBoxSvacantName);
                command.Parameters.AddWithValue("@textBoxSvacantPay", Convert.ToDouble(textBoxSvacantPay));
                command.Parameters.AddWithValue("@textBoxSvacantId", Convert.ToInt32(textBoxSvacantId));

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

        public void AddStaffVacant(string textBoxSvacantId, string textBoxSvacantName, string textBoxSvacantPay)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "INSERT INTO \"hotel\".\"StaffPosition\"" +
                    " (SvacantKey, SVacant, Salary)" +
                    " VALUES" +
                    " (@textBoxSvacantId, @textBoxSvacantName, @textBoxSvacantPay) ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxSvacantId", Convert.ToInt32(textBoxSvacantId));
                command.Parameters.AddWithValue("@textBoxSvacantName", textBoxSvacantName);
                command.Parameters.AddWithValue("@textBoxSvacantPay", Convert.ToDouble(textBoxSvacantPay));

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

        public void DeleteStaffVacant(string textBoxSvacantId)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "DELETE FROM \"hotel\".\"StaffPosition\"" +
                    " WHERE SVacantKey = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxSvacantId));
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