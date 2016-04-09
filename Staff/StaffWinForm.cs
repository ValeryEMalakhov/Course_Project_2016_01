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
        SqlConnect sqlConnect = new SqlConnect();
        StaffRequest staffRequest = new StaffRequest();


        public StaffWinForm()
        {
            InitializeComponent();

            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Horizontal;



        }

        private void StaffWinForm_Load(object sender, EventArgs e)
        {
            // использовать дату из dateTPUser
            staffRequest.UserOutput(dgvUser, dateTPUser);
            staffRequest.NumOutput(dgvNum, dateTPUser);
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // предположим, потом это будет делать IDisposable
            sqlConnect.GetInstance().CloseConn();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            staffRequest.UserOutput(dgvUser, dateTPUser);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.ShowDialog();

            // обновляем таблицу
            staffRequest.UserOutput(dgvUser, dateTPUser);
            staffRequest.NumOutput(dgvNum, dateTPUser);
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            staffRequest.NumOutput(dgvNum, dateTPNum);
        }
    }
}
