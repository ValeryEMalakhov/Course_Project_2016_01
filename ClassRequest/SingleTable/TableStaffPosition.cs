using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableStaffPosition
    {
        public string SvacantKey { private set; get; }
        public string SVacant { private set; get; }
        public string Salary { private set; get; }

        public TableStaffPosition()
        { }

        public TableStaffPosition(string svacantKey, string sVacant, string salary)
        {
            SvacantKey = svacantKey;
            SVacant = sVacant;
            Salary = salary;
        }
    }
}
