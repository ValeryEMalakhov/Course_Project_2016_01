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

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Apartment\";";
            try
            {
                // открываем соединение
                //sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartment = new TableApartment(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString());

                    tableApartmentList.Add(tableApartment);
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
            return tableApartmentList;
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
