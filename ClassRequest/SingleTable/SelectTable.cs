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
using ClassRequest.SingleTable;
using Npgsql;

namespace ClassRequest.SingleTable
{
    public class SelectTable
    {
        // глобальные переменные
        SqlConnect sqlConnect = new SqlConnect();

        // запросы на все поля из каждой таблицы
        public List<TableACard> GetTableACard()
        {
            TableACard tableACard;
            var tableACardList = new List<TableACard>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"ACard\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableACard = new TableACard(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["CheckInDate"].ToString(),
                        dbDataRecord["CheckOutDate"].ToString(),
                        dbDataRecord["StComment"].ToString());
                    tableACardList.Add(tableACard);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableACardList;
        }
        public List<TableAClass> GetTableAClass()
        {
            TableAClass tableAClass;
            var tableAClassList = new List<TableAClass>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"AClass\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableAClass = new TableAClass(
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());
                    tableAClassList.Add(tableAClass);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableAClassList;
        }
        public List<TableApartment> GetTableApartment(string filterDate)
        {
            TableApartment tableApartment;
            var tableApartmentList = new List<TableApartment>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Apartment\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableApartment = new TableApartment(
                        dbDataRecord["Ap_ID"].ToString(),
                        dbDataRecord["PlaceQuantity"].ToString(),
                        dbDataRecord["Class_ID"].ToString(),
                        dbDataRecord["ClassCost"].ToString());

                    tableApartmentList.Add(tableApartment);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableApartmentList;
        }
        public List<TableClient> GetTableClient()
        {
            TableClient tableClient;
            var tableClientList = new List<TableClient>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Client\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableClient = new TableClient(
                        dbDataRecord["Client_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["DateOfBirth"].ToString(),
                        dbDataRecord["Phone"].ToString());
                    tableClientList.Add(tableClient);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableClientList;
        }
        public List<TableHotel> GetTableHotel()
        {
            TableHotel tableHotel;
            var tableHotelList = new List<TableHotel>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Hotel\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableHotel = new TableHotel(
                        dbDataRecord["Hotel_ID"].ToString(),
                        dbDataRecord["OrgName"].ToString(),
                        dbDataRecord["HotelName"].ToString(),
                        dbDataRecord["City"].ToString(),
                        dbDataRecord["Street"].ToString(),
                        dbDataRecord["Phone"].ToString(),
                        dbDataRecord["Class"].ToString());
                    tableHotelList.Add(tableHotel);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableHotelList;
        }
        public List<TableStaff> GetTableStaff()
        {
            TableStaff tableStaff;
            var tableStaffList = new List<TableStaff>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"Staff\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaff = new TableStaff(
                        dbDataRecord["Staff_ID"].ToString(),
                        dbDataRecord["FirstName"].ToString(),
                        dbDataRecord["SecondName"].ToString(),
                        dbDataRecord["Gender"].ToString(),
                        dbDataRecord["DateOfBirth"].ToString(),
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Supervisor"].ToString(),
                        dbDataRecord["RegBuilding"].ToString());
                    tableStaffList.Add(tableStaff);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableStaffList;
        }
        public List<TableStaffPosition> GetTableStaffPosition()
        {
            TableStaffPosition tableStaffPosition;
            var tableStaffPositionList = new List<TableStaffPosition>();

            string commPart =
                "SELECT *" +
                " FROM \"hotel\".\"StaffPosition\";";
            try
            {
                // открываем соединение
                sqlConnect.GetInstance().OpenConn();

                NpgsqlCommand command = new NpgsqlCommand(commPart, sqlConnect.GetInstance().GetConn);
                NpgsqlDataReader readerUserTable = command.ExecuteReader();

                foreach (DbDataRecord dbDataRecord in readerUserTable)
                {
                    tableStaffPosition = new TableStaffPosition(
                        dbDataRecord["SVacant"].ToString(),
                        dbDataRecord["Salary"].ToString());
                    tableStaffPositionList.Add(tableStaffPosition);
                }
            }
            catch (NpgsqlException exp)
            {
                // MessageBox.Show("Не удалось выполнить запрос!");
                MessageBox.Show(Convert.ToString(exp));
            }
            finally
            {
                // соединение закрыто принудительно
                sqlConnect.GetInstance().CloseConn();
            }
            return tableStaffPositionList;
        }

    }
}
