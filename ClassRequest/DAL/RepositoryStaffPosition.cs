using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
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
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableStaffPositionList;
        }

        #endregion

        #region TableUpdate

        public void EditStaffVacant(string textBoxSvacantId, string textBoxSvacantName, string textBoxSvacantPay)
        {
            try
            {
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
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        #endregion

        #region TableInsert

        public void AddStaffVacant(string textBoxSvacantId, string textBoxSvacantName, string textBoxSvacantPay)
        {
            try
            {
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
                catch (PostgresException exp)
                {
                    MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                }
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        #endregion

        #region TableDelete

        public void DeleteStaffVacant(string textBoxSvacantId)
        {
            try
            {
                string commPart =
                    "DELETE FROM \"hotel\".\"StaffPosition\"" +
                    " WHERE SVacantKey = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxSvacantId));
                command.ExecuteNonQuery();

                MessageBox.Show(@"Успешно удалено!");
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        #endregion
    }
}