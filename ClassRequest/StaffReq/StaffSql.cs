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

namespace ClassRequest.StaffReq
{
    public class StaffSql
    {
        // глобальные переменные
        SqlConnect sqlConnect = new SqlConnect();
        SelectTable selectTable = new SelectTable();

        public List<UserAppartmentCard> GetUserList(string filterDate)
        {
            UserAppartmentCard userAppartmentCard;
            var userAppartmentCardList = new List<UserAppartmentCard>();

            //MessageBox.Show(filterDate);

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                " WHERE c.client_id = a.client_id" +
                " AND ap.ap_id = a.ap_id" +
                " AND a.CheckInDate <= '" + filterDate + "'::timestamp with time zone" +
                " AND a.CheckOutDate > '" + filterDate + "'::timestamp with time zone ;";

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

        public List<ApartmentAClass> GetNumList(string filterDate)
        {
            ApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<ApartmentAClass>();

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
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartmentAClass = new ApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
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
            return tableApartmentList;
        }

        // добавление посетителя
        public void AddUser(string textBoxPass, string textBoxFirstName, string textBoxSecondName,
            string textBoxGender, string dtpBirth, string textBoxPhone,
            string comboBoxApId, string dtpCheckIn, string dtpCheckOut, string textBoxComm)
        {
            int keyClientJustInHotel = 0;
            foreach (var v in GetUserList(Convert.ToString(DateTime.Today)))
            {
                // проверяем наличие постояльца отеле
                if (v.ClientId == textBoxPass) keyClientJustInHotel = 1;
            }
            if (keyClientJustInHotel == 0)
            {
                int keyClientInBD = 0;
                foreach (var v in selectTable.GetTableClient())
                {
                    // проверяем наличие постояльца в БД
                    if (v.ClientId == textBoxPass) keyClientInBD = 1;
                }
                if (keyClientInBD == 0)
                {
                    // блок добавления нового пользователя в базу
                    try
                    {
                        // открываем соединение
                        sqlConnect.GetInstance().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"Client\"" +
                            " (Client_ID, FirstName, SecondName, Gender, DateOfBirth, Phone)" +
                            " VALUES" +
                            " (@Client_ID, @FirstName, @SecondName, @Gender, @DateOfBirth::timestamp with time zone, @Phone)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@FirstName", textBoxFirstName);
                        command.Parameters.AddWithValue("@SecondName", textBoxSecondName);
                        command.Parameters.AddWithValue("@Gender", textBoxGender);
                        command.Parameters.AddWithValue("@DateOfBirth", dtpBirth);
                        if (textBoxPhone.Length == 0)
                        {
                            textBoxPhone = "";
                        }
                        command.Parameters.AddWithValue("@Phone", textBoxPhone);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (NpgsqlException exp)
                        {
                            MessageBox.Show(Convert.ToString(exp));
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
                    // блок добавления человека в карту регистрации
                    try
                    {
                        // открываем соединение
                        sqlConnect.GetInstance().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Ap_ID", Convert.ToInt32(comboBoxApId));
                        command.Parameters.AddWithValue("@CheckInDate", dtpCheckIn);
                        command.Parameters.AddWithValue("@CheckOutDate", dtpCheckOut);
                        if (textBoxComm.Length == 0)
                        {
                            textBoxComm = "";
                        }
                        command.Parameters.AddWithValue("@StComment", textBoxComm);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(@"Успешно добавлен/на!");
                        }
                        catch (NpgsqlException exp)
                        {
                            MessageBox.Show(Convert.ToString(exp));
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
                }
                else
                {
                    // блок добавления человека в карту регистрации если он уже есть в базе
                    try
                    {
                        // открываем соединение
                        sqlConnect.GetInstance().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Ap_ID", Convert.ToInt32(comboBoxApId));
                        command.Parameters.AddWithValue("@CheckInDate", dtpCheckIn);
                        command.Parameters.AddWithValue("@CheckOutDate", dtpCheckOut);
                        if (textBoxComm.Length == 0)
                        {
                            textBoxComm = "";
                        }
                        command.Parameters.AddWithValue("@StComment", textBoxComm);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(@"Успешно добавлен/на!");
                        }
                        catch (NpgsqlException exp)
                        {
                            MessageBox.Show(Convert.ToString(exp));
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
                }
            }
            else
            {
                MessageBox.Show(@"Постоялец таки уже в отеле!");
            }
        }
        public List<ApartmentAClass> UpdateStatAdd()
        {
            ApartmentAClass tableApartmentAClass;
            var tableApartmentList = new List<ApartmentAClass>();

            string commPart =
                "SELECT a.Ap_ID, a.Hotel_ID, a.PlaceQuantity, a.Class_ID, s.ClassCost" +
                " FROM \"hotel\".\"Apartment\" a, \"hotel\".\"AClass\" s" +
                " WHERE a.Class_ID = s.Class_ID";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartmentAClass = new ApartmentAClass(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartmentAClass);
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
            return tableApartmentList;
        }

        public void FakeUserDeleteSQL(UserAppartmentCard userAppartmentCard)
        {
            string commPart =
                "UPDATE \"hotel\".\"ACard\"" +
                " SET CheckOutDate = '" + DateTime.Now + "'" +
                " WHERE Client_Id = '" + userAppartmentCard.ClientId + "'" +
                " AND CheckInDate = '" + userAppartmentCard.CheckInDate + "' ;";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                command.ExecuteNonQuery();
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
        }
    }
}