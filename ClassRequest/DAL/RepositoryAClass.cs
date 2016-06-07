using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryAClass
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryAClass(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableAClass> GetSingleTable()
        {
            TableAClass tableAClass;
            var tableAClassList = new List<TableAClass>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"AClass\"" +
                    " ORDER BY Class_ID;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableAClass = new TableAClass(
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());
                    tableAClassList.Add(tableAClass);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableAClassList;
        }

        #endregion

        #region TableUpdate

        public void EditClassCost(string textBoxClass, string textBoxClassCost)
        {
            try
            {
                string commPart =
                    "UPDATE \"hotel\".\"AClass\"" +
                    " SET ClassCost = @textBoxClassCost" +
                    " WHERE Class_ID = @textBoxClass ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxClassCost", Convert.ToDouble(textBoxClassCost));
                command.Parameters.AddWithValue("@textBoxClass", Convert.ToInt32(textBoxClass));

                command.ExecuteNonQuery();
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