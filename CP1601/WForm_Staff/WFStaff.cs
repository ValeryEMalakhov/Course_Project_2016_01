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
using System.Data.Common;
using CP1601.WForm_Start;
using Npgsql;

namespace CP1601.WForm_Staff
{
    public partial class WfStaff : Form
    {
        public WfStaff()
        {
            InitializeComponent();


        }

        private void WFStaff_Load(object sender, EventArgs e)
        {
            // использовать дату из dateTPUser
            StaffReq.UserOutput(dgvUser, dateTPUser);
            StaffReq.NumOutput(dgvNum, dateTPUser);
        }

        private void WFStaff_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            // предположим, потом это будет делать IDisposable
            SqlConnect.GetInstance().CloseConn();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            StaffReq.UserOutput( dgvUser, dateTPUser );
        }

        private void btnUpdateNum_Click(object sender, EventArgs e)
        {
            StaffReq.NumOutput( dgvNum, dateTPNum);
        }
    }
}
