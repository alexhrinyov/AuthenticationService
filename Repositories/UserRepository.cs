using System;
using System.Collections.Generic;
using System.Linq;
using AuthenticationService.Models;

namespace AuthenticationService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>()
        {
            new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Максим",
                LastName="Мальцев",
                Email="malec@mail.ru",
                Password="kapusta123",
                Login="max95",
                Role = new Role
                {
                    Id=1,
                    Name="Пользователь"
                }
            },
            new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Сергей",
                LastName="Смирнов",
                Email="smirnov@mail.ru",
                Password="kapusta321",
                Login="smirnov96",
                Role = new Role
                {
                    Id=1,
                    Name="Пользователь"
                }
            },
            new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Никита",
                LastName="Литвенков",
                Email="litvenkov@mail.ru",
                Password="kapusta178",
                Login="lit95",
                Role = new Role
                {
                    Id=2,
                    Name="Администратор"
                }
            }
        };
        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }
    }
}
