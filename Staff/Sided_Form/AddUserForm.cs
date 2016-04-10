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
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.SingleTable;
using ClassRequest.StaffReq;

namespace Staff.Sided_Form
{
    public partial class AddUserForm : Form
    {
        // глобальные переменные
        SqlConnect sqlConnect = new SqlConnect();
        StaffRequest staffRequest = new StaffRequest();
        StaffSql staff = new StaffSql();

        public AddUserForm()
        {
            InitializeComponent();
            staffRequest.GetUserIdList(textBoxPass);
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            staffRequest.UpdateComboBoxApId(comboBoxApId, dtpCheckIn);
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // на всякий случай
            sqlConnect.GetInstance().CloseConn();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPass.Text != string.Empty &
                textBoxFirstName.Text != string.Empty &
                textBoxSecondName.Text != string.Empty &
                comboBoxGender.Text != string.Empty &

                comboBoxApId.Text != string.Empty &
                dtpCheckOut.Value >= dtpCheckIn.Value)
            {
                staff.AddUser(textBoxPass.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text,
                    dtpBirth.Text, textBoxPhone.Text,
                    
                    comboBoxApId.Text, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text);
            }
            else
            {
                MessageBox.Show(@"Заполните все обязательные поля!");
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            staffRequest.UpdateComboBoxApId(comboBoxApId, dtpCheckIn);
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text != string.Empty)
            {
                staffRequest.InputAllClientFields(textBoxPass.Text, textBoxFirstName, textBoxSecondName,
                    comboBoxGender, dtpBirth, textBoxPhone);
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPass.Text != string.Empty)
                {
                    staffRequest.InputAllClientFields(textBoxPass.Text, textBoxFirstName, textBoxSecondName,
                        comboBoxGender, dtpBirth, textBoxPhone);
                }
            }
        }
    }
}
