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
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Configuration;
using Admin;
using ClassRequest;
using ClassRequest.Login;
using WMPLib;
using Npgsql;
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
            cc = new ConnectConfig(Protection.Decrypt(ConfigurationManager.AppSettings.Get("ip"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("port"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("userIdAdmin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("passwdAdmin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("dataBase"), "VEM"));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeStaff()
        {
            cc = new ConnectConfig(Protection.Decrypt(ConfigurationManager.AppSettings.Get("ip"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("port"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("userIdStaff"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("passwdStaff"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("dataBase"), "VEM"));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeUser()
        {
            cc = new ConnectConfig(Protection.Decrypt(ConfigurationManager.AppSettings.Get("ip"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("port"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("userIdUser"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("passwdUser"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("dataBase"), "VEM"));
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
            _reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);
        }

        private void LoginLikeLogin()
        {
            cc = new ConnectConfig(Protection.Decrypt(ConfigurationManager.AppSettings.Get("ip"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("port"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("userIdLogin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("passwdLogin"), "VEM"),
                Protection.Decrypt(ConfigurationManager.AppSettings.Get("dataBase"), "VEM"));
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

                        ClientWinForm client = new ClientWinForm(_reposFactory, Protection.Encrypt(_login, "VEM"));
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
