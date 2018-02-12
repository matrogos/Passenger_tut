using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Passenger.Infrastructure.Commands;
using Passenger.Infrastructure.Commands.Users;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Services;

namespace Passenger.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }
 
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user==null)
            {
                return new NotFoundResult();
            }

            return Json(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            try
            {
                await CommandDispatcher.DispatchAsync(command);
                
                return Created($"api/users/{command.Email}", new object());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
