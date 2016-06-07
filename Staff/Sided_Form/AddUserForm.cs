using System;
using System.Windows.Forms;
using ClassRequest;

namespace Staff.Sided_Form
{
    public partial class AddUserForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        StaffRequest _staffRequest;
        StaffValidators _staffValidators;

        #endregion

        public AddUserForm()
        { }

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

            dtpBirth.MinDate = DateTime.Today.AddYears(-100);
            dtpBirth.MaxDate = DateTime.Today.AddYears(-16);
            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckIn.MaxDate = DateTime.Today.AddYears(1);
            dtpCheckOut.MinDate = DateTime.Today;
            dtpCheckOut.MaxDate = DateTime.Today.AddYears(2);


            _staffValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn);
        }

        private void AddUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_staffValidators.ValidAddUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                dtpBirth, maskedTextBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm))
            {
                _staffRequest.AddUser(_reposFactory, textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                    dtpBirth, maskedTextBoxPhone, comboBoxApId, dtpCheckIn, dtpCheckOut, textBoxComm);
            }

            // обновляем список свободных комнат
            if (_staffValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _staffRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
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
                _staffRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
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
                    textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone))
                {
                    _staffRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
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
                    if (_staffValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone))
                    {
                        _staffRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
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