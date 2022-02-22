namespace TestComplex.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        // Auth0 unique id. Should be stored in DB to match DB user with Auth0 user.
        public string ExternalId { get; set; }
    }
}