namespace ClassRequest.SingleTable
{
    public class TableAClass
    {
        public string ClassId { private set; get; }
        public string ClassCost { private set; get; }

        public TableAClass()
        { }

        public TableAClass(string classId, string classCost)
        {
            ClassId = classId;
            ClassCost = classCost;
        }
    }
}
