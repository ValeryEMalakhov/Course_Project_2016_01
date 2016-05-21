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
        private string _loginId;

        #endregion

        public ClientWinForm(ReposFactory reposFactory, string loginId)
        {
            InitializeComponent();

            _reposFactory = reposFactory;
            _loginId = loginId;
            dgvNum.ScrollBars = ScrollBars.Horizontal;
        }
        public ClientWinForm()
        {
            InitializeComponent();
        }

        private void ClientWinForm_Load(object sender, EventArgs e)
        {

        }

        private void ClientWinForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }



    }
}
