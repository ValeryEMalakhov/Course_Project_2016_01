﻿using System;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Client
{
    public class ClientValidators
    {
        #region Global Values

        private bool ValidKey;
        private string ErrorString;

        #endregion

        public ClientValidators()
        {
            ValidKey = true;
            ErrorString = "--- Введите корректные значения ---\n" +
                          "-----------------------------------------\n";
        }

        #region mainForm

        public bool ValidNumOutput(DateTimePicker dateTPUser)
        {
            try
            {
                if (dateTPUser.Text == string.Empty)
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

        public bool ValidLogOutput(string loginId)
        {
            try
            {
                if (loginId == string.Empty)
                {
                    ErrorString += "-- LogIn не может быть пуcтой\n";
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

        public bool ValidNowOutput(string loginId)
        {
            try
            {
                if (loginId == string.Empty)
                {
                    ErrorString += "-- LogIn не может быть пуcтой\n";
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

        public bool ValidDelete(string loginId, int dgvIndex)
        {
            try
            {
                if (loginId == string.Empty)
                {
                    ErrorString += "-- LogIn не может быть пуcтой\n";
                    ValidKey = false;
                }
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

        #endregion

        #region addForm

        public bool ValidSelectStatInfo(string comboBoxApId, DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut,
            Label labelRoomT)
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

        public bool ValidAddUser(string comboBoxApId, DateTimePicker dtpCheckIn, DateTimePicker dtpCheckOut,
            RichTextBox textBoxComm)
        {
            try
            {
                if (comboBoxApId == string.Empty)
                {
                    ErrorString += "-- Номер комнаты не может быть пуcтой\n";
                    ValidKey = false;
                }
                else
                {
                    if (Convert.ToInt32(comboBoxApId) < 0)
                    {
                        ErrorString += "-- Номер комнаты не может быть меньше нуля\n";
                        ValidKey = false;
                    }
                }
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

        #endregion

        #region editForm

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

        public bool ValidUpdateUser(TextBox textBoxPass, TextBox textBoxFirstName, TextBox textBoxSecondName,
            ComboBox comboBoxGender, DateTimePicker dtpBirth, MaskedTextBox textBoxPhone)
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
                else
                {
                    if (comboBoxGender.Text != "муж" && comboBoxGender.Text != "жен")
                    {
                        ErrorString += "-- Пол человека не может быть таким\n";
                        ValidKey = false;
                    }
                }
                if (Regex.Replace(textBoxPhone.Text, "[ ]+", "") != "()-")
                {
                    if (textBoxPhone.Text.IndexOf(' ') != 5 && textBoxPhone.Text.IndexOf(' ') != -1)
                    {
                        ErrorString += "-- Номер должен быть без пробелов\n";
                        ValidKey = false;
                    }
                }
                else
                {
                    textBoxPhone.Text = "0000000000";
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
        public bool ValidUpdatePass(TextBox textNewPass)
        {
            try
            {
                if (textNewPass.Text == string.Empty)
                {
                    //ErrorString += "-- Пароль не может быть пустым\n";
                    ValidKey = false;
                }

                if (ValidKey)
                {
                    return ValidKey;
                }
                else
                {
                    //MessageBox.Show(ErrorString);
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