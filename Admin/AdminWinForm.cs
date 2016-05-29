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
using Admin.Sided_Form;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;

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
            dgvNum.ScrollBars = ScrollBars.Horizontal;
            dgvNumClass.ScrollBars = ScrollBars.Horizontal;
        }

        public AdminWinForm()
        {
            InitializeComponent();
        }

        private void AdminWinForm_Load(object sender, EventArgs e)
        {
            _adminRequest.UserOutputFull(_reposFactory, dgvUser);
            _adminRequest.NumOutputFull(_reposFactory, dgvNum);
            if (_adminValidators.ValidNumCostOutput())
            {
                _adminRequest.NumCostOutput(_reposFactory, dgvNumClass);
            }


            if (dgvUser.CurrentRow != null) dgvUser.Rows[dgvUser.CurrentRow.Index].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
            dgvNum.AllowUserToAddRows = false;
            if (dgvNumClass.CurrentRow != null) dgvNumClass.Rows[dgvNumClass.CurrentRow.Index].Selected = false;
            dgvNumClass.AllowUserToAddRows = false;
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
                MessageBox.Show(Convert.ToString(exp));
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
    }
}