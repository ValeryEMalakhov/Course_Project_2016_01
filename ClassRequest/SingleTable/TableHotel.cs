namespace ClassRequest.SingleTable
{
    public class TableHotel
    {
        public string HotelId { private set; get; }
        public string OrgName { private set; get; }
        public string HotelName { private set; get; }
        public string City { private set; get; }
        public string Street { private set; get; }
        public string Phone { private set; get; }
        public string HotelClass { private set; get; }
        public string HotelLink { private set; get; }

        public TableHotel()
        { }

        public TableHotel(string hotelId, string orgName, string hotelName, string city,
            string street, string phone, string hotelClass, string hotelLink)
        {
            HotelId = hotelId;
            OrgName = orgName;
            HotelName = hotelName;
            City = city;
            Street = street;
            Phone = phone;
            HotelClass = hotelClass;
            HotelLink = hotelLink;
        }
    }
}
