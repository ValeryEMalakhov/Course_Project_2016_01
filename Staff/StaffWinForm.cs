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
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.StaffReq;
using Staff.Sided_Form;

namespace Staff
{
    public partial class StaffWinForm : Form
    {
        // Глобальные переменные
        SqlConnect sqlConnect;
        StaffRequest staffRequest;
        NpgsqlConnection _conn;
        public StaffWinForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            sqlConnect = new SqlConnect(conn);
            staffRequest = new StaffRequest(conn);
            _conn = conn;
            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Horizontal;
        }

        public StaffWinForm()
        { }

        private void StaffWinForm_Load(object sender, EventArgs e)
        {
            // использовать дату из dateTPUser
            staffRequest.UserOutput(dgvUser, dateTPUser);
            staffRequest.NumOutput(dgvNum, dateTPUser);
            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // предположим, потом это будет делать IDisposable
            sqlConnect.GetInstance().CloseConn();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Эта кнопка мертва
            staffRequest.UserOutput(dgvUser, dateTPUser);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm(_conn);
            addUser.ShowDialog();

            // обновляем таблицу
            staffRequest.UserOutput(dgvUser, dateTPUser);
            staffRequest.NumOutput(dgvNum, dateTPUser);
            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            staffRequest.NumOutput(dgvNum, dateTPNum);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // удаление это изменение даты выписки на сегоднешнюю
            try
            {
                staffRequest.FakedUserDelete(dgvUser.CurrentRow.Index);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // обновляем таблицу
                staffRequest.UserOutput(dgvUser, dateTPUser);
                staffRequest.NumOutput(dgvNum, dateTPUser);
                dgvUser.Rows[0].Selected = false;
                dgvUser.AllowUserToAddRows = false;
            }
        }

        private void dateTPUser_ValueChanged(object sender, EventArgs e)
        {
            staffRequest.UserOutput(dgvUser, dateTPUser);
            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            //MessageBox.Show(Convert.ToString(dateTPUser.Value));
        }

        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            staffRequest.NumOutput(dgvNum, dateTPNum);
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
        }
    }
}
