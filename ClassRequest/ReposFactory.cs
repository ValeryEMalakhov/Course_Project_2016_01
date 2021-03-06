﻿using System;
using ClassRequest.DAL;
using ClassRequest.Login;
using Npgsql;

namespace ClassRequest
{
    public class ReposFactory : IDisposable
    {
        RepositoryACard RepositoryACard { set; get; }
        RepositoryAClass RepositoryAClass { set; get; }
        RepositoryApartment RepositoryApartment { set; get; }
        RepositoryApartmentAClass RepositoryApartmentAClass { set; get; }
        RepositoryClient RepositoryClient { set; get; }
        RepositoryHotel RepositoryHotel { set; get; }
        RepositoryStaff RepositoryStaff { set; get; }
        RepositoryStaffPosition RepositoryStaffPosition { set; get; }
        RepositoryUserApartmentCard RepositoryUserApartmentCard { set; get; }
        RepositoryUserApartmentCardCost RepositoryUserApartmentCardCost { set; get; }
        RepositoryHotelACardApartment RepositoryHotelACardApartment { set; get; }
        RepositoryLogin RepositoryLogin { set; get; }

        private NpgsqlConnection npgsql;
        private SqlConnect sqlConnect;

        public ReposFactory(string server, string port, string userId, string password, string database)
        {
            npgsql = new NpgsqlConnection("Server=" + server +
                                                           "; Port=" + port +
                                                           "; User Id=" + userId +
                                                           "; Password=" + password +
                                                           "; Database=" + database + ";");
            sqlConnect = new SqlConnect(npgsql);
            OpenConnection();

            RepositoryACard = new RepositoryACard(sqlConnect);
            RepositoryAClass = new RepositoryAClass(sqlConnect);
            RepositoryApartment = new RepositoryApartment(sqlConnect);
            RepositoryApartmentAClass = new RepositoryApartmentAClass(sqlConnect);
            RepositoryClient = new RepositoryClient(sqlConnect);
            RepositoryHotel = new RepositoryHotel(sqlConnect);
            RepositoryStaff = new RepositoryStaff(sqlConnect);
            RepositoryStaffPosition = new RepositoryStaffPosition(sqlConnect);
            RepositoryUserApartmentCard = new RepositoryUserApartmentCard(sqlConnect);
            RepositoryUserApartmentCardCost = new RepositoryUserApartmentCardCost(sqlConnect);
            RepositoryHotelACardApartment = new RepositoryHotelACardApartment(sqlConnect);
            RepositoryLogin = new RepositoryLogin(sqlConnect);
        }

        public void OpenConnection()
        {
            sqlConnect.GetNewSqlConn().OpenConn();
        }

        public void Dispose()
        {
            sqlConnect.GetNewSqlConn().CloseConn();
        }

        public RepositoryLogin GetLogin()
        {
            return RepositoryLogin;
        }
        public RepositoryACard GetACard()
        {
            return RepositoryACard;
        }
        public RepositoryAClass GetAClass()
        {
            return RepositoryAClass;
        }
        public RepositoryApartment GetApartment()
        {
            return RepositoryApartment;
        }
        public RepositoryApartmentAClass GetApartmentAClass()
        {
            return RepositoryApartmentAClass;
        }
        public RepositoryClient GetClient()
        {
            return RepositoryClient;
        }
        public RepositoryHotel GetHotel()
        {
            return RepositoryHotel;
        }
        public RepositoryStaff GetStaff()
        {
            return RepositoryStaff;
        }
        public RepositoryStaffPosition GetStaffPosition()
        {
            return RepositoryStaffPosition;
        }
        public RepositoryUserApartmentCard GetUserApartmentCard()
        {
            return RepositoryUserApartmentCard;
        }
        public RepositoryUserApartmentCardCost GetUserApartmentCardCost()
        {
            return RepositoryUserApartmentCardCost;
        }
        public RepositoryHotelACardApartment GetHotelACardApartment()
        {
            return RepositoryHotelACardApartment;
        }
    }
}
