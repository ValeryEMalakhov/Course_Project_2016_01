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
        //RepositoryACard repositoryACard = new RepositoryACard();
        //RepositoryApartment repositoryApartment = new RepositoryApartment();
        //RepositoryApartmentAClass repositoryApartmentAClass = new RepositoryApartmentAClass();
        //RepositoryClient repositoryClient = new RepositoryClient();
        //RepositoryHotel repositoryHotel = new RepositoryHotel();
        //RepositoryStaff repositoryStaff = new RepositoryStaff();
        //RepositoryStaffPosition repositoryStaffPosition = new RepositoryStaffPosition();
        //RepositoryUserApartmentCard repositoryUserApartmentCard = new RepositoryUserApartmentCard();
        #endregion
        #region TableSelect
        public List<TableAClass> GetSingleTable(SqlConnect sqlConnect)
        {
            TableAClass tableAClass;
            var tableAClassList = new List<TableAClass>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"AClass\";";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

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
                // sqlConnect.GetInstance().CloseConn();
            }
            return tableAClassList;
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
