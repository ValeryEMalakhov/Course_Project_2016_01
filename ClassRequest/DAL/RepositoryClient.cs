using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryClient
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryClient(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableClient> GetSingleTable()
        {
            TableClient tableClient;
            var tableClientList = new List<TableClient>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Client\"" +
                    " ORDER BY Client_ID;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableClient = new TableClient(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Login_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        Convert.ToDateTime(dbDataRecord["DateOfBirth"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["Phone"].ToString());
                    tableClientList.Add(tableClient);
                }
                readerTable.Close();
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            return tableClientList;
        }

        #endregion

        #region TableUpdate

        public void UserEdit(string clientId, string textBoxFirstName, string textBoxSecondName, string comboBoxGender,
            string dateTimePicker, string textBoxPhone)
        {
            try
            {
                string commPart =
                    "UPDATE \"hotel\".\"Client\"" +
                    " SET FirstName = @textBoxFirstName," +
                    " SecondName = @textBoxSecondName," +
                    " Gender = @comboBoxGender," +
                    " DateOfBirth = @dateTimePicker::timestamp with time zone ," +
                    " Phone = @textBoxPhone" +
                    " WHERE Client_Id = @client_Id ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxFirstName", textBoxFirstName);
                command.Parameters.AddWithValue("@textBoxSecondName", textBoxSecondName);
                command.Parameters.AddWithValue("@comboBoxGender", comboBoxGender);
                command.Parameters.AddWithValue("@dateTimePicker", dateTimePicker);
                command.Parameters.AddWithValue("@textBoxPhone", textBoxPhone);
                if (textBoxPhone.Length == 0)
                {
                    textBoxPhone = @"";
                }
                command.Parameters.AddWithValue("@Phone", textBoxPhone);
                command.Parameters.AddWithValue("@client_Id", clientId);

                command.ExecuteNonQuery();
                MessageBox.Show(@"Данные успешно измененны");
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public void UserEditPass(string loginId, string newPass)
        {
            try
            {
                string commPart =
                    "UPDATE \"login\".\"UserPass\"" +
                    " SET Pass = @newPass" +
                    " WHERE Login_ID = @loginId ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@newPass", Protection.EncryptMD5(newPass));
                command.Parameters.AddWithValue("@loginId", Protection.DESEncrypt(loginId));

                command.ExecuteNonQuery();
                MessageBox.Show(@"Данные успешно измененны");
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        #endregion
    }
}