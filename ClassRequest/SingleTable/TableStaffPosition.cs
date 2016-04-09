using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableStaffPosition
    {
        public string SVacant { private set; get; }
        public string Salary { private set; get; }

        public TableStaffPosition()
        { }

        public TableStaffPosition(string sVacant, string salary)
        {
            SVacant = sVacant;
            Salary = salary;
        }
    }
}
