﻿namespace ClassRequest.SingleTable
{
    // User_Appartment_ACard
    public class TableUserAppartmentCard
    {
        public string ClientId { private set; get;  }
        public string ApId { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public string Gender { private set; get; }
        public string CheckInDate { private set; get; }
        public string CheckOutDate { private set; get; }
        public string MToPay { private set; get; }

        public TableUserAppartmentCard()
        { }

        public TableUserAppartmentCard(string clientId, string apId, string firstName,
            string secondName, string gender, string checkInDate, string checkOutDate, string mToPay)
        {
            ClientId = clientId;
            ApId = apId;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            MToPay = mToPay;
        }
    }
}
