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
            groupBoxInfo.Enabled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            testEnter();
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_logInValidators.ValidAddUser(textBoxPass, textBoxCodeID, textBoxFirstName, textBoxSecondName,
                comboBoxGender, dtpBirth, textBoxPhone))
            {
                _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                    textBoxFirstName, textBoxSecondName,
                    comboBoxGender, dtpBirth, textBoxPhone);
                this.Close();
            }
        }

        private void testEnter()
        {
            textBoxPass.Text = "1100";
            textBoxCodeID.Text = "1100";
            textBoxCodeID.Text = "1100";
            textBoxFirstName.Text = "1100";
            textBoxSecondName.Text = "1100";
            comboBoxGender.Text = "1100";
            dtpBirth.Text = "1100";
            textBoxPhone.Text = "1100";
            _logInRequest.AddUserFirstPart(_loginReposFactory, textBoxID, textBoxPass, textBoxCodeID,
                textBoxFirstName, textBoxSecondName,
                comboBoxGender, dtpBirth, textBoxPhone);

            _logInRequest.GiveUser(_loginReposFactory, textBoxID);

        }
    }
}