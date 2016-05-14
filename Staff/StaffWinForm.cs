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
using ClassRequest.DAL;
using Staff.Sided_Form;

namespace Staff
{
    public partial class StaffWinForm : Form
    {
        #region Global Values
        SqlConnect _sqlConnect;
        NpgsqlConnection _conn;
        StaffRequest _staffRequest;
        #endregion

        public StaffWinForm(NpgsqlConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            _sqlConnect = new SqlConnect(_conn);
            _staffRequest = new StaffRequest();

            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Horizontal;
        }

        public StaffWinForm()
        { }

        private void StaffWinForm_Load(object sender, EventArgs e)
        {
            // открываем соединение
            _sqlConnect.GetInstance().OpenConn();

            // использовать дату из dateTPUser
            _staffRequest.UserOutput(_sqlConnect, dgvUser, dateTPUser);
            _staffRequest.NumOutput(_sqlConnect, dgvNum, dateTPUser);

            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            _sqlConnect.GetInstance().CloseConn();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Эта кнопка мертва
            _staffRequest.UserOutput(_sqlConnect, dgvUser, dateTPUser);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm(_sqlConnect);
            addUser.ShowDialog();

            // обновляем таблицу
            _staffRequest.UserOutput(_sqlConnect, dgvUser, dateTPUser);
            _staffRequest.NumOutput(_sqlConnect, dgvNum, dateTPUser);

            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            _staffRequest.NumOutput(_sqlConnect, dgvNum, dateTPNum);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // удаление это изменение даты выписки на сегоднешнюю
            try
            {
                _staffRequest.FakedUserDelete(_sqlConnect, dgvUser.CurrentRow.Index);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // обновляем таблицу
                _staffRequest.UserOutput(_sqlConnect, dgvUser, dateTPUser);
                _staffRequest.NumOutput(_sqlConnect, dgvNum, dateTPUser);
            }
        }

        private void dateTPUser_ValueChanged(object sender, EventArgs e)
        {
            _staffRequest.UserOutput(_sqlConnect, dgvUser, dateTPUser);
        }
        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            _staffRequest.NumOutput(_sqlConnect, dgvNum, dateTPNum);
        }
    }
}
