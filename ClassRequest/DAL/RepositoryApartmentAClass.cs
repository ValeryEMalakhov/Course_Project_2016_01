﻿using System;
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
    public class RepositoryApartmentAClass
    {
        #region Global Values
        //RepositoryACard repositoryACard = new RepositoryACard();
        //RepositoryAClass repositoryAClass = new RepositoryAClass();
        //RepositoryApartment repositoryApartment = new RepositoryApartment();
        //RepositoryClient repositoryClient = new RepositoryClient();
        //RepositoryHotel repositoryHotel = new RepositoryHotel();
        //RepositoryStaff repositoryStaff = new RepositoryStaff();
        //RepositoryStaffPosition repositoryStaffPosition = new RepositoryStaffPosition();
        //RepositoryUserApartmentCard repositoryUserApartmentCard = new RepositoryUserApartmentCard();
        #endregion
        #region TableSelect
        public List<TableApartmentAClass> GetNumList(SqlConnect sqlConnect, string filterDate)
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            string commPart =
                "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                " WHERE a.Class_ID = s.Class_ID" +
                " EXCEPT" +
                " SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                " WHERE a.ap_id = c.ap_id" +
                " AND c.CheckInDate <= '" + filterDate + "'::timestamp with time zone" +
                " AND c.CheckOutDate > '" + filterDate + "'::timestamp with time zone" +
                " ORDER BY (Ap_ID) ;";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
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
            return tableApartmentList;
        }
        public List<TableApartmentAClass> UpdateStatAdd(SqlConnect sqlConnect)
        {
            TableApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<TableApartmentAClass>();

            string commPart =
                "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                " WHERE a.Class_ID = s.Class_ID";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartmentAClass = new TableApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
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