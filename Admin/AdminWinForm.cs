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

            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
            dgvNumClass.Rows[0].Selected = false;
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
            //AddUserForm addUser = new AddUserForm(_reposFactory);
            //addUser.ShowDialog();

            //// обновляем таблицу
            //if (_adminValidators.ValidUserOutput(dateTPUser))
            //{
            //    _adminRequest.UserOutput(_reposFactory, dgvUser, dateTPUser);
            //}
            //if (_adminValidators.ValidNumOutput(dateTPUser))
            //{
            //    _adminRequest.NumOutput(_reposFactory, dgvNum, dateTPUser);
            //}
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
            }
        }

        private void dgvNumClass_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNumClass.CurrentRow != null && _adminValidators.ValidEnterSecondBox(dgvNumClass.CurrentRow.Index))
            {
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
                    _adminRequest.EnterSecondBox(textBoxClass, textBoxClassCost, dgvNumClass,
                        dgvNumClass.CurrentRow.Index);
                }
            }
        }

        private void dgvNum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNum.CurrentRow != null && _adminValidators.ValidEnterFirstBox(dgvNum.CurrentRow.Index))
            {
                _adminRequest.EnterFirstBox(textBoxNum, textBoxPlace, textBoxNumClass, textBoxNumCost, dgvNum,
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
                    _adminRequest.EnterFirstBox(textBoxNum, textBoxPlace, textBoxNumClass, textBoxNumCost, dgvNum,
                        dgvNum.CurrentRow.Index);
                }
            }
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            textBoxNum.Text = string.Empty;
            textBoxPlace.Text = string.Empty;
            textBoxNumClass.Text = string.Empty;
            textBoxNumCost.Text = string.Empty;

            if (dgvNum.CurrentRow != null) dgvNum.Rows[dgvNum.CurrentRow.Index].Selected = false;
        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            textBoxClass.Text = string.Empty;
            textBoxClassCost.Text = string.Empty;

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
    }
}
