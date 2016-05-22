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

namespace Client.Sided_Form
{
    public partial class AddForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        ClientRequest _clientRequest;
        ClientValidators _clientValidators;

        private string _loginId;
        private string _currentApId;

        #endregion


        // заглушка
        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(ReposFactory reposFactory, string loginId, string currentApId)
        {
            InitializeComponent();
            _clientValidators = new ClientValidators();
            _clientRequest = new ClientRequest();

            _reposFactory = reposFactory;
            _loginId = loginId;
            _currentApId = currentApId;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;
        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_clientValidators.ValidAddUser(_currentApId, dtpCheckIn, dtpCheckOut, textBoxComm))
            {
                _clientRequest.RequestAdd(_reposFactory, _loginId, _currentApId, dtpCheckIn, dtpCheckOut, textBoxComm);
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

            // обновляет автоматическую статистику в labels
            if (_clientValidators.ValidSelectStatInfo(_currentApId, dtpCheckIn, dtpCheckOut, labelRoomT))
            {
                _clientRequest.SelectStatInfo(_reposFactory, _currentApId, dtpCheckIn, dtpCheckOut, labelRoomN,
                    labelRoomQ, labelRoomT, labelRoomC);
            }
        }
    }
}