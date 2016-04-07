using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRequest.DAL
{
    public class Apartment
    {
        private int _Ap_Id { set; get; }
        private int _Hotel_Id { set; get; }
        private int _PlaceQuantity { set; get; }
        private int _Class_ID { set; get; }

        // используем при заливке данных в клиента
        public void SetClient(int Ap_Id, int Hotel_Id, int PlaceQuantity, int Class_ID)
        {
            _Ap_Id = Ap_Id;
            _Hotel_Id = Hotel_Id;
            _PlaceQuantity = PlaceQuantity;
            _Class_ID = Class_ID;
        }


    }
}
