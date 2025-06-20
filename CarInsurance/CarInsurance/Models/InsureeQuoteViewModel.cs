namespace CarInsurance.Models
{
    public class InsureeQuoteViewModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string EmailAddress { get; set; }
        public decimal Quote { get; set; }
    }
}
