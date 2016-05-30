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
    public class RepositoryHotelACardApartment
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryHotelACardApartment(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableHotelACardApartment> GetSingleTable()
        {
            TableHotelACardApartment tableHotelACardApartment;
            var tableHotelACardApartmentList = new List<TableHotelACardApartment>();

            try
            {
                string commPart =
                    "SELECT h.Hotel_ID, ac.Ap_ID, ac.CheckInDate, ac.CheckOutDate" +
                    " FROM \"hotel\".\"Hotel\" h, \"hotel\".\"ACard\" ac, \"hotel\".\"Apartment\" a" +
                    " WHERE h.Hotel_ID = a.Hotel_ID" +
                    " AND a.Ap_ID = ac.Ap_ID" +
                    " ORDER BY ac.CheckInDate ;";

                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableHotelACardApartment = new TableHotelACardApartment(
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString());
                    tableHotelACardApartmentList.Add(tableHotelACardApartment);
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
            return tableHotelACardApartmentList;
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
