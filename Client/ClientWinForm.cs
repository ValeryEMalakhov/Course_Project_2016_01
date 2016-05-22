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

namespace Client
{
    public partial class ClientWinForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        ClientRequest _clientRequest;
        ClientValidators _clientValidators;

        private string _loginId;

        #endregion

        public ClientWinForm(ReposFactory reposFactory, string loginId)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _clientRequest = new ClientRequest();
            _clientValidators = new ClientValidators();

            _loginId = loginId;

            dgvNum.ScrollBars = ScrollBars.Horizontal;
            dgvLog.ScrollBars = ScrollBars.Horizontal;
            dgvNow.ScrollBars = ScrollBars.Horizontal;

            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
            dgvLog.Rows[0].Selected = false;
            dgvLog.AllowUserToAddRows = false;
            dgvNow.Rows[0].Selected = false;
            dgvNow.AllowUserToAddRows = false;

        }
        public ClientWinForm()
        {
            InitializeComponent();
        }

        private void ClientWinForm_Load(object sender, EventArgs e)
        {
            if (_clientValidators.ValidNumOutput(dateTPNum))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
            }
            if (_clientValidators.ValidLogOutput(_loginId))
            {
                _clientRequest.LogOutput(_reposFactory, dgvLog, _loginId);
            }
            if (_clientValidators.ValidNowOutput(_loginId))
            {
                _clientRequest.NowOutput(_reposFactory, dgvNow, _loginId);
            }
        }

        private void ClientWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            // кнопка мертва
            if (_clientValidators.ValidNumOutput(dateTPNum))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
            }
        }

        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            if (_clientValidators.ValidNumOutput(dateTPNum))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
            }
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            // удаление
            try
            {
                if (dgvNow.CurrentRow != null)
                {
                    if (_clientValidators.ValidDelete(_loginId, dgvNow.CurrentRow.Index))
                    {
                        _clientRequest.RequestDelete(_reposFactory, _loginId, dgvNow.Rows[dgvNow.CurrentRow.Index].Cells[0].Value.ToString(), dgvNow.Rows[dgvNow.CurrentRow.Index].Cells[1].Value.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось удалить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // обновляем таблицу
                if (_clientValidators.ValidNumOutput(dateTPNum))
                {
                    _clientRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
                }
                if (_clientValidators.ValidLogOutput(_loginId))
                {
                    _clientRequest.LogOutput(_reposFactory, dgvLog, _loginId);
                }
                if (_clientValidators.ValidNowOutput(_loginId))
                {
                    _clientRequest.NowOutput(_reposFactory, dgvNow, _loginId);
                }
            }
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
