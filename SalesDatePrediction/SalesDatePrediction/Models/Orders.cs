namespace SalesDatePrediction.Models
{
    public class Orders
    {
        public int orderid { get; set; }
        public int custid { get; set; }
        public int intempid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime shippeddate { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; } 
        public String shipname { get; set; } 
        public String shipaddress { get; set; }
        public String shipcity { get; set; }
        public String shipregion { get; set; }
        public String shippostalcode { get; set; }
        public String shipcountry { get; set; }

    }
}
