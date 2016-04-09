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
using System.Runtime.CompilerServices;
using ClassRequest.DAL;
using ClassRequest.StaffReq;
using Npgsql;

namespace ClassRequest
{
    public class StaffRequest
    {
        // глобальные переменные
        StaffSql staff = new StaffSql();

        // вывод списка посетителей
        public void UserOutput(DataGridView dgvUser, DateTimePicker dateTpUser)
        {
            dgvUser.Rows.Clear();
            try
            {
                // фильтр даты
                string filterDate = dateTpUser.Text;
                foreach (var v in staff.GetUserList(filterDate))
                {
                    dgvUser.Rows.Add(v.FirstName, v.SecondName, v.Gender, v.ApId,
                        v.CheckInDate, v.CheckOutDate, v.ClientId);
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // вывод списка свободных номеров
        public void NumOutput(DataGridView dgvNum, DateTimePicker dateTpNum)
        {
            dgvNum.Rows.Clear();
            try
            {
                // фильтр даты
                string filterDate = dateTpNum.Text;
                foreach (var v in staff.GetNumList(filterDate))
                {
                    dgvNum.Rows.Add(v.ApId, v.PlaceQuantity,
                        v.ClassId, v.ClassCost);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        // запрос списка свободных комнат
        public void UpdateComboBoxApId(ComboBox comboBox, DateTimePicker dtpIn)
        {
            comboBox.Items.Clear();
            try
            {
                // фильтр даты
                string filterDate = dtpIn.Text;
                foreach (var v in staff.GetNumList(filterDate))
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

    }
}
