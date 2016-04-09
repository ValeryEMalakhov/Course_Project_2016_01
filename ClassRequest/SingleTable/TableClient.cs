using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableClient
    {
        public string ClientId { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public string Gender { private set; get; }
        public string DateOfBirth { private set; get; }
        public string Phone { private set; get; }

        public TableClient()
        { }

        public TableClient(string clientId, string firstName, string secondName, string gender,
            string dateOfBirth, string phone)
        {
            ClientId = clientId;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Phone = phone;
        }        
    }
}
