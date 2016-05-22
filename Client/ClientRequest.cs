﻿using System;
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
using System.Security.Cryptography;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using ClassRequest;
using ClassRequest.DAL;
using ClassRequest.SingleTable;
using Npgsql;

namespace Client
{
    public class ClientRequest
    {
        #region Global Values

        #endregion

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
                        reposFactory.GetACard().AddUser(loginId, v.FirstName, v.SecondName,
                            v.Gender, v.DateOfBirth, v.Phone,
                            apId, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text);
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
            DateTimePicker dtpCheckOut, Label labelRoomN, Label labelRoomQ, Label labelRoomT, Label labelRoomC)
        {
            double costValue = 0;
            labelRoomN.Text = comboBoxApId;
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
    }
}
