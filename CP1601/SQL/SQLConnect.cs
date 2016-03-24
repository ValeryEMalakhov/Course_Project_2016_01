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
using System.Runtime.CompilerServices;
using Npgsql;


namespace CP1601.SQL
{
    public class SqlConnect
    {
        // временные переменные для подключения
        private static String _sServer = "127.0.0.1";
        private static String _sPort = "5432";
        private static String _sUserId = "postgres";
        private static String _sPassword = "1507";
        private static String _sDatabase = "malakhov";

        private static String ConnParam = "Server=" + _sServer + "; Port=" + _sPort + "; User Id=" + _sUserId + "; Password=" + _sPassword + "; Database=" + _sDatabase + ";";
        
        public NpgsqlConnection Conn = new NpgsqlConnection(ConnParam);

        public void OpenConn()
        {
            try
            {

                Conn.Open();
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
                Conn.Close();
                //MessageBox.Show("Соединение закрыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }


    }
}
