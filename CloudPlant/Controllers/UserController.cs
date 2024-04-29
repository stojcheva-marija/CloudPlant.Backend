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

        [HttpGet("GetUserByUsername")]
        public IActionResult GetUserByUsername(string username) 
        {
            return Ok(_userService.GetUserByUsername(username));
        }

        [HttpGet("GetDevices")]
        public IActionResult GetDevices(string username)
        {
            return Ok(_userService.GetDevices(username));
        }

        [HttpGet("GetPlants")]
        public IActionResult GetPlants(string username)
        {
            return Ok(_userService.GetPlants(username));
        }
    }
}
