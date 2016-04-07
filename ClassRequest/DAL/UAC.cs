using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.DAL
{
    // User_Appartment_ACard
    public class UAC
    {
        private string _Client_Id { set; get; }
        private string _Ap_Id { set; get; }
        private string _FirstName { set; get; }
        private string _SecondName { set; get; }
        private string _Gender { set; get; }
        private string _CheckInDate { set; get; }
        private string _CheckOutDate { set; get; }

        public UAC()
        { }

        public UAC(string Client_Id, string Ap_Id, string FirstName, string SecondName, string Gender, string CheckInDate, string CheckOutDate)
        {
            _Client_Id = Client_Id;
            _Ap_Id = Ap_Id;
            _FirstName = FirstName;
            _SecondName = SecondName;
            _Gender = Gender;
            _CheckInDate = CheckInDate;
            _CheckOutDate = CheckOutDate;
        }

        public string GetClient_Id() => _Client_Id;
        public string GetAp_Id() => _Ap_Id;
        public string GetFirstName() => _FirstName;
        public string GetSecondName() => _SecondName;
        public string GetGender() => _Gender;
        public string GetCheckInDate() => _CheckInDate;
        public string GetCheckOutDate() => _CheckOutDate;
    }
}
