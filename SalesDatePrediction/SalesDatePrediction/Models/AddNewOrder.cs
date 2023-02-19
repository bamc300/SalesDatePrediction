using System.Net;

namespace SalesDatePrediction.Models
{
    public class AddNewOrder
    {
        public int empid { get; set; }
        public int shipperid { get; set; }
        public string shipname { get; set; }
        public string shipaddress { get; set; }
        public string shipcity { get; set; }
        public DateTime? orderdate { get; set; }
        public DateTime? requireddate { get; set; }
        public DateTime? shippeddate { get; set; }
        public decimal? freight { get; set; }
        public string shipcountry { get; set; }
        public int productid { get; set; }
        public decimal? unitprice { get; set; }
        public int qty { get; set; }
        public int discount { get; set; }

    }
}
