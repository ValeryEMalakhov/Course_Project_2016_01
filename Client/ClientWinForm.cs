using System;
using System.Windows.Forms;
using ClassRequest;
using Client.Sided_Form;

namespace Client
{
    public partial class ClientWinForm : Form
    {
        #region Global Values

        ReposFactory _reposFactory;
        ClientRequest _clientRequest;
        ClientValidators _clientValidators;

        private string _clientId;
        private string _loginId;

        #endregion

        public ClientWinForm(ReposFactory reposFactory, string loginId)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _clientRequest = new ClientRequest();
            _clientValidators = new ClientValidators();

            _loginId = loginId;
            _clientId = _clientRequest.GetId(_reposFactory, _loginId);

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
            if (_clientValidators.ValidNumOutput(dtpCheckIn))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
            }
            if (_clientValidators.ValidLogOutput(_clientId))
            {
                _clientRequest.LogOutput(_reposFactory, dgvLog, _clientId);
            }
            if (_clientValidators.ValidNowOutput(_clientId))
            {
                _clientRequest.NowOutput(_reposFactory, dgvNow, _clientId);
            }

            //toolTipUserEdit.ToolTipIcon = ToolTipIcon.Info;
            toolTipUserEdit.SetToolTip(btnEditRequest, @"Редактировать профиль пользователя");
            toolTipDeleteRequest.SetToolTip(btnDeleteRequest, @"Удалить бронь");

            _clientRequest.InputGroupBoxName(_reposFactory, _clientId, groupBoxUserInfo);
            _clientRequest.InputHotelName(_reposFactory, lLabelHotelName, labelHotelPhone);

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;
        }

        private void ClientWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            // кнопка мертва
            if (_clientValidators.ValidNumOutput(dtpCheckIn))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
            }
        }

        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value < DateTime.Now)
            {
                dtpCheckIn.Value = DateTime.Now;
            }
            if (dtpCheckOut.Value < dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            if (_clientValidators.ValidNumOutput(dtpCheckIn))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
            }
        }

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            if (dgvNum.CurrentRow != null)
            {
                AddForm addUser = new AddForm(_reposFactory, _clientId, dgvNum.Rows[dgvNum.CurrentRow.Index].Cells[0].Value.ToString(),
                    dtpCheckIn.Text, dtpCheckOut.Text);
                addUser.ShowDialog();
            }

            _clientRequest.InputGroupBoxName(_reposFactory, _clientId, groupBoxUserInfo);
            _clientRequest.InputHotelName(_reposFactory, lLabelHotelName, labelHotelPhone);

            dtpCheckIn.Value = DateTime.Today;
            dtpCheckOut.Value = DateTime.Today;
            // обновляем таблицу
            if (_clientValidators.ValidNumOutput(dtpCheckIn))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
            }
            if (_clientValidators.ValidLogOutput(_clientId))
            {
                _clientRequest.LogOutput(_reposFactory, dgvLog, _clientId);
            }
            if (_clientValidators.ValidNowOutput(_clientId))
            {
                _clientRequest.NowOutput(_reposFactory, dgvNow, _clientId);
            }
        }

        private void btnDeleteRequest_Click(object sender, EventArgs e)
        {
            // удаление
            try
            {
                if (dgvNow.CurrentRow != null)
                {
                    if (_clientValidators.ValidDelete(_clientId, dgvNow.CurrentRow.Index))
                    {
                        _clientRequest.RequestDelete(_reposFactory, _clientId, dgvNow.Rows[dgvNow.CurrentRow.Index].Cells[0].Value.ToString(), dgvNow.Rows[dgvNow.CurrentRow.Index].Cells[1].Value.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось удалить запрос!");
                MessageBox.Show("Произошла ошибка на уровне представления");
            }
            finally
            {
                // обновляем таблицу
                if (_clientValidators.ValidNumOutput(dtpCheckIn))
                {
                    _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
                }
                if (_clientValidators.ValidLogOutput(_clientId))
                {
                    _clientRequest.LogOutput(_reposFactory, dgvLog, _clientId);
                }
                if (_clientValidators.ValidNowOutput(_clientId))
                {
                    _clientRequest.NowOutput(_reposFactory, dgvNow, _clientId);
                }
            }
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            if (_clientId != null)
            {
                EditRequestForm editRequestForm = new EditRequestForm(_reposFactory, _clientId, _loginId);
                editRequestForm.ShowDialog();
            }

            _clientRequest.InputGroupBoxName(_reposFactory, _clientId, groupBoxUserInfo);
            _clientRequest.InputHotelName(_reposFactory, lLabelHotelName, labelHotelPhone);

            // обновляем таблицу
            if (_clientValidators.ValidNumOutput(dtpCheckIn))
            {
                _clientRequest.NumOutput(_reposFactory, dgvNum, dtpCheckIn, dtpCheckOut);
            }
            if (_clientValidators.ValidLogOutput(_clientId))
            {
                _clientRequest.LogOutput(_reposFactory, dgvLog, _clientId);
            }
            if (_clientValidators.ValidNowOutput(_clientId))
            {
                _clientRequest.NowOutput(_reposFactory, dgvNow, _clientId);
            }
        }

        private void lLabelHotelName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _clientRequest.OpenLink(_reposFactory, lLabelHotelName);
        }
    }
}
