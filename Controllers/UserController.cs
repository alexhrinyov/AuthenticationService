using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        public UserController(ILogger logger)
        {
            _logger = logger;
            _logger.WriteEvent("Сообщение о событии в программе");
            _logger.WriteError("Сообщение об ошибке в программе");
            
        }
        [HttpGet]
        public User GetUser()
        {
            return new User()
            {
                Id=Guid.NewGuid(),
                FirstName="Ivan",
                LastName="Klyuev",
                Email="klyuev@mail.ru",
                Password="kapusta123",
                Login="klyuychik"
            };
        }
    }
}
