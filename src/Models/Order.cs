namespace src.Models
{
    public class Order
    {
        public Guid Id {get;set;}
        public Guid UserId {get;set;}
        public decimal TotalAmount {get;set;}
        public string Status {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime PaidAt {get;set;}
    }
}