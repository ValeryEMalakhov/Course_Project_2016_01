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

namespace Admin.Sided_Form
{
    public partial class DeleteNumForm : Form
    {

        #region Global Values

        AdminValidators _adminValidators;
        AdminRequest _adminRequest;
        ReposFactory _reposFactory;

        private TextBox _textBoxNum;
        private TextBox _textBoxNumHotel;
        private TextBox _textBoxPlace;
        private TextBox _textBoxNumClass;

        #endregion


        public DeleteNumForm(ReposFactory reposFactory, bool keyNew, TextBox textBoxNum, TextBox textBoxNumHotel,
            TextBox textBoxPlace, TextBox textBoxNumClass)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _adminRequest = new AdminRequest();
            _adminValidators = new AdminValidators();

            if (keyNew)
            {
                labelInfo.Text = @"Номер уже кем-то забронирован! 
Для удаления снимите бронь";
                btnYes.Enabled = false;
            }
            else
            {
                labelInfo.Text = @"Номер уже был когда-то забронирован!
Удаление номера удалит и записи в журнале!";
                _textBoxNum = textBoxNum;
                _textBoxNumHotel = textBoxNumHotel;
                _textBoxPlace = textBoxPlace;
                _textBoxNumClass = textBoxNumClass;
            }
        }

        public DeleteNumForm()
        {
            InitializeComponent();
        }

        private void DeleteNumForm_Load(object sender, EventArgs e)
        {

        }

        private void DeleteNumForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _adminRequest.DeleteFirstBoxFromForm(_reposFactory, _textBoxNum);
            _adminRequest.DeleteFirstBox(_reposFactory, _textBoxNum, _textBoxNumHotel, _textBoxPlace,
                _textBoxNumClass);
            this.Close();
        }
    }
}
