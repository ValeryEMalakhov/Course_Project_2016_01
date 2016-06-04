using System;
using System.Windows.Forms;
using ClassRequest;

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

            if (_adminValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _adminRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
            }
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
                _adminRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
            }
            if (_adminValidators.ValidGetUserIdList(textBoxPass))
            {
                _adminRequest.GetUserIdList(_reposFactory, textBoxPass);
            }

            this.Close();
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
                _adminRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
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
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskedTextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}