using System;
using System.Windows.Forms;
using ClassRequest;
using Staff.Sided_Form;

namespace Staff
{
    public partial class StaffWinForm : Form
    {
        #region Global Values

        StaffValidators _staffValidators;
        StaffRequest _staffRequest;
        ReposFactory _reposFactory;

        #endregion

        public StaffWinForm(ReposFactory reposFactory)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _staffRequest = new StaffRequest();
            _staffValidators = new StaffValidators();

            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Horizontal;
            dgvHotel.ScrollBars = ScrollBars.Vertical;
        }

        public StaffWinForm()
        {
            InitializeComponent();
        }

        private void StaffWinForm_Load(object sender, EventArgs e)
        {
            // использовать дату из dateTPUser
            if (_staffValidators.ValidUserOutput(dateTPUser))
            {
                _staffRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
            }
            if (_staffValidators.ValidNumOutput(dateTPUser))
            {
                _staffRequest.NumOutput(_reposFactory, dgvNum, dateTPUser);
            }
            _staffRequest.HotelOutput(_reposFactory, dgvHotel);


            if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
            dgvNum.AllowUserToAddRows = false;
            if (dgvHotel.CurrentRow != null) dgvHotel.Rows[dgvHotel.CurrentRow.Index].Selected = false;
            dgvHotel.AllowUserToAddRows = false;

            toolTipAddReq.SetToolTip(btnAddUser, @"Вселить нового гостя");
            toolTipDeleteUser.SetToolTip(btnDeleteUser, @"Досрочно выселить гостя");
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm(_reposFactory);
            addUser.ShowDialog();

            // обновляем таблицу
            if (_staffValidators.ValidUserOutput(dateTPUser))
            {
                _staffRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
            }
            if (_staffValidators.ValidNumOutput(dateTPUser))
            {
                _staffRequest.NumOutput(_reposFactory, dgvNum, dateTPUser);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // удаление это изменение даты выписки на сегоднешнюю
            try
            {
                if (dgvUser.CurrentRow != null)
                {
                    if (_staffValidators.ValidUserDelete(dgvUser.CurrentRow.Index))
                    {
                        _staffRequest.FakedUserDelete(_reposFactory,
                            dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[6].Value.ToString(),
                            dgvUser.Rows[dgvUser.CurrentRow.Index].Cells[4].Value.ToString());
                    }
                }
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось заполнить список!");
                MessageBox.Show("Произошла ошибка на уровне представления");
            }
            finally
            {
                // обновляем таблицу
                if (_staffValidators.ValidUserOutput(dateTPUser))
                {
                    _staffRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
                }
                if (_staffValidators.ValidNumOutput(dateTPUser))
                {
                    _staffRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
                }
            }
        }

        private void dateTPUser_ValueChanged(object sender, EventArgs e)
        {
            if (_staffValidators.ValidUserOutput(dateTPUser))
            {
                _staffRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
            }
        }

        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            if (_staffValidators.ValidNumOutput(dateTPUser))
            {
                _staffRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
            }
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            textBoxHotelNum.Text = string.Empty;
            textBoxHotelNum.Enabled = true;
            textBoxHotelName.Text = string.Empty;
            textBoxHotelName.Enabled = true;
            textBoxHotelOrg.Text = string.Empty;
            textBoxHotelOrg.Enabled = true;
            textBoxHotelC.Text = string.Empty;
            textBoxHotelC.Enabled = true;
            textBoxHotelS.Text = string.Empty;
            textBoxHotelS.Enabled = true;
            maskedTextBoxHotelPhone.Text = string.Empty;
            maskedTextBoxHotelPhone.Enabled = true;
            textBoxHotelClass.Text = string.Empty;
            textBoxHotelClass.Enabled = true;
            textBoxHotelWeb.Text = string.Empty;
            textBoxHotelWeb.Enabled = true;

            //groupBoxStat, labelAllUser, labelNewUser
            groupBoxStat.Text = @"Статистика {empty}";
            labelAllUser.Text = @"0";
            labelNewUser.Text = @"0";


            if (dgvHotel.CurrentRow != null) dgvHotel.Rows[dgvHotel.CurrentRow.Index].Selected = false;
        }

        private void dgvHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHotel.CurrentRow != null && _staffValidators.ValidEnterThirdBox(dgvHotel.CurrentRow.Index))
            {
                textBoxHotelNum.Enabled = false;
                _staffRequest.EnterThirdBox(_reposFactory, textBoxHotelNum, textBoxHotelName, textBoxHotelOrg,
                    textBoxHotelC,
                    textBoxHotelS, maskedTextBoxHotelPhone, textBoxHotelClass, textBoxHotelWeb,
                    dgvHotel, dgvHotel.CurrentRow.Index, groupBoxStat, labelAllUser, labelNewUser);
            }
        }

        private void dgvHotel_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right)
            {
                if (dgvHotel.CurrentRow != null && _staffValidators.ValidEnterThirdBox(dgvHotel.CurrentRow.Index))
                {
                    textBoxHotelNum.Enabled = false;
                    _staffRequest.EnterThirdBox(_reposFactory, textBoxHotelNum, textBoxHotelName, textBoxHotelOrg,
                        textBoxHotelC,
                        textBoxHotelS, maskedTextBoxHotelPhone, textBoxHotelClass, textBoxHotelWeb,
                        dgvHotel, dgvHotel.CurrentRow.Index, groupBoxStat, labelAllUser, labelNewUser);
                }
            }
        }

        private void textBoxHotelNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnUpdateNum_Click_1(object sender, EventArgs e)
        {
            _staffRequest.NumOutputFull(_reposFactory, dgvNum);
            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
        }
    }
}