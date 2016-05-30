using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableHotelACardApartment
    {
        public string HotelId { private set; get; }
        public string ApId { private set; get; }
        public string CheckInDate { private set; get; }
        public string CheckOutDate { private set; get; }

        public TableHotelACardApartment()
        { }

        public TableHotelACardApartment(string hotelId, string apId, string checkInDate, string checkOutDate)
        {
            HotelId = hotelId;
            ApId = apId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }
    }
}