﻿using CloudPlant.Domain.CustomExceptions;
using CloudPlant.Domain.Identity;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(CloudPlantUser user)
        {
            try
            {
                var result = await _userService.SignUp(user);
                return Created("", result);
            }
            catch (UsernameAlreadyExistsException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(CloudPlantUser user)
        {
            try
            {
                var result = await _userService.SignIn(user);
                return Ok(result);
            }
            catch (InvalidUsernamePasswordException e)
            {
                return StatusCode(409, e.Message);
            }
        }
    }
}
