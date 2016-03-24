using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CP1601.SQL;
using CP1601.WForm_Admin;
using CP1601.WForm_Staff;
using Npgsql;

namespace CP1601.WForm_Start
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

        // происходит при загрузке формы
        private void WFLogin_Load(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnLoginLikeAdmin_Click(object sender, EventArgs e)
        {
            WfAdmin adminForm = new WfAdmin();
            Hide();
            adminForm.ShowDialog();
            Show();
        }

        private void btnLoginLikeStaff_Click(object sender, EventArgs e)
        {
            WfStaff staffForm = new WfStaff();
            Hide();
            staffForm.ShowDialog();
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
