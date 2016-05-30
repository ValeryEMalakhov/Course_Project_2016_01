using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.Login
{
    public class TableLogin
    {
        public string LoginId { private set; get; }
        public string Pass { private set; get; }
        public string Vacant { private set; get; }

        public TableLogin()
        { }

        public TableLogin(string loginId, string pass, string vacant)
        {
            LoginId = loginId;
            Pass = pass;
            Vacant = vacant;
        }
    }
}
