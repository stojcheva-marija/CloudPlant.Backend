using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.Identity;
using CloudPlant.Service.Implementation;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CloudPlantUser user)
        {
            var newUser = _userService.CreateUser(user);
            return CreatedAtRoute("GetUser", new { newUser.Id }, newUser);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetPlant(int id)
        {
            return Ok(_userService.GetUser(id));
        }
    }
}
