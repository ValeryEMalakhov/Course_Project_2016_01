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
    public class RepositoryHotel
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryHotel(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableHotel> GetSingleTable()
        {
            TableHotel tableHotel;
            var tableHotelList = new List<TableHotel>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Hotel\";";
                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableHotel = new TableHotel(
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["OrgName"].ToString(),
                        dbDataRecord["HotelName"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["Phone"].ToString(),
                        dbDataRecord["Class"].ToString(),
                        dbDataRecord["Hotel_Link"].ToString());
                    tableHotelList.Add(tableHotel);
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
            return tableHotelList;
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