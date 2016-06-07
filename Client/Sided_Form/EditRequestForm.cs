using System;
using System.Windows.Forms;
using ClassRequest;

namespace Client.Sided_Form
{
    public partial class EditRequestForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        ClientRequest _clientRequest;
        ClientValidators _clientValidators;

        private string _clientId;
        private string _loginId;

        #endregion

        // заглушка
        public EditRequestForm()
        {
            InitializeComponent();
        }

        public EditRequestForm(ReposFactory reposFactory, string clientId, string loginId)
        {
            InitializeComponent();
            _clientValidators = new ClientValidators();
            _clientRequest = new ClientRequest();

            _reposFactory = reposFactory;
            _clientId = clientId;
            _loginId = Protection.DESDecrypt(loginId);

            textBoxNewPass.UseSystemPasswordChar = true;
        }

        private void EditRequestForm_Load(object sender, EventArgs e)
        {
            textBoxPass.Text = _clientId;
            textBoxID.Text = _loginId;

            if (textBoxPass.Text != string.Empty)
            {
                if (_clientValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone))
                {
                    _clientRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);
                }
            }

            dtpBirth.MinDate = DateTime.Today.AddYears(-120);
            dtpBirth.MaxDate = DateTime.Today.AddYears(-16);
        }

        private void EditRequestForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_clientValidators.ValidUpdateUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                dtpBirth, maskedTextBoxPhone))
            {
                _clientRequest.UserEdit(_reposFactory, textBoxPass.Text, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);
            }
            if (_clientValidators.ValidUpdatePass(textBoxNewPass))
            {
                _clientRequest.UserEditPass(_reposFactory, _loginId, textBoxNewPass);
            }
        }

        private void EditRequestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_clientValidators.ValidUpdateUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                    dtpBirth, maskedTextBoxPhone))
                {
                    _clientRequest.UserEdit(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);
                }
                if (_clientValidators.ValidUpdatePass(textBoxNewPass))
                {
                    _clientRequest.UserEditPass(_reposFactory, _loginId, textBoxNewPass);
                }
            }
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewPass.UseSystemPasswordChar = !textBoxNewPass.UseSystemPasswordChar;
        }

        private void maskedTextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
