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

                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableAClass = new TableAClass(
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());
                    tableAClassList.Add(tableAClass);
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
            return tableAClassList;
        }

        #endregion

        #region TableInsert

        #endregion

        #region TableUpdate

        public void EditClassCost(string textBoxClass, string textBoxClassCost)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();
                string commPart =
                    "UPDATE \"hotel\".\"AClass\"" +
                    " SET ClassCost = @textBoxClassCost" +
                    " WHERE Class_ID = @textBoxClass ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);

                command.Parameters.AddWithValue("@textBoxClassCost", Convert.ToDouble(textBoxClassCost));
                command.Parameters.AddWithValue("@textBoxClass", Convert.ToInt32(textBoxClass));

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
                //sqlConnect.GetInstance().CloseConn();
            }
        }

        #endregion

        #region TableDelete

        #endregion

        #region Other

        #endregion
    }
}