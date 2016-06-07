using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
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
                    " FROM \"hotel\".\"ACard\"" +
                    " ORDER BY CheckInDate;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableACard = new TableACard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["StComment"].ToString(),
                        dbDataRecord["mToPay"].ToString());
                    tableACardList.Add(tableACard);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                // MessageBox.Show("Не удалось выполнить запрос!");
                // MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableACardList;
        }

        #endregion

        #region TableInsert

        public void AddUser(string textBoxPass, string textBoxFirstName, string textBoxSecondName,
            string textBoxGender, string dtpBirth, string textBoxPhone,
            string comboBoxApId, string dtpCheckIn, string dtpCheckOut, string textBoxComm, double mToPay,
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
                        string commPart =
                            "INSERT INTO \"login\".\"UserPass\"" +
                            " (Login_ID, Pass, Vacant)" +
                            " VALUES" +
                            " (@Login_ID, @Pass, @Vacant)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(newLogIn));
                        command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(newPass));
                        command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("C"));

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Новый логин: " + newLogIn + "\nНовый пароль: " + newPass);
                        }
                        catch (PostgresException exp)
                        {
                            MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                        }
                    }
                    catch (PostgresException exp)
                    {
                        // MessageBox.Show("Не удалось выполнить запрос!");
                        MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                    }
                    // блок добавления нового пользователя в базу
                    try
                    {
                        string commPart =
                            "INSERT INTO \"hotel\".\"Client\"" +
                            " (Client_ID, FirstName, SecondName, Gender, DateOfBirth, Phone)" +
                            " VALUES" +
                            " (@Client_ID, @Login_ID, @FirstName, @SecondName, @Gender, @DateOfBirth::timestamp with time zone, @Phone)";

                        NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                        command.Parameters.AddWithValue("@Client_ID", textBoxPass);
                        command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(newLogIn));
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
                        catch (PostgresException exp)
                        {
                            MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                            repositoryLogin.RequestDeleteLogIn(newLogIn);
                        }
                    }
                    catch (PostgresException exp)
                    {
                        // MessageBox.Show("Не удалось выполнить запрос!");
                        MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                    }
                    // блок добавления человека в карту регистрации
                    try
                    {
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment, mToPay)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment, @mToPay)";

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
                        command.Parameters.AddWithValue("@mToPay", mToPay);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(@"Успешно добавлен/на!");
                        }
                        catch (PostgresException exp)
                        {
                            MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                        }
                    }
                    catch (PostgresException exp)
                    {
                        // MessageBox.Show("Не удалось выполнить запрос!");
                        MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                    }
                }
                else
                {
                    // блок добавления человека в карту регистрации если он уже есть в базе
                    try
                    {
                        string commPart =
                            "INSERT INTO \"hotel\".\"ACard\"" +
                            " (Client_ID, Ap_ID, CheckInDate, CheckOutDate, StComment, mToPay)" +
                            " VALUES" +
                            " (@Client_ID, @Ap_ID, @CheckInDate::timestamp with time zone, @CheckOutDate::timestamp with time zone, @StComment, @mToPay)";

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
                        command.Parameters.AddWithValue("@mToPay", mToPay);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show(@"Успешно добавлен/на!");
                        }
                        catch (PostgresException exp)
                        {
                            MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                        }
                    }
                    catch (PostgresException exp)
                    {
                        // MessageBox.Show("Не удалось выполнить запрос!");
                        MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Гость уже в отеле!");
            }
        }

        #endregion

        #region TableDelete

        // псевдо удаление, реализуется изменением данных в строке
        public void FakeUserDeleteSql(string clientId, string checkInDate)
        {
            try
            {
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
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        public void RequestDeleteSql(string clientId, string checkInDate)
        {
            try
            {
                string commPart =
                    "DELETE FROM \"hotel\".\"ACard\"" +
                    " WHERE Client_Id = @client_Id " +
                    " AND CheckInDate = @checkInDate::timestamp with time zone ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@client_Id", clientId);
                command.Parameters.AddWithValue("@checkInDate", checkInDate);

                command.ExecuteNonQuery();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        public void RequestDeleteSqlForApartment(string textBoxNum)
        {
            try
            {
                string commPart =
                    "DELETE FROM \"hotel\".\"ACard\"" +
                    " WHERE Ap_ID = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));
                command.ExecuteNonQuery();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }

        #endregion
    }
}