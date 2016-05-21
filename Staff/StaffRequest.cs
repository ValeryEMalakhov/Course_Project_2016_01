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
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using ClassRequest;
using ClassRequest.DAL;
using ClassRequest.SingleTable;
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

        // запрос списка свободных комнат
        public void UpdateComboBoxApId(ReposFactory reposFactory, ComboBox comboBox, DateTimePicker dtpIn)
        {
            comboBox.Items.Clear();
            try
            {
                // фильтр даты
                //var dateMinusDay = dtpIn.Value.AddDays(-1);
                string filterDate = Convert.ToString(dtpIn.Value);
                foreach (var v in reposFactory.GetApartmentAClass().GetNumList(filterDate))
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
            ComboBox comboBoxGender, DateTimePicker dateTimePicker, TextBox textBoxPhone)
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
            int costValue = 0;
            labelRoomN.Text = comboBoxApId.Text;
            foreach (var v in reposFactory.GetApartmentAClass().UpdateStatAdd())
            {
                if (v.ApId == comboBoxApId.Text)
                {
                    labelRoomQ.Text = v.PlaceQuantity;
                    costValue = Convert.ToInt32(v.ClassCost);
                }
            }
            var dateDiff = (dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
            labelRoomT.Text = Convert.ToString(dateDiff, CultureInfo.CurrentCulture);
            if (dateDiff > 0)
            {
                labelRoomC.Text = Convert.ToString(dateDiff*costValue, CultureInfo.InvariantCulture);
            }
            else
            {
                labelRoomC.Text = @"Так не сработает";
            }
        }

        // псевдоудаление клента из таблицы
        public void FakedUserDelete(ReposFactory reposFactory, int dgvIndex)
        {
            try
            {
                // фильтр даты
                string filterDate = Convert.ToString(DateTime.Now);
                // счётчик
                int i = 0;
                foreach (var v in reposFactory.GetUserApartmentCard().GetUserList(filterDate))
                {
                    if (i == dgvIndex)
                    {
                        reposFactory.GetACard().FakeUserDeleteSql(v);
                    }
                    ++i;
                }
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
            ComboBox comboBoxGender, DateTimePicker dtpBirth, TextBox textBoxPhone, ComboBox comboBoxApId,
            DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut, RichTextBox textBoxComm)
        {
            try
            {
                reposFactory.GetACard().AddUser(textBoxPass.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text,
                    dtpBirth.Text, textBoxPhone.Text,
                    comboBoxApId.Text, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text);
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
    }
}
