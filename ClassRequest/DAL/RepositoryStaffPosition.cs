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
                    " FROM \"hotel\".\"StaffPosition\";";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaffPosition = new TableStaffPosition(
                        dbDataRecord["SvacantKey"].ToString(),
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Salary"].ToString());
                    tableStaffPositionList.Add(tableStaffPosition);
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
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
            return tableStaffPositionList;
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