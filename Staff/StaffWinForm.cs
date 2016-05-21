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

            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false; 
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

            dgvUser.Rows[0].Selected = false;
            dgvUser.AllowUserToAddRows = false;
            dgvNum.Rows[0].Selected = false;
            dgvNum.AllowUserToAddRows = false;
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
                        _staffRequest.FakedUserDelete(_reposFactory, dgvUser.CurrentRow.Index);
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
    }
}
