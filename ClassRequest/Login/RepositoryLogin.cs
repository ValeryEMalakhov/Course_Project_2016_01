using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.DAL;
using Npgsql;

namespace ClassRequest.Login
{
    public class RepositoryLogin
    {
        #region Global Values

        private SqlConnect sqlConnect;
        private RepositoryClient repositoryClient;

        #endregion

        public RepositoryLogin(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
            repositoryClient = new RepositoryClient(sqlConnect);
        }

        #region TableSelect

        public List<TableLogin> GetSingleTable()
        {
            TableLogin tableLogin;
            var tableLoginList = new List<TableLogin>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"login\".\"UserPass\" " +
                    " ORDER BY Vacant;";

                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableLogin = new TableLogin(
                        dbDataRecord["Login_ID"].ToString(),
                        dbDataRecord["Pass"].ToString(),
                        dbDataRecord["Vacant"].ToString());
                    tableLoginList.Add(tableLogin);
                }
                readerTable.Close();
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
            return tableLoginList;
        }

        #endregion

        #region TableInsert

        public void AddUser(string textBoxLogIn, string textBoxPass, string textBoxUserId, string textBoxFirstName,
            string textBoxSecondName,
            string textBoxGender, string dtpBirth, string textBoxPhone)
        {
            int keyClientInBd = 0;
            foreach (var v in repositoryClient.GetSingleTable())
            {
                // проверяем наличие постояльца в БД
                if (v.ClientId == textBoxUserId) keyClientInBd = 1;
            }
            if (keyClientInBd == 0)
            {
                // блок добавления нового пользователя в базу логинов
                try
                {
                    string commPart =
                        "INSERT INTO \"login\".\"UserPass\"" +
                        " (Login_ID, Pass, Vacant)" +
                        " VALUES" +
                        " (@Login_ID, @Pass, @Vacant)";

                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(textBoxLogIn));
                    command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(textBoxPass));
                    command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("C"));

                    try
                    {
                        command.ExecuteNonQuery();
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
                        " (Client_ID, Login_ID, FirstName, SecondName, Gender, DateOfBirth, Phone)" +
                        " VALUES" +
                        " (@Client_ID, @Login_ID, @FirstName, @SecondName, @Gender, @DateOfBirth::timestamp with time zone, @Phone)";

                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@Client_ID", textBoxUserId);
                    command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(textBoxLogIn));
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
                        MessageBox.Show(@"Успешно добавлено!");
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
                MessageBox.Show(@"Такой пользователь уже есть в системе");
            }
        }

        public void AddUserAdmin(string textBoxLogIn, string textBoxPass)
        {
            // блок добавления нового пользователя в базу логинов
            try
            {
                string commPart =
                    "INSERT INTO \"login\".\"UserPass\"" +
                    " (Login_ID, Pass, Vacant)" +
                    " VALUES" +
                    " (@Login_ID, @Pass, @Vacant)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(textBoxLogIn));
                command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(textBoxPass));
                command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("A"));

                try
                {
                    command.ExecuteNonQuery();
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
        public void AddUserStaff(string textBoxLogIn, string textBoxPass)
        {
            // блок добавления нового пользователя в базу логинов
            try
            {
                string commPart =
                    "INSERT INTO \"login\".\"UserPass\"" +
                    " (Login_ID, Pass, Vacant)" +
                    " VALUES" +
                    " (@Login_ID, @Pass, @Vacant)";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@Login_ID", Protection.DESEncrypt(textBoxLogIn));
                command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(textBoxPass));
                command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("A"));

                try
                {
                    command.ExecuteNonQuery();
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

        #endregion

        #region TableUpdate

        public void TableAdminEditPass(string newPass)
        {
            try
            {
                string commPart =
                    "UPDATE \"login\".\"UserPass\"" +
                    " SET Pass = @newPass" +
                    " WHERE Login_ID = @loginId ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@newPass", Protection.EncryptMD5(newPass));
                command.Parameters.AddWithValue("@loginId", Protection.DESEncrypt("admin"));

                command.ExecuteNonQuery();
                MessageBox.Show(@"Данные успешно измененны");
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }
        public void TableStaffEditPass(string newPass)
        {
            try
            {
                string commPart =
                    "UPDATE \"login\".\"UserPass\"" +
                    " SET Pass = @newPass" +
                    " WHERE Login_ID = @loginId ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@newPass", Protection.EncryptMD5(newPass));
                command.Parameters.AddWithValue("@loginId", Protection.DESEncrypt("staff"));

                command.ExecuteNonQuery();
                MessageBox.Show(@"Данные успешно измененны");
            }
            catch (PostgresException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне БД.\r\nКод ошибки: " + Convert.ToString(exp.SqlState));
            }
        }
        #endregion

        #region TableDelete

        public void RequestDeleteLogIn(string logIn)
        {
            try
            {
                string commPart =
                    "DELETE FROM \"login\".\"UserPass\"" +
                    " WHERE Login_ID = @logIn ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@logIn", Protection.DESEncrypt(logIn));
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