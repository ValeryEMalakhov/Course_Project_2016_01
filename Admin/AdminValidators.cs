using System;
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
    public class AdminValidators
    {
        #region Global Values

        private bool ValidKey;
        private string ErrorString;

        #endregion

        public AdminValidators()
        {
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "-----------------------------------------\n";
        }

        #region mainForm

        public bool ValidUserOutput(DateTimePicker dtp)
        {
            try
            {
                if (dtp.Text == string.Empty)
                {
                    ErrorString += "-- Дата не может быть пуcтой\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidNumOutput(DateTimePicker dtp)
        {
            try
            {
                if (dtp.Text == string.Empty)
                {
                    ErrorString += "-- Дата не может быть пуcтой\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidNumCostOutput()
        {
            try
            {
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidUserDelete(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEnterFirstBox(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEnterSecondBox(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEnterThirdBox(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEnterStaffBox(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEnterVacantBox(int dgvIndex)
        {
            try
            {
                if (dgvIndex < 0)
                {
                    ErrorString += "-- Индекс не может быть отрицательным\n";
                    MessageBox.Show(@"Как вы получили отрицательный индекс?");
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEditThirdBox(string textBoxHotelNum, string textBoxHotelName, string textBoxHotelOrg,
            string textBoxHotelC,
            string textBoxHotelS, string textBoxHotelPhone, string textBoxHotelClass, string textBoxHotelWeb)
        {
            try
            {
                if (textBoxHotelNum == string.Empty)
                {
                    ErrorString += "-- Сначало выберите отель\n";
                    ValidKey = false;
                }
                else
                {
                    try
                    {
                        Convert.ToInt32(textBoxHotelNum);
                    }
                    catch (Exception)
                    {
                        ErrorString += "-- Код отеля должен быть численным \n";
                        ValidKey = false;
                    }
                }
                if (textBoxHotelName == string.Empty)
                {
                    ErrorString += "-- Поле названия отеля не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxHotelOrg == string.Empty)
                {
                    ErrorString += "-- Поле организации не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxHotelC == string.Empty)
                {
                    ErrorString += "-- Поле города не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxHotelS == string.Empty)
                {
                    ErrorString += "-- Поле улицы не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxHotelClass == string.Empty)
                {
                    ErrorString += "-- Поле класса отеля не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxHotelClass) > 5 || Convert.ToInt32(textBoxHotelClass) < 1)
                    {
                        ErrorString += "-- Класса отеля не может быть вне диапазона {1-5}\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEditSecondBox(string numClass, string numClassCost)
        {
            try
            {
                numClassCost = numClassCost.Replace('.', ',');
                if (numClass == string.Empty)
                {
                    ErrorString += "-- Сначало выберите класс\n";
                    ValidKey = false;
                }

                if (numClassCost == string.Empty)
                {
                    ErrorString += "-- Поле стоимости не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToDouble(numClassCost) < 0)
                    {
                        ErrorString += "-- Стоимость не может быть меньше нуля\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEditFirstBox(string textBoxNum, string textBoxNumHotel, string textBoxNumPlace,
            string textBoxNumClass)
        {
            try
            {
                if (textBoxNum == string.Empty)
                {
                    ErrorString += "-- Сначало выберите номер\n";
                    ValidKey = false;
                }

                if (textBoxNumHotel == string.Empty)
                {
                    ErrorString += "-- Поле отеля не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxNumPlace == string.Empty)
                {
                    ErrorString += "-- Поле количества комнат не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxNumPlace) <= 0)
                    {
                        ErrorString += "-- Количество комнат не может быть меньше или равняться нулю\n";
                        ValidKey = false;
                    }
                }

                if (textBoxNumClass == string.Empty)
                {
                    ErrorString += "-- Поле класса номера не может быть пустым\n";
                    ValidKey = false;

                }
                else
                {
                    if (Convert.ToInt32(textBoxNumClass) <= 0 || Convert.ToInt32(textBoxNumClass) > 5)
                    {
                        ErrorString += "-- Клас не находиться в диапазоне (0-5)\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidDeleteFirstBox(string textBoxNum, string textBoxNumHotel, string textBoxNumPlace,
            string textBoxNumClass)
        {
            try
            {
                if (textBoxNum == string.Empty)
                {
                    ErrorString += "-- Сначало выберите номер\n";
                    ValidKey = false;
                }

                if (textBoxNumHotel == string.Empty)
                {
                    ErrorString += "-- Поле отеля не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxNumPlace == string.Empty)
                {
                    ErrorString += "-- Поле количества комнат не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxNumPlace) <= 0)
                    {
                        ErrorString += "-- Количество комнат не может быть меньше или равняться нулю\n";
                        ValidKey = false;
                    }
                }

                if (textBoxNumClass == string.Empty)
                {
                    if (Convert.ToInt32(textBoxNumClass) <= 0 || Convert.ToInt32(textBoxNumClass) > 5)
                    {
                        ErrorString += "-- Клас не находиться в диапазоне (0-5)\n";
                        ValidKey = false;
                    }
                    else
                    {
                        ErrorString += "-- Поле класса номера не может быть пустым\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidAddFirstBox(string textBoxNum, string textBoxNumHotel, string textBoxNumPlace,
            string textBoxNumClass, DataGridView dgvNum)
        {
            try
            {
                if (textBoxNum == string.Empty)
                {
                    ErrorString += "-- Сначало выберите номер\n";
                    ValidKey = false;
                }
                else
                {
                    try
                    {
                        Convert.ToInt32(textBoxNum);
                    }
                    catch (Exception)
                    {
                        ErrorString += "-- Код номера должен быть численным \n";
                        ValidKey = false;
                    }

                    for (int i = 0; i < dgvNum.RowCount; i++)
                    {
                        if (textBoxNum == dgvNum.Rows[i].Cells[0].Value.ToString())
                        {
                            ErrorString += "-- Номер уже есть в отеле\n";
                            ValidKey = false;
                        }
                    }
                }

                if (textBoxNumHotel == string.Empty)
                {
                    ErrorString += "-- Поле отеля не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxNumPlace == string.Empty)
                {
                    ErrorString += "-- Поле количества комнат не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxNumPlace) <= 0)
                    {
                        ErrorString += "-- Количество комнат не может быть меньше или равняться нулю\n";
                        ValidKey = false;
                    }
                }

                if (textBoxNumClass == string.Empty)
                {
                    ErrorString += "-- Поле класса номера не может быть пустым\n";
                    ValidKey = false;

                }
                else
                {
                    if (Convert.ToInt32(textBoxNumClass) <= 0 || Convert.ToInt32(textBoxNumClass) > 5)
                    {
                        ErrorString += "-- Клас не находиться в диапазоне (0-5)\n";
                        ValidKey = false;
                    }
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidAddStaff(string textBoxStaffId, string textBoxStaffName, string textBoxStaffSirName,
            string comboBoxStaffGender, string staffBirth, string comboBoxSvacant,
            string comboBoxLeader, string comboBoxStaffHotel)
        {
            try
            {
                if (textBoxStaffId != string.Empty)
                {
                    ErrorString += "-- Поле ID должно быть пустым!\n";
                    ValidKey = false;
                }

                if (textBoxStaffName == string.Empty)
                {
                    ErrorString += "-- Поле имени не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxStaffSirName == string.Empty)
                {
                    ErrorString += "-- Поле фамилии не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxStaffGender == string.Empty)
                {
                    ErrorString += "-- Поле gender не может быть пустым\n";
                    ValidKey = false;
                }

                if (staffBirth == string.Empty)
                {
                    ErrorString += "-- Поле даты рождения не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxSvacant == string.Empty)
                {
                    ErrorString += "-- Поле должности не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxLeader != string.Empty)
                {
                    if (Convert.ToInt32(comboBoxLeader) < 0)
                    {
                        ErrorString += "-- Лидер не может быть меньше нуля\n";
                        ValidKey = false;
                    }
                }

                if (comboBoxStaffHotel == string.Empty)
                {
                    ErrorString += "-- Поле отеля не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidEditStaff(string textBoxStaffId, string textBoxStaffName, string textBoxStaffSirName,
            string comboBoxStaffGender, string staffBirth, string comboBoxSvacant,
            string comboBoxLeader, string comboBoxStaffHotel)
        {
            try
            {
                if (textBoxStaffId == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxStaffName == string.Empty)
                {
                    ErrorString += "-- Поле имени не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxStaffSirName == string.Empty)
                {
                    ErrorString += "-- Поле фамилии не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxStaffGender == string.Empty)
                {
                    ErrorString += "-- Поле gender не может быть пустым\n";
                    ValidKey = false;
                }

                if (staffBirth == string.Empty)
                {
                    ErrorString += "-- Поле даты рождения не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxSvacant == string.Empty)
                {
                    ErrorString += "-- Поле должности не может быть пустым\n";
                    ValidKey = false;
                }

                if (comboBoxLeader != string.Empty)
                {
                    if (Convert.ToInt32(comboBoxLeader) < 0)
                    {
                        ErrorString += "-- Лидер не может быть меньше нуля\n";
                        ValidKey = false;
                    }
                }

                if (comboBoxStaffHotel == string.Empty)
                {
                    ErrorString += "-- Поле отеля не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidDeleteStaff(string textBoxStaffId)
        {
            try
            {
                if (textBoxStaffId == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidVacant(string textBoxSvacantId, string textBoxSvacantName, string textBoxSvacantPay)
        {
            try
            {
                if (textBoxSvacantId == string.Empty)
                {
                    ErrorString += "-- Поле ID не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxSvacantId) <= 0)
                    {
                        ErrorString += "-- ID не может быть меньше или равняться нулю\n";
                        ValidKey = false;
                    }
                }

                if (textBoxSvacantName == string.Empty)
                {
                    ErrorString += "-- Поле названия должности не может быть пустым\n";
                    ValidKey = false;
                }

                if (textBoxSvacantPay == string.Empty)
                {
                    ErrorString += "-- Поле стоимости не может быть пустым\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(textBoxSvacantId) < 0)
                    {
                        ErrorString += "-- Зарплата не может быть меньше нуля\n";
                        ValidKey = false;
                    }
                }


                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }


        #endregion

        #region AddUserForm

        public bool ValidGetUserIdList(TextBox textBoxPass)
        {
            try
            {
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidUpdateComboBoxApId(ComboBox comboBox, DateTimePicker dtpIn)
        {
            try
            {
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidAddUser(TextBox textBoxPass, TextBox textBoxFirstName, TextBox textBoxSecondName,
            ComboBox comboBoxGender, DateTimePicker dtpBirth, MaskedTextBox textBoxPhone, ComboBox comboBoxApId,
            DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut, RichTextBox textBoxComm)
        {
            try
            {
                if (textBoxPass.Text == string.Empty)
                {
                    ErrorString += "-- Код паспорта не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxFirstName.Text == string.Empty)
                {
                    ErrorString += "-- Поле имени не может быть пустым\n";
                    ValidKey = false;
                }
                if (textBoxSecondName.Text == string.Empty)
                {
                    ErrorString += "-- Поле фамилии не может быть пустым\n";
                    ValidKey = false;
                }
                if (comboBoxGender.Text == string.Empty)
                {
                    ErrorString += "-- Пол человека не может быть пустым\n";
                    ValidKey = false;
                }
                //if (comboBoxApId.Text != string.Empty)
                //{
                //    ErrorString += "-- Номер комнаты не может быть пустым\n";
                //    ValidKey = false;
                //}
                if (dtpCheckOut.Value < dtpCheckIn.Value)
                {
                    ErrorString += "-- Дата выселения не может быть раньше даты вселения в номер\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidSelectStatInfo(ComboBox comboBoxApId, DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut,
            Label labelRoomN, Label labelRoomQ, Label labelRoomT, Label labelRoomC)
        {
            try
            {
                var dateDiff = (dtpCheckOut.Value - dtpCheckIn.Value).TotalDays;
                labelRoomT.Text = Convert.ToString(dateDiff, CultureInfo.CurrentCulture);
                if (dateDiff < 0)
                {
                    ErrorString += "-- Дата выселения не может быть раньше даты вселения в номер\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        public bool ValidInputAllClientFields(TextBox textBoxPass, TextBox textBoxFirstName,
            TextBox textBoxSecondName, ComboBox comboBoxGender, DateTimePicker dtpBirth, MaskedTextBox textBoxPhone)
        {
            try
            {
                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    MessageBox.Show(ErrorString);
                    return ValidKey;
                }
            }
            finally
            {
                ValidKey = true;
                ErrorString = "--- Введите корректные значения ---\n" +
                              "-----------------------------------------\n";
            }
        }

        #endregion

    }
}
