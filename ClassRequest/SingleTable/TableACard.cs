﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableACard
    {
        public string ClientId { private set; get; }
        public string ApId { private set; get; }
        public string CheckInDate { private set; get; }
        public string CheckOutDate { private set; get; }
        public string Comment { private set; get; }

        public TableACard ()
        { }

        public TableACard(string clientId, string apId, string checkInDate, string checkOutDate, string comment)
        {
            ClientId = clientId;
            ApId = apId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Comment = comment;
        }
    }
}