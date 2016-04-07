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
using System.Data.Entity.SqlServer;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ClassRequest.DAL;
using Npgsql;

namespace ClassRequest.StaffReq
{
    public class StaffSql
    {
        public static List<UAC> GetUserList(string filterDate)
        {
            UAC uac;
            var uacList = new List<UAC>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Client\" c, \"hotel\".\"ACard\" a, \"hotel\".\"Apartment\" ap" +
                " WHERE c.client_id = a.client_id" +
                " AND ap.ap_id = a.ap_id" +
                " AND a.CheckInDate < '" + filterDate + "'::date" +
                " AND a.CheckOutDate > '" + filterDate + "'::date ;";
            NpgsqlCommand command = new NpgsqlCommand(commPart, SqlConnect.GetInstance().GetConn);
            NpgsqlDataReader readerUserTable = command.ExecuteReader();
            foreach (DbDataRecord dbDataRecord in readerUserTable)
            {
                uac = new UAC(
                    dbDataRecord["Client_ID"].ToString(),
                    dbDataRecord["Ap_ID"].ToString(),
                    dbDataRecord["FirstName"].ToString(),
                    dbDataRecord["SecondName"].ToString(),
                    dbDataRecord["Gender"].ToString(),
                    dbDataRecord["CheckInDate"].ToString(),
                    dbDataRecord["CheckOutDate"].ToString());

                uacList.Add(uac);
            }
            return uacList;
        }






    }
}
