using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.Common;
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.DAL
{
    public class RepositoryStaff
    {
        #region Global Values

        private SqlConnect sqlConnect;

        #endregion

        public RepositoryStaff(SqlConnect _sqlConnect)
        {
            sqlConnect = _sqlConnect;
        }

        #region TableSelect

        public List<TableStaff> GetSingleTable()
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            try
            {
                string commPart =
                    "SELECT *" +
                    " FROM \"hotel\".\"Staff\"" +
                    " ORDER BY Staff_ID" +
                    " ;";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        Convert.ToDateTime(dbDataRecord["DateOfBirth"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["SVacantKey"].ToString(),
                        dbDataRecord["Supervisor"].ToString(),
                        dbDataRecord["RegBuilding"].ToString());
                    tableStaffList.Add(tableStaff);
                }
                readerTable.Close();
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            return tableStaffList;
        }

        public List<TableStaff> GetSingleTableWithPosition()
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            try
            {
                string commPart =
                    "SELECT s.Staff_Id, s.FirstName, s.SecondName, s.Gender, s.DateOfBirth, sv.SVacant, s.Supervisor, h.HotelName" +
                    " FROM \"hotel\".\"Staff\" s, \"hotel\".\"StaffPosition\" sv, \"hotel\".\"Hotel\" h" +
                    " WHERE s.SVacantKey = sv.SVacantKey" +
                    "  AND s.RegBuilding = h.Hotel_Id" +
                    " ORDER BY s.Staff_Id" +
                    ";";

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);
                NpgsqlDataReader readerTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        Convert.ToDateTime(dbDataRecord["DateOfBirth"]).ToString("dd/MM/yyyy"),
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Supervisor"].ToString(),
                        dbDataRecord["HotelName"].ToString());
                    tableStaffList.Add(tableStaff);
                }
                readerTable.Close();
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            return tableStaffList;
        }

        #endregion

        #region TableUpdate

        public void EditStaff(string textBoxStaffId, string textBoxStaffName, string textBoxStaffSirName,
            string comboBoxStaffGender, string staffBirth, string comboBoxSvacant,
            string comboBoxLeader, string comboBoxStaffHotel)
        {
            if (comboBoxLeader != string.Empty)
            {
                try
                {
                    string commPart =
                        "SELECT * FROM \"hotel\".edit_staff_func_withSuper(" +
                        " @textBoxStaffId, @textBoxStaffName, @textBoxStaffSirName, @comboBoxStaffGender," +
                        " @staffBirth::date, @comboBoxSvacant, @comboBoxLeader, @comboBoxStaffHotel" +
                        " );";
                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@textBoxStaffId", Convert.ToInt32(textBoxStaffId));
                    command.Parameters.AddWithValue("@textBoxStaffName", textBoxStaffName);
                    command.Parameters.AddWithValue("@textBoxStaffSirName", textBoxStaffSirName);
                    command.Parameters.AddWithValue("@comboBoxStaffGender", comboBoxStaffGender);
                    command.Parameters.AddWithValue("@staffBirth", Convert.ToDateTime(staffBirth));
                    command.Parameters.AddWithValue("@comboBoxSvacant", comboBoxSvacant);
                    command.Parameters.AddWithValue("@comboBoxLeader", Convert.ToInt32(comboBoxLeader));
                    command.Parameters.AddWithValue("@comboBoxStaffHotel", comboBoxStaffHotel);

                    NpgsqlDataReader readerTable = command.ExecuteReader();
                    readerTable.Close();

                    MessageBox.Show(@"Данные успешно измененны");
                }
                catch
                (Npgsql.PostgresException exp)
                {
                    // MessageBox.Show("Не удалось выполнить запрос!");
                    MessageBox.Show(Convert.ToString(exp));
                }
            }
            else
            {
                try
                {
                    string commPart =
                        "SELECT * FROM \"hotel\".edit_staff_func_withOutSuper(" +
                        " @textBoxStaffId, @textBoxStaffName, @textBoxStaffSirName, @comboBoxStaffGender," +
                        " @staffBirth::date, @comboBoxSvacant, @comboBoxStaffHotel" +
                        " );";
                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@textBoxStaffId", Convert.ToInt32(textBoxStaffId));
                    command.Parameters.AddWithValue("@textBoxStaffName", textBoxStaffName);
                    command.Parameters.AddWithValue("@textBoxStaffSirName", textBoxStaffSirName);
                    command.Parameters.AddWithValue("@comboBoxStaffGender", comboBoxStaffGender);
                    command.Parameters.AddWithValue("@staffBirth", Convert.ToDateTime(staffBirth));
                    command.Parameters.AddWithValue("@comboBoxSvacant", comboBoxSvacant);
                    command.Parameters.AddWithValue("@comboBoxStaffHotel", comboBoxStaffHotel);

                    NpgsqlDataReader readerTable = command.ExecuteReader();
                    readerTable.Close();

                    MessageBox.Show(@"Данные успешно измененны");
                }
                catch
                    (Npgsql.PostgresException exp)
                {
                    // MessageBox.Show("Не удалось выполнить запрос!");
                    MessageBox.Show(Convert.ToString(exp));
                }
            }
        }

        #endregion

        #region TableInsert

        public void AddStaff(string textBoxStaffId, string textBoxStaffName, string textBoxStaffSirName,
    string comboBoxStaffGender, string staffBirth, string comboBoxSvacant,
    string comboBoxLeader, string comboBoxStaffHotel)
        {
            if (comboBoxLeader != string.Empty)
            {
                try
                {
                    string commPart =
                        "SELECT * FROM \"hotel\".add_staff_func_withSuper(" +
                        " @textBoxStaffName, @textBoxStaffSirName, @comboBoxStaffGender," +
                        " @staffBirth::date, @comboBoxSvacant, @comboBoxLeader, @comboBoxStaffHotel" +
                        " );";
                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@textBoxStaffName", textBoxStaffName);
                    command.Parameters.AddWithValue("@textBoxStaffSirName", textBoxStaffSirName);
                    command.Parameters.AddWithValue("@comboBoxStaffGender", comboBoxStaffGender);
                    command.Parameters.AddWithValue("@staffBirth", Convert.ToDateTime(staffBirth));
                    command.Parameters.AddWithValue("@comboBoxSvacant", comboBoxSvacant);
                    command.Parameters.AddWithValue("@comboBoxLeader", Convert.ToInt32(comboBoxLeader));
                    command.Parameters.AddWithValue("@comboBoxStaffHotel", comboBoxStaffHotel);

                    NpgsqlDataReader readerTable = command.ExecuteReader();
                    readerTable.Close();

                    MessageBox.Show(@"Данные успешно измененны");
                }
                catch
                    (Npgsql.PostgresException
                        exp)
                {
                    // MessageBox.Show("Не удалось выполнить запрос!");
                    MessageBox.Show(Convert.ToString(exp));
                }
            }
            else
            {
                try
                {
                    string commPart =
                        "SELECT * FROM \"hotel\".add_staff_func_withOutSuper(" +
                        " @textBoxStaffName, @textBoxStaffSirName, @comboBoxStaffGender," +
                        " @staffBirth::date, @comboBoxSvacant, @comboBoxStaffHotel" +
                        " );";
                    NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                    command.Parameters.AddWithValue("@textBoxStaffName", textBoxStaffName);
                    command.Parameters.AddWithValue("@textBoxStaffSirName", textBoxStaffSirName);
                    command.Parameters.AddWithValue("@comboBoxStaffGender", comboBoxStaffGender);
                    command.Parameters.AddWithValue("@staffBirth", Convert.ToDateTime(staffBirth));
                    command.Parameters.AddWithValue("@comboBoxSvacant", comboBoxSvacant);
                    command.Parameters.AddWithValue("@comboBoxStaffHotel", comboBoxStaffHotel);

                    NpgsqlDataReader readerTable = command.ExecuteReader();
                    readerTable.Close();

                    MessageBox.Show(@"Данные успешно измененны");
                }
                catch
                    (Npgsql.PostgresException
                        exp)
                {
                    // MessageBox.Show("Не удалось выполнить запрос!");
                    MessageBox.Show(Convert.ToString(exp));
                }
            }
        }

        #endregion

        #region TableDelete

        public void DeleteStaff(string textBoxNum)
        {
            try
            {
                string commPart =
                    "DELETE FROM \"hotel\".\"Staff\"" +
                    " WHERE staff_id = @textBoxNum ;";
                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetNewSqlConn().GetConn);

                command.Parameters.AddWithValue("@textBoxNum", Convert.ToInt32(textBoxNum));
                command.ExecuteNonQuery();

                MessageBox.Show(@"Успешно удалено!");
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