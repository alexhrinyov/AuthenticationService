using System.Collections.Generic;

namespace AuthenticationService.Repositories
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User GetByLogin(string login);
    }
}
