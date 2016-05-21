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
using System.Configuration;
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Npgsql;
using ClassRequest;
using ClassRequest.DAL;
using Staff.Sided_Form;

namespace LogIn
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ConnectConfig cc = new ConnectConfig(ConfigurationManager.AppSettings.Get("ip"),
                ConfigurationManager.AppSettings.Get("port"), ConfigurationManager.AppSettings.Get("userId"),
                ConfigurationManager.AppSettings.Get("passwd"), ConfigurationManager.AppSettings.Get("dataBase"));

            ReposFactory reposFactory = new ReposFactory(cc.Server, cc.Port, cc.UserId, cc.Password, cc.Database);

            //Application.Run(new WfLogin());

            Application.Run(new WfLogin(reposFactory));
        }
    }
}