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
using System.Data.Common;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using ClassRequest;
using ClassRequest.DAL;
using ClassRequest.SingleTable;
using ClassRequest.Login;
using Npgsql;

namespace LogIn
{
    public class LogInRequest
    {
        public int GoodUser(LoginReposFactory loginReposFactory, string name, string pass)
        {

            foreach (var v in loginReposFactory.GetLogin().GetSingleTable())
            {
                if (v.LoginId == Protection.Encrypt(name, "VEM") &
                    v.Pass == Protection.Encrypt(pass, "VEM"))
                {
                    if (v.Vacant == Protection.Encrypt("A", "VEM"))
                        return 0;
                    if (v.Vacant == Protection.Encrypt("S", "VEM"))
                        return 1;
                    if (v.Vacant == Protection.Encrypt("C", "VEM"))
                        return 2;
                }
            }
            return 99;
        }
    }
}
