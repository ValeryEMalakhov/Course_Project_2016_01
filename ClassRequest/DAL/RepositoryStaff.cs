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
        //RepositoryACard repositoryACard = new RepositoryACard();
        //RepositoryAClass repositoryAClass = new RepositoryAClass();
        //RepositoryApartment repositoryApartment = new RepositoryApartment();
        //RepositoryApartmentAClass repositoryApartmentAClass = new RepositoryApartmentAClass();
        //RepositoryClient repositoryClient = new RepositoryClient();
        //RepositoryHotel repositoryHotel = new RepositoryHotel();
        //RepositoryStaffPosition repositoryStaffPosition = new RepositoryStaffPosition();
        //RepositoryUserApartmentCard repositoryUserApartmentCard = new RepositoryUserApartmentCard();
        #endregion
        #region TableSelect
        public List<TableStaff> GetSingleTable(SqlConnect sqlConnect)
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Staff\";";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["DateOfBirth"].ToString(),
                        dbDataRecord["SVacant"].ToString(),
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
                // sqlConnect.GetInstance().CloseConn();
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
