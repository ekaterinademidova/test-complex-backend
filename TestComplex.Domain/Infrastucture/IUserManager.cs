using System;
using TestComplex.Domain.Models;

namespace TestComplex.Domain.Infrastucture
{
    public interface IUserManager
    {
        TResult GetUserAsync<TResult>(long id, Func<User, TResult> selector);
    }
}
