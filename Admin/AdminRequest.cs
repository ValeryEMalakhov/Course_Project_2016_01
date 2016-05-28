﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;

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
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // записываем выбранный номер в TextBox-сы
        public void EnterFirstBox(TextBox textBoxNum, TextBox textBoxPlace, TextBox textBoxNumClass,
            TextBox textBoxNumCost, DataGridView dgvNum, int dgvIndex)
        {
            textBoxNum.Text = dgvNum.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxPlace.Text = dgvNum.Rows[dgvIndex].Cells[1].Value.ToString();
            textBoxNumClass.Text = dgvNum.Rows[dgvIndex].Cells[2].Value.ToString();
            textBoxNumCost.Text = dgvNum.Rows[dgvIndex].Cells[3].Value.ToString();
        }

        // записываем выбранный класс в TextBox-сы
        public void EnterSecondBox(TextBox textBoxClass, TextBox textBoxClassCost, DataGridView dgvNumClass,
            int dgvIndex)
        {
            textBoxClass.Text = dgvNumClass.Rows[dgvIndex].Cells[0].Value.ToString();
            textBoxClassCost.Text = dgvNumClass.Rows[dgvIndex].Cells[1].Value.ToString();
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

        public void EditSecondBox(ReposFactory reposFactory, TextBox textBoxClass, TextBox textBoxClassCost)
        {
            try
            {
                textBoxClassCost.Text = textBoxClassCost.Text.Replace('.', ',');
                reposFactory.GetAClass().EditClassCost(textBoxClass.Text, textBoxClassCost.Text);
                textBoxClass.Text = string.Empty;
                textBoxClassCost.Text = string.Empty;
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
    }
}
