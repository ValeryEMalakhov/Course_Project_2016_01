using System;
using System.Windows.Forms;
using Admin.Sided_Form;
using ClassRequest;

namespace Admin
{
    public partial class AdminWinForm : Form
    {
        #region Global Values

        AdminValidators _adminValidators;
        AdminRequest _adminRequest;
        ReposFactory _reposFactory;

        #endregion

        public AdminWinForm(ReposFactory reposFactory)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _adminRequest = new AdminRequest();
            _adminValidators = new AdminValidators();

            dgvUser.ScrollBars = ScrollBars.Both;
            dgvNum.ScrollBars = ScrollBars.Vertical;
            dgvNumClass.ScrollBars = ScrollBars.Vertical;
            dgvHotel.ScrollBars = ScrollBars.Vertical;
            dgvStaff.ScrollBars = ScrollBars.Vertical;
            dgvStaffPosition.ScrollBars = ScrollBars.Vertical;
            dgvClientAll.ScrollBars = ScrollBars.Vertical;
        }

        public AdminWinForm()
        {
            InitializeComponent();
        }

        private void AdminWinForm_Load(object sender, EventArgs e)
        {
            _adminRequest.UserOutputFull(_reposFactory, dgvUser);
            _adminRequest.NumOutputFull(_reposFactory, dgvNum);
            _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);
            _adminRequest.HotelOutput(_reposFactory, dgvHotel);
            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            _adminRequest.StaffPositionOutput(_reposFactory, dgvStaffPosition);
            _adminRequest.ClientAllOutput(_reposFactory, dgvClientAll);

            if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
            dgvNum.AllowUserToAddRows = false;
            if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            dgvNumClass.AllowUserToAddRows = false;
            if (dgvHotel.CurrentRow != null) dgvHotel.Rows[dgvHotel.CurrentRow.Index].Selected = false;
            dgvHotel.AllowUserToAddRows = false;
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
            dgvStaff.AllowUserToAddRows = false;
            if (dgvStaffPosition.CurrentRow != null)
                dgvStaffPosition.Rows[dgvStaffPosition.CurrentRow.Index].Selected = false;
            dgvStaffPosition.AllowUserToAddRows = false;
            if (dgvClientAll.CurrentRow != null) dgvClientAll.Rows[dgvClientAll.CurrentRow.Index].Selected = false;
            dgvClientAll.AllowUserToAddRows = false;

            dtpStaffBirth.MinDate = DateTime.Today.AddYears(-100);
            dtpStaffBirth.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void AdminWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            _adminRequest.UserOutputFull(_reposFactory, dgvUser);
            if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm addUser = new AddUserForm(_reposFactory);
            addUser.ShowDialog();

            // обновляем таблицу
            if (_adminValidators.ValidUserOutput(dateTPUser))
            {
                _adminRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
            }
            if (_adminValidators.ValidNumOutput(dateTPUser))
            {
                _adminRequest.NumOutput(_reposFactory, dgvNum, dateTPUser);
            }
            _adminRequest.ClientAllOutput(_reposFactory, dgvClientAll);
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            _adminRequest.NumOutputFull(_reposFactory, dgvNum);
            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // удаление это изменение даты выписки на сегоднешнюю
            try
            {
                if (dgvUser.CurrentRow != null)
                {
                    if (_adminValidators.ValidUserDelete(dgvUser.CurrentRow.Index))
                    {
                        _adminRequest.FakedUserDelete(_reposFactory,
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
                if (_adminValidators.ValidUserOutput(dateTPUser))
                {
                    _adminRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
                    if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
                }
                if (_adminValidators.ValidNumOutput(dateTPUser))
                {
                    _adminRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
                    if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                }
            }
        }

        private void dateTPUser_ValueChanged(object sender, EventArgs e)
        {
            if (_adminValidators.ValidUserOutput(dateTPUser))
            {
                _adminRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
                if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
            }
        }

        private void dateTPNum_ValueChanged(object sender, EventArgs e)
        {
            if (_adminValidators.ValidNumOutput(dateTPUser))
            {
                _adminRequest.NumOutput(_reposFactory, dgvNum, dateTPNum);
                if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
            }
        }

        private void dgvNumClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNumClass.CurrentRow != null && _adminValidators.ValidEnterSecondBox(dgvNumClass.CurrentRow.Index))
            {
                textBoxClass.Enabled = false;
                _adminRequest.EnterSecondBox(textBoxClass, textBoxClassCost, dgvNumClass, dgvNumClass.CurrentRow.Index);
            }
        }

