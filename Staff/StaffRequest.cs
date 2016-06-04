using System;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using ClassRequest;
using Npgsql;

namespace Staff
{
    public class StaffRequest
    {
        #region Global Values

        #endregion

        // вывод списка посетителей
        public void UserOutput(ReposFactory reposFactory, DataGridView dgvUser, DateTimePicker dateTpUser)
        {
            dgvUser.Rows.Clear();
            try
            {
                // фильтр даты
                string filterDate = Convert.ToString(dateTpUser.Value);
                int colorKey = 0;
                foreach (var v in reposFactory.GetUserApartmentCard().GetUserList(filterDate))
                {
                    dgvUser.Rows.Add(v.FirstName, v.SecondName, v.Gender, v.ApId,
                        v.CheckInDate, v.CheckOutDate, v.ClientId);

                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvUser.ColumnCount; ++i)
                            dgvUser.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
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

        // вывод списка свободных номеров
        public void NumOutput(ReposFactory reposFactory, DataGridView dgvNum, DateTimePicker dateTpNum)
        {
            dgvNum.Rows.Clear();
            try
            {
                // фильтр даты
                //var dateMinusDay = dateTpNum.Value.AddDays(-1);
                string filterDate = Convert.ToString(dateTpNum.Value);
                int colorKey = 0;
                foreach (var v in reposFactory.GetApartmentAClass().GetNumList(filterDate))
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

        public void NumOutputFull(ReposFactory reposFactory, DataGridView dgvNum)
        {
            dgvNum.Rows.Clear();
            try
            {
                // фильтр даты
                //var dateMinusDay = dateTpNum.Value.AddDays(-1);
                int colorKey = 0;
                foreach (var v in reposFactory.GetApartmentAClass().GetNumListFull())
                {
                    dgvNum.Rows.Add(v.ApId, v.HotelId, v.PlaceQuantity, v.ClassId);
                    if (colorKey % 2 == 0)
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

        // вывод списка отелей
        public void HotelOutput(ReposFactory reposFactory, DataGridView dgvHotel)
        {
            dgvHotel.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetHotel().GetSingleTable())
                {
                    dgvHotel.Rows.Add(v.HotelId, v.OrgName, v.HotelName, v.City, v.Street, v.Phone, v.HotelClass, v.HotelLink);
                    if (colorKey % 2 == 0)
                    {
                        for (int i = 0; i < dgvHotel.ColumnCount; ++i)
                            dgvHotel.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
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

        // запрос зареганых клиентов
        public void GetUserIdList(ReposFactory reposFactory, TextBox textBoxPass)
        {
            AutoCompleteStringCollection acsCollection = new AutoCompleteStringCollection();

            string[] str = new string[reposFactory.GetClient().GetSingleTable().Count];
            int i = 0;
            foreach (var v in reposFactory.GetClient().GetSingleTable())
            {
                str[i] = v.ClientId;
                ++i;
            }
            acsCollection.AddRange(str);

            textBoxPass.AutoCompleteCustomSource = acsCollection;
            textBoxPass.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBoxPass.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        // запрос на все поля клиента если он уже есть в базе
        public void InputAllClientFields(ReposFactory reposFactory, string textBoxPass, TextBox textBoxFirstName,
            TextBox textBoxSecondName,
            ComboBox comboBoxGender, DateTimePicker dateTimePicker, MaskedTextBox textBoxPhone)
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

        // вывод информации, если изменяются поля комнаты
        public void SelectStatInfo(ReposFactory reposFactory, ComboBox comboBoxApId, DateTimePicker dtpCheckIn,
            DateTimePicker dtpCheckOut,
            Label labelRoomN, Label labelRoomQ, Label labelRoomT, Label labelRoomC)
        {
            double costValue = 0;
            labelRoomN.Text = comboBoxApId.Text;
            foreach (var v in reposFactory.GetApartmentAClass().UpdateStatAdd())
            {
                if (v.ApId == comboBoxApId.Text)
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
                costValue = Math.Round(costValue * Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                labelRoomC.Text = Convert.ToString(costValue);
            }
            else
            {
                labelRoomC.Text = @"Так не сработает";
            }
        }

        // псевдоудаление клента из таблицы
        public void FakedUserDelete(ReposFactory reposFactory, string clientId, string checkInDate)
        {
            try
            {
                // фильтр даты
                //string filterDate = Convert.ToString(DateTime.Now);
                reposFactory.GetACard().FakeUserDeleteSql(clientId, checkInDate);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось удалить клиента!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // добавление клиента
        public void AddUser(ReposFactory reposFactory, TextBox textBoxPass, TextBox textBoxFirstName,
            TextBox textBoxSecondName,
            ComboBox comboBoxGender, DateTimePicker dtpBirth, MaskedTextBox textBoxPhone, ComboBox comboBoxApId,
            DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut, RichTextBox textBoxComm)
        {
            try
            {
                string newLogIn;
                string newPass = @"12345";

                int key = 1100;
                foreach (var v in reposFactory.GetLogin().GetSingleTable())
                {
                    key++;
                }
                newLogIn = @"user-" + Convert.ToString(key);

                reposFactory.GetACard().AddUser(textBoxPass.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text,
                    dtpBirth.Text, textBoxPhone.Text,
                    comboBoxApId.Text, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text,
                    newLogIn, newPass);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось добавить клиента!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                textBoxPass.Clear();
                textBoxFirstName.Clear();
                textBoxSecondName.Clear();
                comboBoxGender.Text = string.Empty;
                textBoxPhone.Clear();
                comboBoxApId.SelectedIndex = 0;
                comboBoxApId.Items.Clear();
                comboBoxApId.Text = string.Empty;
                textBoxComm.Clear();
            }
        }
        // записываем выбранный отель в TextBox-сы
        public void EnterThirdBox(ReposFactory reposFactory, TextBox textBoxHotelNum, TextBox textBoxHotelName, TextBox textBoxHotelOrg,
            TextBox textBoxHotelC, TextBox textBoxHotelS, MaskedTextBox textBoxHotelPhone, TextBox textBoxHotelClass,
            TextBox textBoxHotelWeb, DataGridView dgvHotel, int dgvIndex, GroupBox groupBox, Label labelAll, Label labelNew)
        {
            //textBoxHotelNum, textBoxHotelName, textBoxHotelOrg, textBoxHotelC,
            //textBoxHotelS, textBoxHotelPhone, textBoxHotelWeb

            int tickAll = 0;
            int tickNew = 0;
            foreach (var v in reposFactory.GetHotelACardApartment().GetSingleTable())
            {
                if (v.HotelId == dgvHotel.Rows[dgvIndex].Cells[0].Value.ToString())
                {
                    tickAll++;
                    if (Convert.ToDateTime(v.CheckInDate) <= DateTime.Today &
                        Convert.ToDateTime(v.CheckOutDate) >= DateTime.Today)
                    {
                        tickNew++;
                    }
                }
            }

            groupBox.Text = @"Статистика " + dgvHotel.Rows[dgvIndex].Cells[2].Value.ToString();
            labelAll.Text = Convert.ToString(tickAll);
            labelNew.Text = Convert.ToString(tickNew);

            textBoxHotelNum.Text = dgvHotel.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxHotelOrg.Text = dgvHotel.Rows[dgvIndex].Cells[1].Value.ToString();
            textBoxHotelName.Text = dgvHotel.Rows[dgvIndex].Cells[2].Value.ToString();
            textBoxHotelC.Text = dgvHotel.Rows[dgvIndex].Cells[3].Value.ToString();
            textBoxHotelS.Text = dgvHotel.Rows[dgvIndex].Cells[4].Value.ToString();
            textBoxHotelPhone.Text = dgvHotel.Rows[dgvIndex].Cells[5].Value.ToString();
            textBoxHotelClass.Text = dgvHotel.Rows[dgvIndex].Cells[6].Value.ToString();
            textBoxHotelWeb.Text = dgvHotel.Rows[dgvIndex].Cells[7].Value.ToString();
        }
    }
}
