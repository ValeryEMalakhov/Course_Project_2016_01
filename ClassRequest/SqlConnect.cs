﻿using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using System.Configuration;
using Npgsql;

namespace ClassRequest
{
    public class SqlConnect
    {
        // временные переменные для подключения
        //private string _sServer = "127.0.0.1";
        //private string _sPort = "5432";
        //private string _sUserId = "postgres";
        //private string _sPassword = "1507";
        //private string _sDatabase = "malakhov";

        //private string _connParam;
        private NpgsqlConnection _conn;
        private static SqlConnect _newConnect = null;

        public SqlConnect(NpgsqlConnection conn)
        {
            //_sServer = ConfigurationManager.AppSettings.Get("ip");
            //_sPort = ConfigurationManager.AppSettings.Get("port");
            //_sUserId = ConfigurationManager.AppSettings.Get("userId");
            //_sPassword = ConfigurationManager.AppSettings.Get("passwd");
            //_sDatabase = ConfigurationManager.AppSettings.Get("dataBase");
            //_connParam = "Server=" + _sServer +
            //             "; Port=" + _sPort +
            //             "; User Id=" + _sUserId +
            //             "; Password=" + _sPassword +
            //             "; Database=" + _sDatabase + ";";

            _conn = conn;
        }

        public SqlConnect GetNewSqlConn()
        {
            // Невозможность использовать синглтон в связи с необходимотью множества подключений
            //if (_newConnect == null)
            //{
            //    _newConnect = new SqlConnect(_conn);
            //}
            //return (_newConnect);

            return (_newConnect = new SqlConnect(_conn));
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
