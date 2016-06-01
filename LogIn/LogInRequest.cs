﻿using System;
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
                    v.Pass == Protection.EncryptMD5(pass))
                {
                    if (v.Vacant == Protection.EncryptMD5("A"))
                    {
                        return 0;
                    }
                    if (v.Vacant == Protection.EncryptMD5("S"))
                    {
                        return 1;
                    }
                    if (v.Vacant == Protection.EncryptMD5("C"))
                    {
                        return 2;
                    }
                }
            }
            return 99;
        }

        public void GiveUser(LoginReposFactory loginReposFactory, TextBox name)
        {
            int key = 1100;
            foreach (var v in loginReposFactory.GetClient().GetSingleTable())
            {
                key++;
            }
            name.Text = @"user-" + Convert.ToString(key);
        }

        public void AddUserFirstPart(LoginReposFactory loginReposFactory, TextBox name, TextBox pass, TextBox textBoxUserId, TextBox textBoxFirstName,
            TextBox textBoxSecondName, ComboBox comboBoxGender, DateTimePicker dtpBirth, TextBox textBoxPhone)
        {
            try
            {
                loginReposFactory.GetLogin().AddUser(name.Text, pass.Text, textBoxUserId.Text, textBoxFirstName.Text,
                    textBoxSecondName.Text, comboBoxGender.Text, dtpBirth.Text, textBoxPhone.Text);
            }
            catch (Exception exp)
            {
                // MessageBox.Show("Не удалось добавить клиента!");
                MessageBox.Show(Convert.ToString(exp));
            }
        }
    }
}
