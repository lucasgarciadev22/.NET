using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReactNetCore.Controllers
{
    [ApiController]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;

        static readonly Models.IUserRepository repository = new Models.UserRepository();

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("api/users")]
        public IEnumerable<Models.UserModel> GetAllUsers()
        {
            return repository.GetAll();
        }

        [HttpPost]
        [Route("api/user")]
        [Consumes("application/json")]
        public Models.UserModel PostUser(Models.UserModel item)
        {
            return repository.Add(item);
        }
    }
}