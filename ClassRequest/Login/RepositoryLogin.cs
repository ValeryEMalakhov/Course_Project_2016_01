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
using ClassRequest.Login;
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
                    " FROM \"login\".\"UserPass\" ;";

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
            return tableLoginList;
        }

        #endregion

        #region TableInsert

        public void AddUser(string textBoxLogIn, string textBoxPass, string textBoxUserId, string textBoxFirstName, string textBoxSecondName,
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
                    // открываем соединение
                    //sqlConnect.GetNewSqlConn().OpenConn();
                    string commPart =
                        //INSERT INTO "login"."UserPass" (Login_ID, Pass, Vacant) VALUES

                        "INSERT INTO \"login\".\"UserPass\"" +
                        " (Login_ID, Pass, Vacant)" +
                        " VALUES" +
                        " (@Login_ID, @Pass, @Vacant)";

                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@Login_ID", Protection.Encrypt(textBoxLogIn, "VEM"));
                    command.Parameters.AddWithValue("@Pass", Protection.EncryptMD5(textBoxPass));
                    command.Parameters.AddWithValue("@Vacant", Protection.EncryptMD5("C"));

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
                    //sqlConnect.GetNewSqlConn().CloseConn();
                }
                // блок добавления нового пользователя в базу
                try
                {
                    // открываем соединение
                    //sqlConnect.GetNewSqlConn().OpenConn();
                    string commPart =
                        "INSERT INTO \"hotel\".\"Client\"" +
                        " (Client_ID, Login_ID, FirstName, SecondName, Gender, DateOfBirth, Phone)" +
                        " VALUES" +
                        " (@Client_ID, @Login_ID, @FirstName, @SecondName, @Gender, @DateOfBirth::timestamp with time zone, @Phone)";

                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@Client_ID", textBoxUserId);
                    command.Parameters.AddWithValue("@Login_ID", Protection.Encrypt(textBoxLogIn, "VEM"));
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
                MessageBox.Show(@"Такой пользователь уже есть в системе");
            }
        }


        #endregion

        #region TableUpdate



        #endregion

        #region TableDelete

        public void RequestDeleteLogIn(string logIn)
        {
            try
            {
                // открываем соединение
                //sqlConnect.GetNewSqlConn().OpenConn();
                string commPart =
                    "DELETE FROM \"login\".\"UserPass\"" +
                    " WHERE Login_ID = @logIn ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@logIn", Protection.Encrypt(logIn, "VEM"));
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
