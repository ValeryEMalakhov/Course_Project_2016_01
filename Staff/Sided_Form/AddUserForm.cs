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

        ReposFactory _reposFactory;
        StaffRequest _staffRequest;
        StaffValidators _staffValidators;

        #endregion

        public AddUserForm(ReposFactory reposFactory)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _staffRequest = new StaffRequest();
            _staffValidators = new StaffValidators();

            if (_staffValidators.ValidGetUserIdList(textBoxPass))
            {
                _staffRequest.GetUserIdList(_reposFactory, textBoxPass);
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;

            _staffValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn);
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_staffValidators.ValidAddUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                dtpBirth, textBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm))
            {
                _staffRequest.AddUser(_reposFactory, textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                    dtpBirth, textBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm);
            }

            // обновляем список свободных комнат
            if (_staffValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _staffRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn);
            }
            if (_staffValidators.ValidGetUserIdList(textBoxPass))
            {
                _staffRequest.GetUserIdList(_reposFactory, textBoxPass);
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


            if (_staffValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _staffRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn);
            }
            if (comboBoxApId.Text != string.Empty)
            {
                // обновляет автоматическую статистику в labels
                if (_staffValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC))
                {
                    _staffRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC);
                }
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text != string.Empty)
            {

                if (_staffValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone))
                {
                    _staffRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone);
                }
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPass.Text != string.Empty)
                {
                    if (_staffValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone))
                    {
                        _staffRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                            textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone);
                    }
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
                if (_staffValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC))
                {
                    _staffRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC);
                }
            }
        }

        private void comboBoxApId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBoxApId.Text != string.Empty)
                {
                    if (_staffValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC))
                    {
                        _staffRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                            labelRoomQ, labelRoomT, labelRoomC);
                    }
                }
            }
        }
    }
}