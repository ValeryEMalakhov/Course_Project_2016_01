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
using Staff;

namespace LogIn
{
    public partial class WfLogin : Form
    {
        public WfLogin()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (label.Left > -label.Width)
            {
                label.Left -= 2;
            }
            else
            {
                label.Left = panel.Width;
            }
        }

        private void WfLogin_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void WfLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnLoginLikeAdmin_Click(object sender, EventArgs e)
        {
            //WfAdmin adminForm = new WfAdmin();
            //Hide();
            //adminForm.ShowDialog();
            //Show();
        }

        private void btnLoginLikeStaff_Click(object sender, EventArgs e)
        {
            StaffWinForm staff = new StaffWinForm();
            Hide();
            staff.ShowDialog();
            Show();
        }

        private void btnLoginLikeUser_Click(object sender, EventArgs e)
        {
            // создать форму для пользователя
            //WFUser userForm = new WFUser();
            //Hide();
            //userForm.ShowDialog();
            //Show();
        }
    }
}
