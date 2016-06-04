using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryHotel
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryHotel(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableHotel> GetSingleTable()
        {
            TableHotel tableHotel;
            var tableHotelList = new List<TableHotel>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Hotel\"" +
                    " ORDER BY Hotel_ID;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableHotel = new TableHotel(
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["OrgName"].ToString(),
                        dbDataRecord["HotelName"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["Phone"].ToString(),
                        dbDataRecord["Class"].ToString(),
                        dbDataRecord["Hotel_Link"].ToString());
                    tableHotelList.Add(tableHotel);
                }
                readerTable.Close();
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            return tableHotelList;
        }

        #endregion

        #region TableUpdate

        public void EditHotel(string textBoxHotelNum, string textBoxHotelName, string textBoxHotelOrg,
                    string textBoxHotelC, string textBoxHotelS, string textBoxHotelPhone, string textBoxHotelClass, string textBoxHotelWeb)
        {
            try
            {
                string commPart =
                    "UPDATE \"hotel\".\"Hotel\"" +
                    " SET HotelName = @textBoxHotelName," +
                    " OrgName = @textBoxHotelOrg," +
                    " City = @textBoxHotelC," +
                    " Street = @textBoxHotelS," +
                    " Phone = @textBoxHotelPhone," +
                    " Class = @textBoxHotelClass," +
                    " Hotel_Link = @textBoxHotelWeb" +
                    " WHERE Hotel_ID = @textBoxHotelNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxHotelName", textBoxHotelName);
                command.Parameters.AddWithValue("@textBoxHotelOrg", textBoxHotelOrg);
                command.Parameters.AddWithValue("@textBoxHotelC", textBoxHotelC);
                command.Parameters.AddWithValue("@textBoxHotelS", textBoxHotelS);
                if (textBoxHotelPhone.Length == 0)
                {
                    textBoxHotelPhone = @"";
                }
                command.Parameters.AddWithValue("@textBoxHotelPhone", textBoxHotelPhone);
                command.Parameters.AddWithValue("@textBoxHotelClass", Convert.ToInt32(textBoxHotelClass));
                command.Parameters.AddWithValue("@textBoxHotelWeb", textBoxHotelWeb);
                command.Parameters.AddWithValue("@textBoxHotelNum", Convert.ToInt32(textBoxHotelNum));

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