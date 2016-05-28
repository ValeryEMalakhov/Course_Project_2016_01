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
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;
using Client.Sided_Form;

namespace Client.Sided_Form
{
    public partial class EditRequestForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        ClientRequest _clientRequest;
        ClientValidators _clientValidators;

        private string _loginId;

        #endregion

        // заглушка
        public EditRequestForm()
        {
            InitializeComponent();
        }

        public EditRequestForm(ReposFactory reposFactory, string loginId)
        {
            InitializeComponent();
            _clientValidators = new ClientValidators();
            _clientRequest = new ClientRequest();

            _reposFactory = reposFactory;
            _loginId = loginId;
        }

        private void EditRequestForm_Load(object sender, EventArgs e)
        {
            textBoxPass.Text = _loginId;

            if (textBoxPass.Text != string.Empty)
            {
                if (_clientValidators.ValidInputAllClientFields(textBoxPass, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone))
                {
                    _clientRequest.InputAllClientFields(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone);
                }
            }
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
                dtpBirth, textBoxPhone))
            {
                _clientRequest.UserEdit(_reposFactory, textBoxPass.Text, textBoxFirstName,
                    textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Временно недоступно");
        }

        private void EditRequestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_clientValidators.ValidUpdateUser(textBoxPass, textBoxFirstName, textBoxSecondName, comboBoxGender,
                    dtpBirth, textBoxPhone))
                {
                    _clientRequest.UserEdit(_reposFactory, textBoxPass.Text, textBoxFirstName,
                        textBoxSecondName, comboBoxGender, dtpBirth, textBoxPhone);
                }
            }
        }
    }
}
