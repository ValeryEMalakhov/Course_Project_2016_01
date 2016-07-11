using System;
using System.Windows.Forms;
using ClassRequest.Login;

namespace LogIn
{
    public partial class RegForm : Form
    {
        private LoginReposFactory _loginReposFactory;
        private LogInValidators _logInValidators;
        private LogInRequest _logInRequest;

        private ConnectConfig cc;

        public RegForm()
        {
            InitializeComponent();
        }

        public RegForm(LoginReposFactory loginReposFactory)
        {
            InitializeComponent();

            _loginReposFactory = loginReposFactory;
            _logInValidators = new LogInValidators();
            _logInRequest = new LogInRequest();

            textBoxPass.UseSystemPasswordChar = true;
        }

        private void RegForm_Load(object sender, EventArgs e)
        {
            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            dtpBirth.MinDate = DateTime.Today.AddYears(-120);
            dtpBirth.MaxDate = DateTime.Today.AddYears(-16);
        }

        private void RegForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            textBoxPass.UseSystemPasswordChar = !textBoxPass.UseSystemPasswordChar;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            textBoxPass.Enabled = false;
            btnNext.Enabled = false;
            groupBoxInfo.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text == "user-1102")
               TestEnter();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_logInValidators.ValidAddUser(textBoxPass, textBoxCodeID, textBoxFirstName, textBoxSecondName,
                comboBoxGender, dtpBirth, maskedTextBoxPhone))
            {
                _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                    textBoxFirstName, textBoxSecondName,
                    comboBoxGender, dtpBirth, maskedTextBoxPhone);
                this.Close();
            }
        }

        private void TestEnter()
        {

            textBoxPass.Text = "1102";
            textBoxCodeID.Text = "GB 00 000 000";
            textBoxFirstName.Text = "Сабрина";
            textBoxSecondName.Text = "МакГи";
            comboBoxGender.Text = "жен";
            dtpBirth.Text = "06.06.1996";
            maskedTextBoxPhone.Text = "(777) 745-5913";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1103";
            textBoxCodeID.Text = "GB 11 111 111";
            textBoxFirstName.Text = "Кэтрин";
            textBoxSecondName.Text = "Далтон";
            comboBoxGender.Text = "жен";
            dtpBirth.Text = "12.07.1990";
            maskedTextBoxPhone.Text = "(777) 654-2353";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1104";
            textBoxCodeID.Text = "GB 33 444 444";
            textBoxFirstName.Text = "Томас";
            textBoxSecondName.Text = "Саттони";
            comboBoxGender.Text = "муж";
            dtpBirth.Text = "13.06.1992";
            maskedTextBoxPhone.Text = "(777) 746-6914";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1105";
            textBoxCodeID.Text = "GB 44 555 555";
            textBoxFirstName.Text = "Мерси";
            textBoxSecondName.Text = "Дженкинс";
            comboBoxGender.Text = "жен";
            dtpBirth.Text = "09.08.1987";
            maskedTextBoxPhone.Text = "(777) 545-5333";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1106";
            textBoxCodeID.Text = "RU 66 777 777";
            textBoxFirstName.Text = "Дмитрий";
            textBoxSecondName.Text = "Лисов";
            comboBoxGender.Text = "муж";
            dtpBirth.Text = "08.06.1996";
            maskedTextBoxPhone.Text = "(444) 506-7877";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1107";
            textBoxCodeID.Text = "US 77 888 888";
            textBoxFirstName.Text = "Питер";
            textBoxSecondName.Text = "Бут";
            comboBoxGender.Text = "муж";
            dtpBirth.Text = "22.02.1985";
            maskedTextBoxPhone.Text = "(656) 875-4233";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1108";
            textBoxCodeID.Text = "GB 99 000 000";
            textBoxFirstName.Text = "Дэвид";
            textBoxSecondName.Text = "Роджерс";
            comboBoxGender.Text = "муж";
            dtpBirth.Text = "01.03.1983";
            maskedTextBoxPhone.Text = "(777) 742-2741";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);
            textBoxPass.Text = "1109";
            textBoxCodeID.Text = "GB 22 333 333";
            textBoxFirstName.Text = "Джефф";
            textBoxSecondName.Text = "Моро";
            comboBoxGender.Text = "муж";
            dtpBirth.Text = "01.01.1955";
            maskedTextBoxPhone.Text = "(777) 424-2564";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName, comboBoxGender, dtpBirth, maskedTextBoxPhone);

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