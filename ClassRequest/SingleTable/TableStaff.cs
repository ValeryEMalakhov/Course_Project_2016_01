using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableStaff
    {
        public string StaffId { private set; get; }
        public string FirstName { private set; get; }
        public string SecondName { private set; get; }
        public string Gender { private set; get; }
        public string DateOfBirth { private set; get; }
        public string SVacantKey { private set; get; }
        public string Supervisor { private set; get; }
        public string RegBuilding { private set; get; }

        public TableStaff()
        { }
        
        public TableStaff(string staffId, string firstName, string secondName, string gender,
            string dateOfBirth, string sVacantKey, string supervisor, string regBuilding)
        {
            StaffId = staffId;
            FirstName = firstName;
            SecondName = secondName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            SVacantKey = sVacantKey;
            Supervisor = supervisor;
            RegBuilding = regBuilding;
        }
    }
}
