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

namespace Admin.Sided_Form
{
    public partial class AddUserForm : Form
    {
        #region Global Values

        AdminValidators _adminValidators;
        AdminRequest _adminRequest;
        ReposFactory _reposFactory;

        #endregion

        public AddUserForm()
        { }

        public AddUserForm(ReposFactory reposFactory)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _adminRequest = new AdminRequest();
            _adminValidators = new AdminValidators();

            if (_adminValidators.ValidGetUserIdList(textBoxPass))
            {
                _adminRequest.GetUserIdList(_reposFactory, textBoxPass);
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;

            _adminValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn);
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidAddUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                dtpBirth, maskedTextBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm))
            {
                _adminRequest.AddUser(_reposFactory, textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                    dtpBirth, maskedTextBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm);
            }

            // обновляем список свободных комнат
            if (_adminValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _adminRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn);
            }
            if (_adminValidators.ValidGetUserIdList(textBoxPass))
            {
                _adminRequest.GetUserIdList(_reposFactory, textBoxPass);
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


            if (_adminValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _adminRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn);
            }
            if (comboBoxApId.Text != string.Empty)
            {
                // обновляет автоматическую статистику в labels
                if (_adminValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC))
                {
                    _adminRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC);
                }
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text != string.Empty)
            {
                if (_adminValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone))
                {
                    _adminRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);
                }
            }
        }

        private void textBoxPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBoxPass.Text != string.Empty)
                {
                    if (_adminValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone))
                    {
                        _adminRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                            textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);
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
                if (_adminValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC))
                {
                    _adminRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
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
                    if (_adminValidators.ValidSelectStatInfo(comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                        labelRoomQ, labelRoomT, labelRoomC))
                    {
                        _adminRequest.SelectStatInfo(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                            labelRoomQ, labelRoomT, labelRoomC);
                    }
                }
            }
        }

        private void comboBoxApId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}