        private void dgvNumClass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right)
            {
                if (dgvNumClass.CurrentRow != null && _adminValidators.ValidEnterSecondBox(dgvNumClass.CurrentRow.Index))
                {
                    textBoxClass.Enabled = false;
                    _adminRequest.EnterSecondBox(textBoxClass, textBoxClassCost, dgvNumClass,
                        dgvNumClass.CurrentRow.Index);
                }
            }
        }

        private void dgvNum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNum.CurrentRow != null && _adminValidators.ValidEnterFirstBox(dgvNum.CurrentRow.Index))
            {
                textBoxNum.Enabled = false;
                _adminRequest.EnterFirstBox(textBoxNum, textBoxNumHotel, textBoxPlace, textBoxNumClass, dgvNum,
                    dgvNum.CurrentRow.Index);
            }
        }

        private void dgvNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right)
            {
                if (dgvNum.CurrentRow != null && _adminValidators.ValidEnterFirstBox(dgvNum.CurrentRow.Index))
                {
                    textBoxNum.Enabled = false;
                    _adminRequest.EnterFirstBox(textBoxNum, textBoxNumHotel, textBoxPlace, textBoxNumClass, dgvNum,
                        dgvNum.CurrentRow.Index);
                }
            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            textBoxNum.Text = string.Empty;
            textBoxNum.Enabled = true;
            textBoxNumHotel.Text = string.Empty;
            textBoxNumHotel.Enabled = true;
            textBoxPlace.Text = string.Empty;
            textBoxPlace.Enabled = true;
            textBoxNumClass.Text = string.Empty;
            textBoxNumClass.Enabled = true;

            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            textBoxClass.Text = string.Empty;
            textBoxClass.Enabled = true;
            textBoxClassCost.Text = string.Empty;
            textBoxClassCost.Enabled = true;

            if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
        }

        private void btnEditClass_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidEditSecondBox(textBoxClass.Text, textBoxClassCost.Text))
            {
                _adminRequest.EditSecondBox(_reposFactory, textBoxClass, textBoxClassCost);

                _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);

                if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            }
        }

        private void textBoxClassCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_adminValidators.ValidEditSecondBox(textBoxClass.Text, textBoxClassCost.Text))
                {
                    _adminRequest.EditSecondBox(_reposFactory, textBoxClass, textBoxClassCost);

                    _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                    _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                    _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);

                    if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                    if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
                }
            }
        }

        private void btnEditNum_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidEditFirstBox(textBoxNum.Text, textBoxNumHotel.Text, textBoxPlace.Text,
                textBoxNumClass.Text))
            {
                _adminRequest.EditFirstBox(_reposFactory, textBoxNum, textBoxNumHotel, textBoxPlace,
                    textBoxNumClass);

                _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);

                if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            }
        }

        private void btnDeleteNum_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidDeleteFirstBox(textBoxNum.Text, textBoxNumHotel.Text, textBoxPlace.Text,
                textBoxNumClass.Text))
            {
                _adminRequest.DeleteFirstBox(_reposFactory, textBoxNum, textBoxNumHotel, textBoxPlace,
                    textBoxNumClass);

                _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);

                if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            }
        }

        private void btnAddNum_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidAddFirstBox(textBoxNum.Text, textBoxNumHotel.Text, textBoxPlace.Text,
                textBoxNumClass.Text, dgvNum))
            {
                _adminRequest.AddFirstBox(_reposFactory, textBoxNum, textBoxNumHotel, textBoxPlace,
                    textBoxNumClass);

                _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);

                if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
                if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            }
        }

        private void btnClear3_Click(object sender, EventArgs e)
        {
            textBoxHotelNum.Text = string.Empty;
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

        private void btnAddHotel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Постройка отелей временно недоступна");
            //
        }

        private void btnEditHotel_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidEditThirdBox(textBoxHotelNum.Text, textBoxHotelName.Text, textBoxHotelOrg.Text,
                textBoxHotelC.Text,
                textBoxHotelS.Text, maskedTextBoxHotelPhone, textBoxHotelClass.Text, textBoxHotelWeb.Text))
            {
                _adminRequest.EditThirdBox(_reposFactory, textBoxHotelNum, textBoxHotelName, textBoxHotelOrg,
                    textBoxHotelC,
                    textBoxHotelS, maskedTextBoxHotelPhone, textBoxHotelClass, textBoxHotelWeb);

                _adminRequest.UserOutputFull(_reposFactory, dgvUser);
                _adminRequest.NumOutputFull(_reposFactory, dgvNum);
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);
                _adminRequest.HotelOutput(_reposFactory, dgvHotel);

                _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);

                //groupBoxStat, labelAllUser, labelNewUser
                groupBoxStat.Text = @"Статистика {empty}";
                labelAllUser.Text = @"0";
                labelNewUser.Text = @"0";

                if (dgvHotel.CurrentRow != null) dgvHotel.Rows[dgvHotel.CurrentRow.Index].Selected = false;
            }
        }

        private void dgvHotel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHotel.CurrentRow != null && _adminValidators.ValidEnterThirdBox(dgvHotel.CurrentRow.Index))
            {
                textBoxHotelNum.Enabled = false;
                _adminRequest.EnterThirdBox(_reposFactory, textBoxHotelNum, textBoxHotelName, textBoxHotelOrg,
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
                if (dgvHotel.CurrentRow != null && _adminValidators.ValidEnterThirdBox(dgvHotel.CurrentRow.Index))
                {
                    textBoxHotelNum.Enabled = false;
                    _adminRequest.EnterThirdBox(_reposFactory, textBoxHotelNum, textBoxHotelName, textBoxHotelOrg,
                        textBoxHotelC,
                        textBoxHotelS, maskedTextBoxHotelPhone, textBoxHotelClass, textBoxHotelWeb,
                        dgvHotel, dgvHotel.CurrentRow.Index, groupBoxStat, labelAllUser, labelNewUser);
                }
            }
        }

        private void textBoxNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStaff.CurrentRow != null && _adminValidators.ValidEnterStaffBox(dgvStaff.CurrentRow.Index))
            {
                textBoxStaffId.Enabled = false;
                _adminRequest.EnterStaffBox(_reposFactory, textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                    comboBoxStaffGender, dtpStaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel,
                    dgvStaff, dgvStaff.CurrentRow.Index);
            }
        }

        private void dgvStaff_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right)
            {
                if (dgvStaff.CurrentRow != null && _adminValidators.ValidEnterStaffBox(dgvStaff.CurrentRow.Index))
                {
                    textBoxStaffId.Enabled = false;
                    _adminRequest.EnterStaffBox(_reposFactory, textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                        comboBoxStaffGender, dtpStaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel,
                        dgvStaff, dgvStaff.CurrentRow.Index);
                }
            }
        }

        private void textBoxStaffName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClearFieldsStaff_Click(object sender, EventArgs e)
        {
            textBoxStaffId.Text = string.Empty;
            textBoxStaffName.Text = string.Empty;
            textBoxStaffName.Enabled = true;
            textBoxStaffSirName.Text = string.Empty;
            textBoxStaffSirName.Enabled = true;
            comboBoxStaffGender.Text = string.Empty;
            comboBoxStaffGender.Enabled = true;
            comboBoxSvacant.Text = string.Empty;
            comboBoxSvacant.Enabled = true;
            comboBoxLeader.Text = string.Empty;
            comboBoxLeader.Enabled = true;
            comboBoxStaffHotel.Text = string.Empty;
            comboBoxStaffHotel.Enabled = true;

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidEditStaff(textBoxStaffId.Text, textBoxStaffName.Text, textBoxStaffSirName.Text,
                comboBoxStaffGender.Text, dtpStaffBirth.Text, comboBoxSvacant.Text, comboBoxLeader.Text,
                comboBoxStaffHotel.Text))
            {
                _adminRequest.EditStaffBox(_reposFactory, textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                    comboBoxStaffGender, dtpStaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            }

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            //textBoxStaffId.Text = string.Empty;
            if (_adminValidators.ValidAddStaff(textBoxStaffId.Text, textBoxStaffName.Text, textBoxStaffSirName.Text,
                comboBoxStaffGender.Text, dtpStaffBirth.Text, comboBoxSvacant.Text, comboBoxLeader.Text,
                comboBoxStaffHotel.Text))
            {
                _adminRequest.AddStaff(_reposFactory, textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                    comboBoxStaffGender, dtpStaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            }

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidDeleteStaff(textBoxStaffId.Text))
            {
                _adminRequest.DeleteStaff(_reposFactory, textBoxStaffId, textBoxStaffName, textBoxStaffSirName,
                    comboBoxStaffGender, dtpStaffBirth, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            }

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void btnClearFieldsVacant_Click(object sender, EventArgs e)
        {
            textBoxSvacantId.Text = string.Empty;
            textBoxSvacantId.Enabled = true;
            textBoxSvacantName.Text = string.Empty;
            textBoxSvacantName.Enabled = true;
            textBoxSvacantPay.Text = string.Empty;
            textBoxSvacantPay.Enabled = true;

            _adminRequest.StaffPositionOutput(_reposFactory, dgvStaffPosition);
            if (dgvStaffPosition.CurrentRow != null)
                dgvStaffPosition.Rows[dgvStaffPosition.CurrentRow.Index].Selected = false;
        }

        private void btnEditVacant_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidVacant(textBoxSvacantId.Text, textBoxSvacantName.Text, textBoxSvacantPay.Text))
            {
                _adminRequest.EditStaffBoxVacant(_reposFactory, textBoxSvacantId, textBoxSvacantName,  textBoxSvacantPay);

            }

            _adminRequest.StaffPositionOutput(_reposFactory, dgvStaffPosition);
            if (dgvStaffPosition.CurrentRow != null)
                dgvStaffPosition.Rows[dgvStaffPosition.CurrentRow.Index].Selected = false;

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void btnAddVacant_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidVacant(textBoxSvacantId.Text, textBoxSvacantName.Text, textBoxSvacantPay.Text))
            {
                _adminRequest.AddStaffVacant(_reposFactory, textBoxSvacantId, textBoxSvacantName, textBoxSvacantPay);
            }

            _adminRequest.StaffPositionOutput(_reposFactory, dgvStaffPosition);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaffPosition.CurrentRow != null)
                dgvStaffPosition.Rows[dgvStaffPosition.CurrentRow.Index].Selected = false;
        }

        private void btnDeleteVacant_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidVacant(textBoxSvacantId.Text, textBoxSvacantName.Text, textBoxSvacantPay.Text))
            {
                _adminRequest.DeleteStaffVacant(_reposFactory, textBoxSvacantId, textBoxSvacantName, textBoxSvacantPay);
            }

            _adminRequest.StaffPositionOutput(_reposFactory, dgvStaffPosition);
            if (dgvStaffPosition.CurrentRow != null)
                dgvStaffPosition.Rows[dgvStaffPosition.CurrentRow.Index].Selected = false;

            _adminRequest.StaffOutput(_reposFactory, dgvStaff);
            _adminRequest.UpdateComboBoxes(_reposFactory, comboBoxSvacant, comboBoxLeader, comboBoxStaffHotel);
            if (dgvStaff.CurrentRow != null) dgvStaff.Rows[dgvStaff.CurrentRow.Index].Selected = false;
        }

        private void dgvStaffPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStaffPosition.CurrentRow != null &&
                _adminValidators.ValidEnterVacantBox(dgvStaffPosition.CurrentRow.Index))
            {
                textBoxSvacantId.Enabled = false;
                _adminRequest.EnterVacantBox(textBoxSvacantId, textBoxSvacantName, textBoxSvacantPay, dgvStaffPosition,
                    dgvStaffPosition.CurrentRow.Index);
            }
        }

        private void dgvStaffPosition_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Right)
            {
                if (dgvStaffPosition.CurrentRow != null &&
                    _adminValidators.ValidEnterVacantBox(dgvStaffPosition.CurrentRow.Index))
                {
                    textBoxSvacantId.Enabled = false;
                    _adminRequest.EnterVacantBox(textBoxSvacantId, textBoxSvacantName, textBoxSvacantPay,
                        dgvStaffPosition,
                        dgvStaffPosition.CurrentRow.Index);
                }
            }
        }

        private void textBoxSvacantPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsPunctuation((e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnLogInOk_Click(object sender, EventArgs e)
        {
            if (_adminValidators.ValidEditNewPass(textBoxNewAdminPass.Text, textBoxNewStaffPass.Text))
            {
                _adminRequest.EditNewPass(_reposFactory, textBoxNewAdminPass.Text, textBoxNewStaffPass.Text);
                textBoxNewAdminPass.Text = string.Empty;
                textBoxNewStaffPass.Text = string.Empty;
            }
        }

        private void comboBoxStaffGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}