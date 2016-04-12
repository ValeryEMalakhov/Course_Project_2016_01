﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.DAL
{
    public class ApartmentAClass
    {
        public string ApId { private set; get; }
        public string HotelId { private set; get; }
        public string PlaceQuantity { private set; get; }
        public string ClassId { private set; get; }
        public string ClassCost { private set; get; }

        public ApartmentAClass()
        { }

        public ApartmentAClass(string apId, string hotelId, string placeQuantity, string classId, string classCost)
        {
            ApId = apId;
            HotelId = hotelId;
            PlaceQuantity = placeQuantity;
            ClassId = classId;
            ClassCost = classCost;
        }

    }
}
