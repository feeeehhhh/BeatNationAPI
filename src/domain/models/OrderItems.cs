namespace src.domain.models
{
    public class OrderItes
    {
        public Guid Id {get;set;}
        public Guid OrderId {get;set;}
        public Guid LicenseAssignment {get;set;}
        public string? LicenseName {get;set;}
        public decimal Price {get;set;}
        public DateTime CreatedAt {get;set;}
    }
}