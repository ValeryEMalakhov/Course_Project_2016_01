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

namespace ClassRequest
{
    public class SqlConnect
    {
        // временные переменные для подключения
        private string _sServer = "127.0.0.1";
        private string _sPort = "5432";
        private string _sUserId = "postgres";
        private string _sPassword = "1507";
        private string _sDatabase = "malakhov";

        private string _connParam;
        private NpgsqlConnection _conn;
        private static SqlConnect _instance = null;

        public SqlConnect()
        {
            _connParam = "Server=" + _sServer + "; Port=" + _sPort + "; User Id=" + _sUserId + "; Password=" + _sPassword + "; Database=" + _sDatabase + ";";
            _conn = new NpgsqlConnection(_connParam);
            //OpenConn(); //не эффективно
        }

        public static SqlConnect GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SqlConnect();
            }
            return (_instance);
        }

        public NpgsqlConnection GetConn => _conn;

        public void OpenConn()
        {
            try
            {
                _conn.Open();
                //MessageBox.Show(@"Соединение открыто!");
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
                _conn.Close();
                //MessageBox.Show(@"Соединение закрыто!");
            }
            catch (Exception exp)
            {
                MessageBox.Show(Convert.ToString(exp));
            }
        }
    }
}
