using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.SingleTable
{
    public class TableApartment
    {
        public string ApId { private set; get; }
        public string ClassId { private set; get; }
        public string PlaceQuantity { private set; get; }
        public string ClassCost { private set; get; }

        public TableApartment()
        { }

        public TableApartment(string apId, string classId, string placeQuantity, string classCost)
        {
            ApId = apId;
            ClassId = classId;
            PlaceQuantity = placeQuantity;
            ClassCost = classCost;
        }
    }
}
