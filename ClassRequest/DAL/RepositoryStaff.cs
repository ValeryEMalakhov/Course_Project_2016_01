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
    public class RepositoryStaff
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryStaff(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableStaff> GetSingleTable()
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Staff\"" +
                    " ORDER BY Staff_ID" +
                    " ;";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        Convert.ToDateTime(dbDataRecord["DateOfBirth"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["SVacantKey"].ToString(),
                        dbDataRecord["Supervisor"].ToString(),
                        dbDataRecord["RegBuilding"].ToString());
                    tableStaffList.Add(tableStaff);
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
            return tableStaffList;
        }

        public List<TableStaff> GetSingleTableWithPosition()
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            try
            {
                string commPart =
                    "SELECT s.Staff_Id, s.FirstName, s.SecondName, s.Gender, s.DateOfBirth, sv.SVacant, s.Supervisor, h.HotelName" +
                    " FROM \"hotel\".\"Staff\" s, \"hotel\".\"StaffPosition\" sv, \"hotel\".\"Hotel\" h" +
                    " WHERE s.SVacantKey = sv.SVacantKey" +
                    "  AND s.RegBuilding = h.Hotel_Id" +
                    " ORDER BY s.Staff_Id" +
                    ";";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        Convert.ToDateTime(dbDataRecord["DateOfBirth"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Supervisor"].ToString(),
                        dbDataRecord["HotelName"].ToString());
                    tableStaffList.Add(tableStaff);
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
            return tableStaffList;
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