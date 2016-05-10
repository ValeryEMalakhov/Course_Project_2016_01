﻿using System;
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
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using WMPLib;
using Npgsql;
using Staff;
using Client;

namespace LogIn
{
    public partial class WfLogin : Form
    {
        // шутка
        string path = @"d:\Uni\Curswork\Course_Project_2016_01\CP1601\materials\Sound\Лонгин.mp3";
        WindowsMediaPlayer wmp = new WindowsMediaPlayer();

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

        private void WfLogin_Load(object sender, EventArgs e)
        {
            timer.Start();
            //wmp.URL = path;
            //wmp.controls.play();

        }

        private void WfLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnLoginLikeAdmin_Click(object sender, EventArgs e)
        {
            //WfAdmin adminForm = new WfAdmin();
            //Hide();
            //adminForm.ShowDialog();
            //Show();
        }

        private void btnLoginLikeStaff_Click(object sender, EventArgs e)
        {

            StaffWinForm staff = new StaffWinForm();
            Hide();
            staff.ShowDialog();
            Show();
        }

        private void btnLoginLikeUser_Click(object sender, EventArgs e)
        {
            ClientWinForm client = new ClientWinForm();
            Hide();
            client.ShowDialog();
            Show();
        }
    }
}
