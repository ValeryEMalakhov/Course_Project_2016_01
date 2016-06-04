using System;
using System.Windows.Forms;
using System.Configuration;
using Admin;
using ClassRequest;
using ClassRequest.Login;
using Staff;
using Client;

namespace LogIn
{
    public partial class NewLogInForm : Form
    {
        private LoginReposFactory _loginReposFactory;
        private ReposFactory _reposFactory;
        private LogInValidators _logInValidators;
        private LogInRequest _logInRequest;

        private string _login;
        private string _pass;
        private ConnectConfig cc;

        public NewLogInForm()
        {
            InitializeComponent();
        }

        public NewLogInForm(LoginReposFactory loginReposFactory)
        {
            InitializeComponent();
            _loginReposFactory = loginReposFactory;

            _logInValidators = new LogInValidators();
            _logInRequest = new LogInRequest();

            textBoxPass.UseSystemPasswordChar = true;
        }

        private void NemLogInForm_Load(object sender, EventArgs e)
        {

        }

        private void NemLogInForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            _login = textBoxID.Text;
            textBoxID.Text = string.Empty;
            _pass = textBoxPass.Text;
            textBoxPass.Text = string.Empty;

            // тестовый блок
            //_login = @"admin";
            //_pass = @"1507";
            //_login = @"staff";
            //_pass = @"1111";
            //_login = @"user-1106";
            //_pass = @"1106";

            EnterLogIn();
            //textBoxTest.Text = Protection.EncryptMD5(textBoxID.Text);
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm(_loginReposFactory);
            regForm.Show();
        }

        #region Параметры входа

        private void LoginLikeAdmin()
        {
            cc = new ConnectConfig(Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("ip")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("port")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("userIdAdmin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("passwdAdmin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("dataBase")));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeStaff()
        {
            cc = new ConnectConfig(Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("ip")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("port")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("userIdStaff")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("passwdStaff")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("dataBase")));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeUser()
        {
            cc = new ConnectConfig(Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("ip")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("port")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("userIdUser")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("passwdUser")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("dataBase")));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeLogin()
        {
            cc = new ConnectConfig(Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("ip")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("port")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("userIdLogin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("passwdLogin")),
                Protection.DESDecrypt(ConfigurationManager.AppSettings.Get("dataBase")));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _loginReposFactory = new LoginReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        #endregion

        #region Вход

        private void EnterLogIn()
        {
            if (_logInValidators.ValidFormNamePass(_login, _pass))
            {
                switch (_logInRequest.GoodUser(_loginReposFactory, _login, _pass))
                {
                    case 0:
                    {
                        LoginLikeAdmin();

                        AdminWinForm admin = new AdminWinForm(_reposFactory);
                        Hide();
                        admin.ShowDialog();
                        Show();

                        LoginLikeLogin();
                        break;
                    }
                    case 1:
                    {
                        LoginLikeStaff();

                        StaffWinForm staff = new StaffWinForm(_reposFactory);
                        Hide();
                        staff.ShowDialog();
                        Show();

                        LoginLikeLogin();
                        break;
                    }
                    case 2:
                    {
                        LoginLikeUser();

                        ClientWinForm client = new ClientWinForm(_reposFactory, Protection.DESEncrypt(_login));
                        Hide();
                        client.ShowDialog();
                        Show();

                        LoginLikeLogin();
                        break;
                    }
                    case 99:
                    {
                        MessageBox.Show(@"Неверно введён логин/пароль");
                        break;
                    }
                    default:
                    {
                        MessageBox.Show(@"Неверно введён логин/пароль");
                        break;
                    }
                }
            }
        }

        #endregion

        private void textBoxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnEnter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterLogIn();
            }
        }
    }
}
