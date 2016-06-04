namespace ClassRequest.SingleTable
{
    public class TableACard
    {
        public string ClientId { private set; get; }
        public string ApId { private set; get; }
        public string CheckInDate { private set; get; }
        public string CheckOutDate { private set; get; }
        public string Comment { private set; get; }
        public string MToPay { private set; get; }

        public TableACard ()
        { }

        public TableACard(string clientId, string apId, string checkInDate, string checkOutDate, string comment, string mToPay)
        {
            ClientId = clientId;
            ApId = apId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Comment = comment;
            MToPay = mToPay;
        }
    }
}
