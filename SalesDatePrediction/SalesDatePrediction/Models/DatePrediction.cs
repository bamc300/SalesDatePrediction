namespace SalesDatePrediction.Models
{
    public class DatePrediction
    {
        public int custid { get; set; }
        public string contactname { get; set; }
        public string? LastOrderDate { get; set; }
        public string? NextPredictedOrder { get; set;}
    }
}
