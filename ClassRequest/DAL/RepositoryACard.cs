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
using ClassRequest.Login;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryACard
    {
        #region Global Values

        private RepositoryClient repositoryClient;
        private RepositoryUserApartmentCard repositoryUserApartmentCard;
        private RepositoryLogin repositoryLogin;
        private SqlConnect sqlConnect;

        #endregion

        public RepositoryACard(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
            repositoryClient = new RepositoryClient(_sqlConnect);
            repositoryUserApartmentCard = new RepositoryUserApartmentCard(_sqlConnect);
            repositoryLogin = new RepositoryLogin(sqlConnect);
        }

        #region TableSelect

        public List<TableACard> GetSingleTable()
        {
            TableACard tableACard;
            var tableACardList = new List<TableACard>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"ACard\";";
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
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
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
            return tableACardList;
        }

        #endregion

        #region TableInsert

        public void AddUser(string textBoxPass, string textBoxFirstName, string textBoxSecondName,
            string textBoxGender, string dtpBirth, string textBoxPhone,
            string comboBoxApId, string dtpCheckIn, string dtpCheckOut, string textBoxComm,
            string newLogIn, string newPass)
        {
            int keyClientJustInHotel = 0;
            foreach (var v in repositoryUserApartmentCard.GetUserList(Convert.ToString(DateTime.Today)))
            {
                // проверяем наличие постояльца отеле
                if (v.ClientId == textBoxPass) keyClientJustInHotel = 1;
            }
            if (keyClientJustInHotel == 0)
            {
                int keyClientInBd = 0;
                foreach (var v in repositoryClient.GetSingleTable())
                {
                    // проверяем наличие постояльца в БД
                    if (v.ClientId == textBoxPass) keyClientInBd = 1;
                }
                if (keyClientInBd == 0)
                {
                    // блок добавления в базу нового логина/пароля
                    try
                    {
                        // открываем соединение
                        //sqlConnect.GetNewSqlConn().OpenConn();
                        string commPart =
                            //INSERT INTO "login"."UserPass" (Login_ID, Pass, Vacant) VALUES

                            "INSERT INTO \"login\".\"UserPass\"" +
                            " (Login_ID, Pass, Vacant)" +
                            " VALUES" +
                            " (@Login_ID, @Pass, @Vacant)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Login_ID", Protection.Encrypt(newLogIn, "VEM"));
                        command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(newPass));
                        command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("C"));

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Новый логин: " + newLogIn + "\nНовый пароль: " + newPass);
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
                        //sqlConnect.GetNewSqlConn().CloseConn();
                    }
                    // блок добавления нового пользователя в базу
                    try
                    {
                        // открываем соединение
                        //sqlConnect.GetNewSqlConn().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"Client\"" +
                            " (Client_ID, FirstName, SecondName, Gender, DateOfBirth, Phone)" +
                            " VALUES" +
                            " (@Client_ID, @Login_ID, @FirstName, @SecondName, @Gender, @DateOfBirth::timestamp with time zone, @Phone)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Login_ID", Protection.Encrypt(newLogIn, "VEM"));
                        command.Parameters.AddWithValue("@FirstName", textBoxFirstName);
                        command.Parameters.AddWithValue("@SecondName", textBoxSecondName);
                        command.Parameters.AddWithValue("@Gender", textBoxGender);
                        command.Parameters.AddWithValue("@DateOfBirth", dtpBirth);
                        if (textBoxPhone.Length == 0)
                        {
                            textBoxPhone = @"";
                        }
                        command.Parameters.AddWithValue("@Phone", textBoxPhone);

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (NpgsqlException exp)
                        {
                            MessageBox.Show(Convert.ToString(exp));
                            repositoryLogin.RequestDeleteLogIn(newLogIn);
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
                        //sqlConnect.GetNewSqlConn().CloseConn();
                    }
                    // блок добавления человека в карту регистрации
                    try
                    {
                        // открываем соединение
                        //sqlConnect.GetNewSqlConn().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Ap_ID", Convert.ToInt32(comboBoxApId));
                        command.Parameters.AddWithValue("@CheckInDate", dtpCheckIn);
                        command.Parameters.AddWithValue("@CheckOutDate", dtpCheckOut);
                        if (textBoxComm.Length == 0)
                        {
                            textBoxComm = @"";
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
                        //sqlConnect.GetNewSqlConn().CloseConn();
                    }
                }
                else
                {
                    // блок добавления человека в карту регистрации если он уже есть в базе
                    try
                    {
                        // открываем соединение
                        //sqlConnect.GetNewSqlConn().OpenConn();
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Ap_ID", Convert.ToInt32(comboBoxApId));
                        command.Parameters.AddWithValue("@CheckInDate", dtpCheckIn);
                        command.Parameters.AddWithValue("@CheckOutDate", dtpCheckOut);
                        if (textBoxComm.Length == 0)
                        {
                            textBoxComm = @"";
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
                        //sqlConnect.GetNewSqlConn().CloseConn();
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
        public void FakeUserDeleteSql(string clientId, string checkInDate)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "UPDATE \"hotel\".\"ACard\"" +
                    " SET CheckOutDate = '" + DateTime.Today + "'" +
                    " WHERE Client_Id = @client_Id " +
                    " AND CheckInDate = @checkInDate::timestamp with time zone ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@client_Id", clientId);
                command.Parameters.AddWithValue("@checkInDate", checkInDate);

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
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
        }

        public void RequestDeleteSql(string clientId, string checkInDate)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "DELETE FROM \"hotel\".\"ACard\"" +
                    " WHERE Client_Id = @client_Id " +
                    " AND CheckInDate = @checkInDate::timestamp with time zone ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@client_Id", clientId);
                command.Parameters.AddWithValue("@checkInDate", checkInDate);

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
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
        }

        public void RequestDeleteSqlForApartment(string textBoxNum)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "DELETE FROM \"hotel\".\"ACard\"" +
                    " WHERE Ap_ID = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));
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
                //sqlConnect.GetNewSqlConn().CloseConn();
            }
        }

        #endregion

        #region Other

        #endregion
    }
}