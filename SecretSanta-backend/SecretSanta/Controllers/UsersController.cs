using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SecretSanta.BLL;
using SecretSanta.BLL.Interfaces;

namespace SecretSanta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _userService.GetUsers();
        }

        [HttpPost]
        public async Task Add(UserDTO user)
        {
            await _userService.Add(user);
        }
    }
}
