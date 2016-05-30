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
    public partial class WfLogin : Form
    {
        private LoginReposFactory _loginReposFactory;
        private ReposFactory _reposFactory;

        private LogInValidators _logInValidators;
        private LogInRequest _logInRequest;

        private ConnectConfig cc;
        private string _loginName;
        private string _loginPass;

        public WfLogin(LoginReposFactory loginReposFactory)
        {
            InitializeComponent();
            _loginReposFactory = loginReposFactory;

            _logInValidators = new LogInValidators();
            _logInRequest = new LogInRequest();

            //string str1 = Convert.ToString(Protection.Encrypt("admin", "VEM"));
            //string str2 = Convert.ToString(Protection.Encrypt("1507", "VEM"));
            //string str3 = Convert.ToString(Protection.Encrypt("A", "VEM"));

            //string str4 = Convert.ToString(Protection.Encrypt("staff", "VEM"));
            //string str5 = Convert.ToString(Protection.Encrypt("1111", "VEM"));
            //string str6 = Convert.ToString(Protection.Encrypt("S", "VEM"));
        }

        public WfLogin()
        {
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (label.Left > -label.Width)
            {
                label.Left -= 2;
            }
            else
            {
                label.Left = panel.Width;
            }
        }

        private void WfLogin_Load(object sender, EventArgs e)
        {
            timer.Start();

        }

        private void WfLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            _reposFactory?.Dispose();
            _loginReposFactory?.Dispose();
        }

        private void btnLoginLikeAdmin_Click(object sender, EventArgs e)
        {
            _loginName = "admin";
            _loginPass = "1507";

            EnterLogIn();
        }

        private void btnLoginLikeStaff_Click(object sender, EventArgs e)
        {
            _loginName = "staff";
            _loginPass = "1111";

            EnterLogIn();
        }

        private void btnLoginLikeUser_Click(object sender, EventArgs e)
        {
            LoginLikeUser();

            ClientWinForm client = new ClientWinForm(_reposFactory, textBoxLoginId.Text);
            Hide();
            client.ShowDialog();
            Show();

            LoginLikeLogin();
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
            if (_logInValidators.ValidFormNamePass(_loginName, _loginPass))
            {
                if (_logInRequest.GoodUser(_loginReposFactory, _loginName, _loginPass) == 0)
                {
                    LoginLikeAdmin();

                    AdminWinForm admin = new AdminWinForm(_reposFactory);
                    Hide();
                    admin.ShowDialog();
                    Show();

                    LoginLikeLogin();
                }
                if (_logInRequest.GoodUser(_loginReposFactory, _loginName, _loginPass) == 1)
                {
                    LoginLikeStaff();

                    StaffWinForm staff = new StaffWinForm(_reposFactory);
                    Hide();
                    staff.ShowDialog();
                    Show();

                    LoginLikeLogin();
                }
                if (_logInRequest.GoodUser(_loginReposFactory, _loginName, _loginPass) == 2)
                {
                    LoginLikeUser();

                    ClientWinForm client = new ClientWinForm(_reposFactory, textBoxLoginId.Text);
                    Hide();
                    client.ShowDialog();
                    Show();

                    LoginLikeLogin();
                }
                if (_logInRequest.GoodUser(_loginReposFactory, _loginName, _loginPass) == 99)
                {
                    MessageBox.Show(@"Неверно введён логин/пароль");

                }
            }
        }

        #endregion
    }
}