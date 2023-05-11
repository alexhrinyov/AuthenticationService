using System.Collections.Generic;
using AuthenticationService.Models;

namespace AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetByLogin(string login);
    }
}
