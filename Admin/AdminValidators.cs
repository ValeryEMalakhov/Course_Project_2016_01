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
            ComboBox comboBoxGender, DateTimePicker dtpBirth, TextBox textBoxPhone, ComboBox comboBoxApId,
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
            TextBox textBoxSecondName, ComboBox comboBoxGender, DateTimePicker dtpBirth, TextBox textBoxPhone)
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
