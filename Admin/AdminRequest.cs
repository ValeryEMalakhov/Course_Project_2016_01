using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using Admin.Sided_Form;
using Npgsql;
using ClassRequest;

namespace Admin
{
    public class AdminRequest
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
                        v.CheckInDate, v.CheckOutDate, v.ClientId, v.MToPay);

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
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void UserOutputFull(ReposFactory reposFactory, DataGridView dgvUser)
        {
            dgvUser.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetUserApartmentCard().GetUserListFull())
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
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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
                    dgvNum.Rows.Add(v.ApId, v.HotelId, v.PlaceQuantity, v.ClassId);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvNum.ColumnCount; ++i)
                            dgvNum.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvNum.ColumnCount; ++i)
                            dgvNum.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // вывод списка классов
        public void NumCostOutput(ReposFactory reposFactory, DataGridView dgvNumCost)
        {
            dgvNumCost.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetAClass().GetSingleTable())
                {
                    dgvNumCost.Rows.Add(v.ClassId, v.ClassCost);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvNumCost.ColumnCount; ++i)
                            dgvNumCost.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }
        // вывод списка гостей
        public void ClientAllOutput(ReposFactory reposFactory, DataGridView dgvClientAll)
        {
            dgvClientAll.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetClient().GetSingleTable())
                {
                    dgvClientAll.Rows.Add(v.FirstName, v.SecondName, v.Gender, v.DateOfBirth,
                        v.Phone, v.ClientId);

                    if (colorKey % 2 == 0)
                    {
                        for (int i = 0; i < dgvClientAll.ColumnCount; ++i)
                            dgvClientAll.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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
                    dgvHotel.Rows.Add(v.HotelId, v.OrgName, v.HotelName, v.City, v.Street, v.Phone, v.HotelClass,
                        v.HotelLink);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvHotel.ColumnCount; ++i)
                            dgvHotel.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // вывод списка сотрудников
        public void StaffOutput(ReposFactory reposFactory, DataGridView dgvStaff)
        {
            dgvStaff.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetStaff().GetSingleTableWithPosition())
                {
                    dgvStaff.Rows.Add(v.StaffId, v.FirstName, v.SecondName, v.Gender, v.DateOfBirth,
                        v.SVacantKey, v.Supervisor, v.RegBuilding);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvStaff.ColumnCount; ++i)
                            dgvStaff.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // вывод списка сотрудников
        public void StaffPositionOutput(ReposFactory reposFactory, DataGridView dgvStaffPosition)
        {
            dgvStaffPosition.Rows.Clear();
            try
            {
                int colorKey = 0;
                foreach (var v in reposFactory.GetStaffPosition().GetSingleTable())
                {
                    dgvStaffPosition.Rows.Add(v.SvacantKey, v.SVacant, v.Salary);
                    if (colorKey%2 == 0)
                    {
                        for (int i = 0; i < dgvStaffPosition.ColumnCount; ++i)
                            dgvStaffPosition.Rows[colorKey].Cells[i].Style.BackColor = Color.Lavender;
                    }
                    colorKey++;
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // записываем выбранный номер в TextBox-сы
        public void EnterFirstBox(TextBox textBoxNum, TextBox textBoxNumHotel, TextBox textBoxPlace,
            TextBox textBoxNumClass,
            DataGridView dgvNum, int dgvIndex)
        {
            textBoxNum.Text = dgvNum.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxNumHotel.Text = dgvNum.Rows[dgvIndex].Cells[1].Value.ToString();
            textBoxPlace.Text = dgvNum.Rows[dgvIndex].Cells[2].Value.ToString();
            textBoxNumClass.Text = dgvNum.Rows[dgvIndex].Cells[3].Value.ToString();
        }

        // записываем выбранный класс в TextBox-сы
        public void EnterSecondBox(TextBox textBoxClass, TextBox textBoxClassCost, DataGridView dgvNumClass,
            int dgvIndex)
        {
            textBoxClass.Text = dgvNumClass.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxClassCost.Text = dgvNumClass.Rows[dgvIndex].Cells[1].Value.ToString();
        }

        // записываем выбранный отель в TextBox-сы
        public void EnterThirdBox(ReposFactory reposFactory, TextBox textBoxHotelNum, TextBox textBoxHotelName,
            TextBox textBoxHotelOrg,
            TextBox textBoxHotelC, TextBox textBoxHotelS, MaskedTextBox maskedTextBoxHotelPhone,
            TextBox textBoxHotelClass,
            TextBox textBoxHotelWeb, DataGridView dgvHotel, int dgvIndex, GroupBox groupBox, Label labelAll,
            Label labelNew)
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
            maskedTextBoxHotelPhone.Text = dgvHotel.Rows[dgvIndex].Cells[5].Value.ToString();
            textBoxHotelClass.Text = dgvHotel.Rows[dgvIndex].Cells[6].Value.ToString();
            textBoxHotelWeb.Text = dgvHotel.Rows[dgvIndex].Cells[7].Value.ToString();
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
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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
                costValue = Math.Round(costValue*Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
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
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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
                string newPass = @"12345";

                int key = 1100;
                foreach (var v in reposFactory.GetLogin().GetSingleTable())
                {
                    key++;
                }
                string newLogIn = @"user-" + Convert.ToString(key);

                double costValue = 0;

                foreach (var w in reposFactory.GetApartmentAClass().UpdateStatAdd())
                {
                    if (w.ApId == comboBoxApId.Text)
                    {
                        costValue = Convert.ToDouble(w.ClassCost);
                    }
                }

                var dateDiff = (dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
                dateDiff = Math.Round(Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                costValue = Math.Round(costValue * Convert.ToDouble(dateDiff), 2, MidpointRounding.AwayFromZero);
                
                reposFactory.GetACard().AddUser(textBoxPass.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text,
                    dtpBirth.Value.ToString("dd/MM/yyyy"), textBoxPhone.Text,
                    comboBoxApId.Text, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text, costValue,
                    newLogIn, newPass);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось добавить клиента!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
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

        public void EditSecondBox(ReposFactory reposFactory, TextBox textBoxClass, TextBox textBoxClassCost)
        {
            try
            {
                textBoxClassCost.Text = textBoxClassCost.Text.Replace('.', ',');
                reposFactory.GetAClass().EditClassCost(textBoxClass.Text, textBoxClassCost.Text);

                textBoxClass.Text = string.Empty;
                textBoxClass.Enabled = true;
                textBoxClassCost.Text = string.Empty;
                textBoxClassCost.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void AddFirstBox(ReposFactory reposFactory, TextBox textBoxNum, TextBox textBoxNumHotel,
            TextBox textBoxPlace, TextBox textBoxNumClass)
        {
            try
            {
                bool key = false;
                foreach (var v in reposFactory.GetHotel().GetSingleTable())
                {
                    if (v.HotelId == textBoxNumHotel.Text)
                        key = true;

                }
                if (key)
                {
                    reposFactory.GetApartment().AddApartment(textBoxNum.Text, textBoxNumHotel.Text, textBoxPlace.Text,
                        textBoxNumClass.Text);

                    textBoxNum.Text = string.Empty;
                    textBoxNum.Enabled = true;
                    textBoxNumHotel.Text = string.Empty;
                    textBoxNumHotel.Enabled = true;
                    textBoxPlace.Text = string.Empty;
                    textBoxPlace.Enabled = true;
                    textBoxNumClass.Text = string.Empty;
                    textBoxNumClass.Enabled = true;
                }
                else
                {
                    MessageBox.Show(@"Отель в базе не найден");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void EditFirstBox(ReposFactory reposFactory, TextBox textBoxNum, TextBox textBoxNumHotel,
            TextBox textBoxPlace, TextBox textBoxNumClass)
        {
            try
            {
                bool key = false;
                foreach (var v in reposFactory.GetHotel().GetSingleTable())
                {
                    if (v.HotelId == textBoxNumHotel.Text)
                        key = true;

                }
                if (key)
                {
                    reposFactory.GetApartment().EditApartment(textBoxNum.Text, textBoxNumHotel.Text, textBoxPlace.Text,
                        textBoxNumClass.Text);

                    textBoxNum.Text = string.Empty;
                    textBoxNum.Enabled = true;
                    textBoxNumHotel.Text = string.Empty;
                    textBoxNumHotel.Enabled = true;
                    textBoxPlace.Text = string.Empty;
                    textBoxPlace.Enabled = true;
                    textBoxNumClass.Text = string.Empty;
                    textBoxNumClass.Enabled = true;
                }
                else
                {
                    MessageBox.Show(@"Отель в базе не найден");
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void DeleteFirstBox(ReposFactory reposFactory, TextBox textBoxNum, TextBox textBoxNumHotel,
            TextBox textBoxPlace,
            TextBox textBoxNumClass)
        {
            try
            {
                bool keyAll = false;
                bool keyNew = false;

                foreach (var v in reposFactory.GetACard().GetSingleTable())
                {
                    if (v.ApId == textBoxNum.Text)
                    {
                        keyAll = true;
                        if (Convert.ToDateTime(v.CheckInDate) >= DateTime.Today ||
                            Convert.ToDateTime(v.CheckOutDate) >= DateTime.Today)
                        {
                            keyNew = true;
                        }
                    }
                }
                if (keyAll)
                {
                    DeleteNumForm deleteNumForm = new DeleteNumForm(reposFactory, keyNew,
                        textBoxNum, textBoxNumHotel, textBoxPlace, textBoxNumClass);
                    deleteNumForm.ShowDialog();
                }
                else
                {
                    reposFactory.GetApartment().DeleteApartment(textBoxNum.Text);

                    textBoxNum.Text = string.Empty;
                    textBoxNum.Enabled = true;
                    textBoxNumHotel.Text = string.Empty;
                    textBoxNumHotel.Enabled = true;
                    textBoxPlace.Text = string.Empty;
                    textBoxPlace.Enabled = true;
                    textBoxNumClass.Text = string.Empty;
                    textBoxNumClass.Enabled = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void DeleteFirstBoxFromForm(ReposFactory reposFactory, TextBox textBoxNum)
        {
            try
            {
                reposFactory.GetACard().RequestDeleteSqlForApartment(textBoxNum.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void EditThirdBox(ReposFactory reposFactory, TextBox textBoxHotelNum, TextBox textBoxHotelName,
            TextBox textBoxHotelOrg, TextBox textBoxHotelC,
            TextBox textBoxHotelS, MaskedTextBox maskedTextBoxHotelPhone, TextBox textBoxHotelClass,
            TextBox textBoxHotelWeb)
        {
            try
            {
                reposFactory.GetHotel().EditHotel(textBoxHotelNum.Text, textBoxHotelName.Text, textBoxHotelOrg.Text,
                    textBoxHotelC.Text, textBoxHotelS.Text, maskedTextBoxHotelPhone.Text, textBoxHotelClass.Text,
                    textBoxHotelWeb.Text);

                textBoxHotelNum.Text = string.Empty;
                textBoxHotelName.Text = string.Empty;
                textBoxHotelName.Enabled = true;
                textBoxHotelOrg.Text = string.Empty;
                textBoxHotelOrg.Enabled = true;
                textBoxHotelC.Text = string.Empty;
                textBoxHotelC.Enabled = true;
                textBoxHotelS.Text = string.Empty;
                textBoxHotelS.Enabled = true;
                maskedTextBoxHotelPhone.Text = string.Empty;
                maskedTextBoxHotelPhone.Enabled = true;
                textBoxHotelClass.Text = string.Empty;
                textBoxHotelClass.Enabled = true;
                textBoxHotelWeb.Text = string.Empty;
                textBoxHotelWeb.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // для сотрудников
        // запрос списка свободных комнат
        public void UpdateComboBoxes(ReposFactory reposFactory, ComboBox comboBoxSvacant, ComboBox comboBoxLeader,
            ComboBox comboBoxStaffHotel)
        {
            comboBoxSvacant.Items.Clear();
            comboBoxLeader.Items.Clear();
            comboBoxStaffHotel.Items.Clear();
            try
            {
                foreach (var v in reposFactory.GetStaffPosition().GetSingleTable())
                {
                    comboBoxSvacant.Items.Add(v.SVacant);
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
            try
            {
                foreach (var v in reposFactory.GetStaff().GetSingleTable())
                {
                    comboBoxLeader.Items.Add(v.StaffId);
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
            try
            {
                foreach (var v in reposFactory.GetHotel().GetSingleTable())
                {
                    comboBoxStaffHotel.Items.Add(v.HotelName);
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        /*textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                    comboBoxStaffGender, StaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel,
                    dgvStaff, dgvStaff.CurrentRow.Index*/

        public void EnterStaffBox(ReposFactory reposFactory, TextBox textBoxStaffId,
            TextBox textBoxStaffName, TextBox textBoxStaffSirName,
            ComboBox comboBoxStaffGender, DateTimePicker staffBirth, ComboBox comboBoxSvacant, ComboBox comboBoxLeader,
            ComboBox comboBoxStaffHotel,
            DataGridView dgvStaff, int dgvIndex)
        {
            textBoxStaffId.Text = dgvStaff.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxStaffName.Text = dgvStaff.Rows[dgvIndex].Cells[1].Value.ToString();
            textBoxStaffSirName.Text = dgvStaff.Rows[dgvIndex].Cells[2].Value.ToString();
            comboBoxStaffGender.Text = dgvStaff.Rows[dgvIndex].Cells[3].Value.ToString();
            staffBirth.Text = dgvStaff.Rows[dgvIndex].Cells[4].Value.ToString();
            comboBoxSvacant.Text = dgvStaff.Rows[dgvIndex].Cells[5].Value.ToString();
            comboBoxLeader.Text = dgvStaff.Rows[dgvIndex].Cells[6].Value.ToString();
            comboBoxStaffHotel.Text = dgvStaff.Rows[dgvIndex].Cells[7].Value.ToString();
        }

        public void EditStaffBox(ReposFactory reposFactory, TextBox textBoxStaffId,
            TextBox textBoxStaffName, TextBox textBoxStaffSirName,
            ComboBox comboBoxStaffGender, DateTimePicker staffBirth, ComboBox comboBoxSvacant, ComboBox comboBoxLeader,
            ComboBox comboBoxStaffHotel)
        {
            try
            {
                reposFactory.GetStaff().EditStaff(textBoxStaffId.Text, textBoxStaffName.Text, textBoxStaffSirName.Text,
                    comboBoxStaffGender.Text, staffBirth.Value.ToString("dd/MM/yyyy"),
                    comboBoxSvacant.Text, comboBoxLeader.Text, comboBoxStaffHotel.Text);

                textBoxStaffId.Text = string.Empty;
                textBoxStaffName.Text = string.Empty;
                textBoxStaffName.Enabled = true;
                textBoxStaffSirName.Text = string.Empty;
                textBoxStaffSirName.Enabled = true;
                comboBoxStaffGender.Text = string.Empty;
                comboBoxStaffGender.Enabled = true;
                comboBoxSvacant.Text = string.Empty;
                comboBoxSvacant.Enabled = true;
                comboBoxLeader.Text = string.Empty;
                comboBoxLeader.Enabled = true;
                comboBoxStaffHotel.Text = string.Empty;
                comboBoxStaffHotel.Enabled = true;

                //staffBirth.Text = string.Empty;
                //staffBirth.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void AddStaff(ReposFactory reposFactory, TextBox textBoxStaffId,
            TextBox textBoxStaffName, TextBox textBoxStaffSirName,
            ComboBox comboBoxStaffGender, DateTimePicker staffBirth, ComboBox comboBoxSvacant, ComboBox comboBoxLeader,
            ComboBox comboBoxStaffHotel)
        {
            try
            {
                reposFactory.GetStaff().AddStaff(textBoxStaffId.Text, textBoxStaffName.Text, textBoxStaffSirName.Text,
                    comboBoxStaffGender.Text, staffBirth.Value.ToString("dd/MM/yyyy"),
                    comboBoxSvacant.Text, comboBoxLeader.Text, comboBoxStaffHotel.Text);

                textBoxStaffId.Text = string.Empty;
                textBoxStaffName.Text = string.Empty;
                textBoxStaffName.Enabled = true;
                textBoxStaffSirName.Text = string.Empty;
                textBoxStaffSirName.Enabled = true;
                comboBoxStaffGender.Text = string.Empty;
                comboBoxStaffGender.Enabled = true;
                comboBoxSvacant.Text = string.Empty;
                comboBoxSvacant.Enabled = true;
                comboBoxLeader.Text = string.Empty;
                comboBoxLeader.Enabled = true;
                comboBoxStaffHotel.Text = string.Empty;
                comboBoxStaffHotel.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void DeleteStaff(ReposFactory reposFactory, TextBox textBoxStaffId,
            TextBox textBoxStaffName, TextBox textBoxStaffSirName,
            ComboBox comboBoxStaffGender, DateTimePicker staffBirth, ComboBox comboBoxSvacant, ComboBox comboBoxLeader,
            ComboBox comboBoxStaffHotel)
        {
            try
            {
                reposFactory.GetStaff().DeleteStaff(textBoxStaffId.Text);

                textBoxStaffId.Text = string.Empty;
                textBoxStaffName.Text = string.Empty;
                textBoxStaffName.Enabled = true;
                textBoxStaffSirName.Text = string.Empty;
                textBoxStaffSirName.Enabled = true;
                comboBoxStaffGender.Text = string.Empty;
                comboBoxStaffGender.Enabled = true;
                comboBoxSvacant.Text = string.Empty;
                comboBoxSvacant.Enabled = true;
                comboBoxLeader.Text = string.Empty;
                comboBoxLeader.Enabled = true;
                comboBoxStaffHotel.Text = string.Empty;
                comboBoxStaffHotel.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // должность
        public void EnterVacantBox(TextBox textBoxSvacantId, TextBox textBoxSvacantName, TextBox textBoxSvacantPay,
            DataGridView dgvStaffPosition, int dgvIndex)
        {
            textBoxSvacantId.Text = dgvStaffPosition.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxSvacantName.Text = dgvStaffPosition.Rows[dgvIndex].Cells[1].Value.ToString();
            textBoxSvacantPay.Text = dgvStaffPosition.Rows[dgvIndex].Cells[2].Value.ToString();
        }

        public void EditStaffBoxVacant(ReposFactory reposFactory, TextBox textBoxSvacantId,
            TextBox textBoxSvacantName, TextBox textBoxSvacantPay)
        {
            try
            {
                reposFactory.GetStaffPosition().EditStaffVacant(textBoxSvacantId.Text, textBoxSvacantName.Text, textBoxSvacantPay.Text);

                textBoxSvacantId.Text = string.Empty;
                textBoxSvacantId.Enabled = true;
                textBoxSvacantName.Text = string.Empty;
                textBoxSvacantName.Enabled = true;
                textBoxSvacantPay.Text = string.Empty;
                textBoxSvacantPay.Enabled = true;

            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void AddStaffVacant(ReposFactory reposFactory, TextBox textBoxSvacantId,
            TextBox textBoxSvacantName, TextBox textBoxSvacantPay)
        {
            try
            {
                reposFactory.GetStaffPosition().AddStaffVacant(textBoxSvacantId.Text, textBoxSvacantName.Text, textBoxSvacantPay.Text);

                textBoxSvacantId.Text = string.Empty;
                textBoxSvacantId.Enabled = true;
                textBoxSvacantName.Text = string.Empty;
                textBoxSvacantName.Enabled = true;
                textBoxSvacantPay.Text = string.Empty;
                textBoxSvacantPay.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        public void DeleteStaffVacant(ReposFactory reposFactory, TextBox textBoxSvacantId,
            TextBox textBoxSvacantName, TextBox textBoxSvacantPay)
        {
            try
            {
                reposFactory.GetStaffPosition().DeleteStaffVacant(textBoxSvacantId.Text);

                textBoxSvacantId.Text = string.Empty;
                textBoxSvacantId.Enabled = true;
                textBoxSvacantName.Text = string.Empty;
                textBoxSvacantName.Enabled = true;
                textBoxSvacantPay.Text = string.Empty;
                textBoxSvacantPay.Enabled = true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Произошла ошибка на уровне контроллера");
            }
        }

        // pass and login
        public void EditNewPass(ReposFactory reposFactory, string newAdminPass, string newStaffPass)
        {
            if (newAdminPass != string.Empty)
            {
                reposFactory.GetLogin().TableAdminEditPass(newAdminPass);
            }
            if (newStaffPass != string.Empty)
            {
                reposFactory.GetLogin().TableStaffEditPass(newStaffPass);
            }
        }
    }
}