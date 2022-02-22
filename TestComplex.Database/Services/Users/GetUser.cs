using TestComplex.Domain.Infrastucture;

namespace TestComplex.Database.Services.Users
{
    public class GetUser
    {

        private readonly IUserManager _userManager;

        public GetUser(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public UserViewModel Do(long id) =>
            _userManager.GetUserAsync(id, x => new UserViewModel
            {
                Id = x.Id,
                ExternalId = x.ExternalId
            });

        public class UserViewModel
        {
            public long Id { get; set; }
            public string ExternalId { get; set; }
        }
    }
}
