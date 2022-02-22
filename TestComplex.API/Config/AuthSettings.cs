namespace TestComplex.API.Config
{
    // Stores Auth0 platform specific data to validate the token
    public class AuthSettings
    {
        public string Domain { get; set; }
        public string Audience { get; set; }
    }
}