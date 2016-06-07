using System;
using System.Windows.Forms;
using ClassRequest;

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

        public AddForm(ReposFactory reposFactory, string loginId, string currentApId, string dtpCheckIn, string dtpCheckOut)
        {
            InitializeComponent();
            _clientValidators = new ClientValidators();
            _clientRequest = new ClientRequest();

            _reposFactory = reposFactory;
            _loginId = loginId;
            _currentApId = currentApId;
            this.dtpCheckIn.Text = dtpCheckIn;
            this.dtpCheckOut.Text = dtpCheckOut;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value < DateTime.Now)
            {
                dtpCheckIn.Value = DateTime.Now;
            }
            if (dtpCheckOut.Value < dtpCheckIn.Value)
            {
                dtpCheckOut.Value = dtpCheckIn.Value.AddDays(1);
            }

            if (_clientValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _clientRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
            }
            comboBoxApId.Text = _currentApId;

            dtpCheckIn.MinDate = DateTime.Today;
            dtpCheckIn.MaxDate = DateTime.Today.AddYears(1);
            dtpCheckOut.MinDate = DateTime.Today;
            dtpCheckOut.MaxDate = DateTime.Today.AddYears(2);
        }

        private void AddForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_clientValidators.ValidAddUser(comboBoxApId.Text, dtpCheckIn, dtpCheckOut, textBoxComm))
            {
                _clientRequest.RequestAdd(_reposFactory, _loginId, comboBoxApId.Text, dtpCheckIn, dtpCheckOut,
                    textBoxComm);
                this.Close();
            }
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

            if (_clientValidators.ValidUpdateComboBoxApId(comboBoxApId, dtpCheckIn))
            {
                _clientRequest.UpdateComboBoxApId(_reposFactory, comboBoxApId, dtpCheckIn, dtpCheckOut);
            }

            // обновляет автоматическую статистику в labels
            if (_clientValidators.ValidSelectStatInfo(comboBoxApId.Text, dtpCheckIn, dtpCheckOut, labelRoomT))
            {
                _clientRequest.SelectStatInfo(_reposFactory, comboBoxApId.Text, dtpCheckIn, dtpCheckOut,
                    labelRoomQ, labelRoomT, labelRoomC);
            }
        }

        private void comboBoxApId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // обновляет автоматическую статистику в labels
            if (_clientValidators.ValidSelectStatInfo(comboBoxApId.Text, dtpCheckIn, dtpCheckOut, labelRoomT))
            {
                _clientRequest.SelectStatInfo(_reposFactory, comboBoxApId.Text, dtpCheckIn, dtpCheckOut,
                    labelRoomQ, labelRoomT, labelRoomC);
            }
        }

        private void comboBoxApId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}