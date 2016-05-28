using System;
using ClassRequest.DAL;
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

            //RepositoryACard = new RepositoryACard(npgsql);
            //RepositoryAClass = new RepositoryAClass(npgsql);
            //RepositoryApartment = new RepositoryApartment(npgsql);
            //RepositoryApartmentAClass = new RepositoryApartmentAClass(npgsql);
            //RepositoryClient = new RepositoryClient(npgsql);
            //RepositoryHotel = new RepositoryHotel(npgsql);
            //RepositoryStaff = new RepositoryStaff(npgsql);
            //RepositoryStaffPosition = new RepositoryStaffPosition(npgsql);
            //RepositoryUserApartmentCard = new RepositoryUserApartmentCard(npgsql);
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
        }

        public void OpenConnection()
        {
            sqlConnect.GetInstance().OpenConn();
        }

        public void Dispose()
        {
            sqlConnect.GetInstance().CloseConn();
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
    }
}
