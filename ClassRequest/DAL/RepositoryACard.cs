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
    public class RepositoryACard
    {
        #region Global Values
        //RepositoryAClass repositoryAClass = new RepositoryAClass();
        //RepositoryApartment repositoryApartment = new RepositoryApartment();
        //RepositoryApartmentAClass repositoryApartmentAClass = new RepositoryApartmentAClass();
        RepositoryClient repositoryClient = new RepositoryClient();
        //RepositoryHotel repositoryHotel = new RepositoryHotel();
        //RepositoryStaff repositoryStaff = new RepositoryStaff();
        //RepositoryStaffPosition repositoryStaffPosition = new RepositoryStaffPosition();
        RepositoryUserApartmentCard repositoryUserApartmentCard = new RepositoryUserApartmentCard();
        #endregion
        #region TableSelect
        public List<TableACard> GetSingleTable(SqlConnect sqlConnect)
        {
            TableACard tableACard;
            var tableACardList = new List<TableACard>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"ACard\";";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableACard = new TableACard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["StComment"].ToString());
                    tableACardList.Add(tableACard);
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
            return tableACardList;
        }
        #endregion
        #region TableInsert
        public void AddUser(SqlConnect sqlConnect, string textBoxPass, string textBoxFirstName, string textBoxSecondName,
    string textBoxGender, string dtpBirth, string textBoxPhone,
    string comboBoxApId, string dtpCheckIn, string dtpCheckOut, string textBoxComm)
        {
            int keyClientJustInHotel = 0;
            foreach (var v in repositoryUserApartmentCard.GetUserList(sqlConnect, Convert.ToString(DateTime.Today)))
            {
                // проверяем наличие постояльца отеле
                if (v.ClientId == textBoxPass) keyClientJustInHotel = 1;
            }
            if (keyClientJustInHotel == 0)
            {
                int keyClientInBd = 0;
                foreach (var v in repositoryClient.GetSingleTable(sqlConnect))
                {
                    // проверяем наличие постояльца в БД
                    if (v.ClientId == textBoxPass) keyClientInBd = 1;
                }
                if (keyClientInBd == 0)
                {
                    // блок добавления нового пользователя в базу
                    try
                    {
                        // открываем соединение
                        // sqlConnect.GetInstance().OpenConn();
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
                        // sqlConnect.GetInstance().CloseConn();
                    }
                    // блок добавления человека в карту регистрации
                    try
                    {
                        // открываем соединение
                        // sqlConnect.GetInstance().OpenConn();
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
                        // sqlConnect.GetInstance().CloseConn();
                    }
                }
                else
                {
                    // блок добавления человека в карту регистрации если он уже есть в базе
                    try
                    {
                        // открываем соединение
                        // sqlConnect.GetInstance().OpenConn();
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
                        // sqlConnect.GetInstance().CloseConn();
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Постоялец таки уже в отеле!");
            }
        }
        #endregion
        #region TableDelete
        // псевдо удаление, реализуется изменением данных в строке
        public void FakeUserDeleteSql(SqlConnect sqlConnect, TableUserAppartmentCard userAppartmentCard)
        {
            string commPart =
                "UPDATE \"hotel\".\"ACard\"" +
                " SET CheckOutDate = '" + DateTime.Now + "'" +
                " WHERE Client_Id = '" + userAppartmentCard.ClientId + "'" +
                " AND CheckInDate = '" + userAppartmentCard.CheckInDate + "' ;";
            try
            {
                // открываем соединение
                // sqlConnect.GetInstance().OpenConn();

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
                // sqlConnect.GetInstance().CloseConn();
            }
        }
        #endregion
        #region Other

        #endregion
    }
}
