﻿namespace ClassRequest.SingleTable
{
    public class TableApartment
    {
        public string ApId { private set; get; }
        public string HotelId { private set; get; }
        public string PlaceQuantity { private set; get; }
        public string ClassId { private set; get; }

        public TableApartment()
        { }

        public TableApartment(string apId, string hotelId, string placeQuantity, string classId)
        {
            ApId = apId;
            HotelId = hotelId;
            PlaceQuantity = placeQuantity;
            ClassId = classId;
        }
    }
}
