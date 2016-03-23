using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using Npgsql;


namespace CP1601.SQL
{
    public class SQLConnect
    {
        // временные переменные для подключения
        private static String SServer = "127.0.0.1";
        private static String SPort = "5432";
        private static String SUserId = "postgres";
        private static String SPassword = "1507";
        private static String SDatabase = "malakhov";

        private static String connParam = "Server=" + SServer + "; Port=" + SPort + "; User Id=" + SUserId + "; Password=" + SPassword + "; Database=" + SDatabase + ";";

        public NpgsqlConnection conn = new NpgsqlConnection(connParam);

        public void OpenConn()
        {
            try
            {
                conn.Open();
                //MessageBox.Show("Соединение открыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }

        public void CloseConn()
        {
            try
            {
                conn.Close();
                //MessageBox.Show("Соединение закрыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }


    }
}
