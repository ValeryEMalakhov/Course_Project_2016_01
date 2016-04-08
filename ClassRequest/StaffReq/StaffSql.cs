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
using Npgsql;

namespace ClassRequest.StaffReq
{
    public class StaffSql
    {
        // глобальные переменные
        SqlConnect sqlConnect = new SqlConnect();

        public List<UserAppartmentCard> GetUserList(string filterDate)
        {
            UserAppartmentCard userAppartmentCard;
            var userAppartmentCardList = new List<UserAppartmentCard>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                " WHERE c.client_id = a.client_id" +
                " AND ap.ap_id = a.ap_id" +
                " AND a.CheckInDate < '" + filterDate + "'::date" +
                " AND a.CheckOutDate > '" + filterDate + "'::date ;";

            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    userAppartmentCard = new UserAppartmentCard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString());

                    userAppartmentCardList.Add(userAppartmentCard);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return userAppartmentCardList;
        }

        public List<AppartmentClass> GetNumList(string filterDate)
        {
            AppartmentClass appartmentClass;
            var appartmentClassList = new List<AppartmentClass>();

            string commPart =
                "SELECT a.Ap_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                " WHERE a.Class_ID = s.Class_ID" +
                " EXCEPT" +
                " SELECT a.Ap_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"ACard\" c, \"hotel\".\"AClass\" s" +
                " WHERE a.ap_id = c.ap_id" +
                " AND c.CheckInDate < '" + filterDate + "'::date" +
                " AND c.CheckOutDate > '" + filterDate + "'::date" +
                " ORDER BY (Ap_ID) ;";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    appartmentClass = new AppartmentClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    appartmentClassList.Add(appartmentClass);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return appartmentClassList;
        }




    }
}