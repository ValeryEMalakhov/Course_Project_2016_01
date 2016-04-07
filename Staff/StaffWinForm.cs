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
using Staff.Sided_Form;

namespace Staff
{
    public partial class StaffWinForm : Form
    {
        public StaffWinForm()
        {
            InitializeComponent();

            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Horizontal;

        }

        private void StaffWinForm_Load(object sender, EventArgs e)
        {
            // использовать дату из dateTPUser
            // StaffRequest.UserOutput(dgvUser, dateTPUser);
            // StaffRequest.NumOutput(dgvNum, dateTPUser);
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // предположим, потом это будет делать IDisposable
            SqlConnect.GetInstance().CloseConn();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            StaffRequest.UserOutput(dgvUser, dateTPUser);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm();
            addUser.ShowDialog();

        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            StaffRequest.NumOutput(dgvNum, dateTPNum);
        }
    }
}
