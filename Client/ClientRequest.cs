using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using ClassRequest;
using Npgsql;

namespace Client
{
    public class ClientRequest
    {
        #region Global Values

        #endregion

        // получение паспорта клиента
        public string GetId(ReposFactory reposFactory, string loginId)
        {
            foreach (var v in reposFactory.GetClient().GetSingleTable())
            {
                if (v.LoginId == loginId)
                    return (v.ClientId);
            }
            return @"ERROR";
        }

        // вывод списка свободных номеров
        public void NumOutput(ReposFactory reposFactory, DataGridView dgvNum, DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut)
        {
            dgvNum.Rows.Clear();
            try
            {
                int colorKey = 0;

                string filterDateIn = Convert.ToString(dtpCheckIn.Value);
                string filterDateOut = Convert.ToString(dtpCheckOut.Value);
                foreach (var v in reposFactory.GetApartmentAClass().GetNumList(filterDateIn, filterDateOut))
                {
                    dgvNum.Rows.Add(v.ApId, v.PlaceQuantity, v.ClassId, v.ClassCost);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvNum.ColumnCount; ++i)
                            dgvNum.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }


        public void LogOutput(ReposFactory reposFactory, DataGridView dgvLog, string loginId)
        {
            dgvLog.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetUserApartmentCardCost().GetSingleLogList(loginId))
                {
                    var costValue = Convert.ToDouble(v.ClassCost);
                    var dateDiff = (Convert.ToDateTime(v.CheckOutDate) - Convert.ToDateTime(v.CheckInDate)).TotalDays;
                    costValue = Math.Round(costValue*Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);

                    dgvLog.Rows.Add(v.ApId, v.CheckInDate, v.CheckOutDate, costValue);

                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvLog.ColumnCount; ++i)
                            dgvLog.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public void NowOutput(ReposFactory reposFactory, DataGridView dgvNow, string loginId)
        {
            dgvNow.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetUserApartmentCardCost().GetSingleNewList(loginId))
                {
                    var costValue = Convert.ToDouble(v.ClassCost);
                    var dateDiff = (Convert.ToDateTime(v.CheckOutDate) - Convert.ToDateTime(v.CheckInDate)).TotalDays;
                    costValue = Math.Round(costValue*Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);

                    dgvNow.Rows.Add(v.ApId, v.CheckInDate, v.CheckOutDate, costValue);

                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvNow.ColumnCount; ++i)
                            dgvNow.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public void RequestDelete(ReposFactory reposFactory, string loginId, string apId, string checkInDate)
        {
            try
            {
                reposFactory.GetACard().RequestDeleteSql(loginId, checkInDate);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось удалить бронь!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // запрос списка свободных комнат
        public void UpdateComboBoxApId(ReposFactory reposFactory, ComboBox comboBox, DateTimePicker dtpIn, DateTimePicker dtpOut)
        {
            comboBox.Text = @"";
            comboBox.Items.Clear();
            try
            {
                // фильтр даты
                //var dateMinusDay = dtpIn.Value.AddDays(-1);
                string filterDateIn = Convert.ToString(dtpIn.Value);
                string filterDateOut = Convert.ToString(dtpOut.Value);
                foreach (var v in reposFactory.GetApartmentAClass().GetNumList(filterDateIn, filterDateOut))
                {
                    comboBox.Items.Add(v.ApId);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // добавление брони
        public void RequestAdd(ReposFactory reposFactory, string loginId, string apId,
            DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut, RichTextBox textBoxComm)
        {
            try
            {
                foreach (var v in reposFactory.GetClient().GetSingleTable())
                {
                    if (v.ClientId == loginId)
                    {
                        string newPass = @"12345";

                        int key = 1100;
                        foreach (var w in reposFactory.GetLogin().GetSingleTable())
                        {
                            key++;
                        }
                        string newLogIn = @"user-" + Convert.ToString(key);

                        double costValue = 0;

                        foreach (var w in reposFactory.GetApartmentAClass().UpdateStatAdd())
                        {
                            if (w.ApId == apId)
                            {
                                costValue = Convert.ToDouble(w.ClassCost);
                            }
                        }

                        var dateDiff = (dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
                        dateDiff = Math.Round(Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                        costValue = Math.Round(costValue * Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                        
                        reposFactory.GetACard().AddUser(loginId, v.FirstName, v.SecondName,
                            v.Gender, v.DateOfBirth, v.Phone,
                            apId, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text, costValue,
                            newLogIn, newPass);
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось добавить клиента!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public void SelectStatInfo(ReposFactory reposFactory, string comboBoxApId, DateTimePicker dtpCheckIn,
            DateTimePicker dtpCheckOut, Label labelRoomQ, Label labelRoomT, Label labelRoomC)
        {
            try
            {
                double costValue = 0;
                foreach (var v in reposFactory.GetApartmentAClass().UpdateStatAdd())
                {
                    if (v.ApId == comboBoxApId)
                    {
                        labelRoomQ.Text = v.PlaceQuantity;
                        costValue = Convert.ToDouble(v.ClassCost);
                    }
                }

                var dateDiff = (dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
                dateDiff = Math.Round(Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                labelRoomT.Text = Convert.ToString(dateDiff, CultureInfo.CurrentCulture);
                if (dateDiff > 0)
                {
                    costValue = Math.Round(costValue*Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                    labelRoomC.Text = Convert.ToString(costValue);
                }
                else
                {
                    labelRoomC.Text = @"Так не сработает";
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось добавить клиента!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        #region editForm

        public void InputAllClientFields(ReposFactory reposFactory, string textBoxPass, TextBox textBoxFirstName,
            TextBox textBoxSecondName, ComboBox comboBoxGender, DateTimePicker dateTimePicker, MaskedTextBox textBoxPhone)
        {
            foreach (var v in reposFactory.GetClient().GetSingleTable())
            {
                if (v.ClientId == textBoxPass)
                {
                    textBoxFirstName.Text = v.FirstName;
                    textBoxSecondName.Text = v.SecondName;
                    comboBoxGender.Text = v.Gender;
                    dateTimePicker.Text = v.DateOfBirth;
                    textBoxPhone.Text = v.Phone;
                }
            }
        }

        // редактирование клента из таблицы
        public void UserEdit(ReposFactory reposFactory, string clientId, TextBox textBoxFirstName,
            TextBox textBoxSecondName, ComboBox comboBoxGender, DateTimePicker dateTimePicker, MaskedTextBox textBoxPhone)
        {
            try
            {

                reposFactory.GetClient().UserEdit(clientId, textBoxFirstName.Text, textBoxSecondName.Text, comboBoxGender.Text,
                    dateTimePicker.Text, textBoxPhone.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
        public void UserEditPass(ReposFactory reposFactory, string loginId, TextBox textBoxNewPass)
        {
            try
            {
                reposFactory.GetClient().UserEditPass(loginId, textBoxNewPass.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        #endregion

        #region other

        public void InputHotelName(ReposFactory reposFactory, LinkLabel lLabelHotelName, Label labelHotelPhone)
        {
            int currentHotel = 1;
            foreach (var v in reposFactory.GetHotel().GetSingleTable())
            {
                if (Convert.ToInt32(v.HotelId) == currentHotel)
                {
                    lLabelHotelName.Text = v.OrgName;
                    labelHotelPhone.Text = v.Phone;
                }
            }
        }

        public void OpenLink(ReposFactory reposFactory, LinkLabel lLabelHotelName)
        {
            foreach (var v in reposFactory.GetHotel().GetSingleTable())
            {
                if (v.OrgName == lLabelHotelName.Text)
                    Process.Start(v.HotelLink);
            }
        }

        public void InputGroupBoxName(ReposFactory reposFactory, string textBoxPass, GroupBox groupBoxUserInfo)
        {
            foreach (var v in reposFactory.GetClient().GetSingleTable())
            {
                if (v.ClientId == textBoxPass)
                {
                    groupBoxUserInfo.Text = v.FirstName + " " + v.SecondName;
                }
            }
        }

        #endregion
    }
}
