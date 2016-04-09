using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.DAL
{
    // User_Appartment_ACard
    public class UserAppartmentCard
    {
        public string ClientId { private set; get;  }
        public string ApId { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public string Gender { private set; get; }
        public string CheckInDate { private set; get; }
        public string CheckOutDate { private set; get; }

        public UserAppartmentCard()
        { }

        public UserAppartmentCard(string clientId, string apId, string firstName, string secondName, string gender, string checkInDate, string checkOutDate)
        {
            ClientId = clientId;
            ApId = apId;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}
