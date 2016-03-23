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
using CP1601.WForm_Start;
using Npgsql;

namespace CP1601.WForm_Admin
{
    public partial class WFAdmin : Form
    {
        // общие переменные
        SQLConnect sqlC = new SQLConnect();


        public WFAdmin()
        {
            InitializeComponent();
            sqlC.OpenConn();

        }

        private void WFAdmin_Load(object sender, EventArgs e)
        {
            //sqlC.OpenConn();
        }

        private void WFAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // разрываем соединение
            sqlC.CloseConn();
        }
    }
}
