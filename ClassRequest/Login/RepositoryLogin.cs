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
using ClassRequest.Login;
using Npgsql;

namespace ClassRequest.Login
{
    public class RepositoryLogin
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryLogin(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableLogin> GetSingleTable()
        {
            TableLogin tableLogin;
            var tableLoginList = new List<TableLogin>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"login\".\"UserPass\" ;";

                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableLogin = new TableLogin(
                        dbDataRecord["Login_ID"].ToString(),
                        dbDataRecord["Pass"].ToString(),
                        dbDataRecord["Vacant"].ToString());
                    tableLoginList.Add(tableLogin);
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
            return tableLoginList;
        }

        #endregion

        #region TableInsert

        #endregion

        #region TableUpdate

        #endregion

        #region TableDelete

        #endregion

        #region Other

        #endregion
    }
}
