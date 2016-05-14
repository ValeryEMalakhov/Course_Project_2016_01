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
using ClassRequest.DAL;
using ClassRequest.SingleTable;

namespace Staff.Sided_Form
{
    public partial class AddUserForm : Form
    {
        #region Global Values
        RepositoryACard repositoryACard = new RepositoryACard();
        RepositoryAClass repositoryAClass = new RepositoryAClass();
        RepositoryApartment repositoryApartment = new RepositoryApartment();
        RepositoryApartmentAClass repositoryApartmentAClass = new RepositoryApartmentAClass();
        RepositoryClient repositoryClient = new RepositoryClient();
        RepositoryHotel repositoryHotel = new RepositoryHotel();
        RepositoryStaff repositoryStaff = new RepositoryStaff();
        RepositoryStaffPosition repositoryStaffPosition = new RepositoryStaffPosition();
        RepositoryUserApartmentCard repositoryUserApartmentCard = new RepositoryUserApartmentCard();
        #endregion
        // глобальные переменные
        SqlConnect _sqlConnect;
        StaffRequest _staffRequest = new StaffRequest();

        public AddUserForm(SqlConnect sqlConnect)
        {
            InitializeComponent();
            this._sqlConnect = sqlConnect;
            _staffRequest.GetUserIdList(this._sqlConnect, textBoxPass);
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;
            _staffRequest.UpdateComboBoxApId(_sqlConnect, comboBoxApId, dtpCheckIn);
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

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
                repositoryACard.AddUser(_sqlConnect, textBoxPass.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text,
                    dtpBirth.Text, textBoxPhone.Text,
                    comboBoxApId.Text, dtpCheckIn.Text, dtpCheckOut.Text, textBoxComm.Text);

                textBoxPass.Clear();
                textBoxFirstName.Clear();
                textBoxSecondName.Clear();
                comboBoxGender.Text = string.Empty;
                textBoxPhone.Clear();
                comboBoxApId.Items.Clear();
                comboBoxApId.Text = string.Empty;
                textBoxComm.Clear();

                // обновляем список свободных комнат
                _staffRequest.UpdateComboBoxApId(_sqlConnect, comboBoxApId, dtpCheckIn);
                _staffRequest.GetUserIdList(_sqlConnect, textBoxPass);
            }
            else
            {
                MessageBox.Show(@"Заполните все обязательные поля!");
            }
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value < DateTime.Now)
            {
                dtpCheckIn.Value = DateTime.Now;
            }
            if (dtpCheckOut.Value < dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
            _staffRequest.UpdateComboBoxApId(_sqlConnect, comboBoxApId, dtpCheckIn);
            if (comboBoxApId.Text != string.Empty)
            {
                // обновляет автоматическую статистику в labels
                _staffRequest.SelectStatInfo(_sqlConnect, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC);
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text != string.Empty)
            {
                _staffRequest.InputAllClientFields(_sqlConnect, textBoxPass.Text, textBoxFirstName, textBoxSecondName,
                    comboBoxGender, dtpBirth, textBoxPhone);
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPass.Text != string.Empty)
                {
                    _staffRequest.InputAllClientFields(_sqlConnect, textBoxPass.Text, textBoxFirstName, textBoxSecondName,
                        comboBoxGender, dtpBirth, textBoxPhone);
                }
            }
        }

        private void comboBoxApId_TextChanged(object sender, EventArgs e)
        {
            if (dtpCheckOut.Value < dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }
            if (comboBoxApId.Text != string.Empty)
            {
                _staffRequest.SelectStatInfo(_sqlConnect, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC);
            }
        }

        private void comboBoxApId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxApId.Text != string.Empty)
                {
                    _staffRequest.SelectStatInfo(_sqlConnect, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC);
                }
            }
        }
    }
}
