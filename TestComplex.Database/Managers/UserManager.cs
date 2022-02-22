using System;
using System.Linq;
using TestComplex.Database;
using TestComplex.Domain.Infrastucture;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _ctx;

        public UserManager(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public TResult GetUserAsync<TResult>(long id, Func<User, TResult> selector)
        {
            return _ctx.Users
                .Where(x => x.ExternalId == id.ToString())
                .Select(selector)
                .FirstOrDefault();
        }
    }
}
