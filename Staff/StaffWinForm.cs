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
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;
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
        }

        private void StaffWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            // Эта кнопка мертва
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

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            // Эта кнопка мертва тоже
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
                MessageBox.Show(Convert.ToString(exp));
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
    }
}