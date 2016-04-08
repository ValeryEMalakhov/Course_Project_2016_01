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

namespace Staff.Sided_Form
{
    public partial class AddUserForm : Form
    {
        // глобальные переменные
        SqlConnect sqlConnect = new SqlConnect();
        StaffSql staff = new StaffSql();

        public AddUserForm()
        {
            InitializeComponent();
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {

        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // предположим, потом это будет делать IDisposable
            sqlConnect.GetInstance().CloseConn();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            staff.AddUser(textBoxPass.Text, textBoxFirstName.Text, textBoxSecondName.Text, textBoxGender.Text, dateTimePicker.Text, textBoxPhone.Text);
        }
    }
}
