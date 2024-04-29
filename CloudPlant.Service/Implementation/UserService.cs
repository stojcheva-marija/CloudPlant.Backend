using CloudPlant.Domain.CustomExceptions;
using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Domain.Identity;
using CloudPlant.Domain.Utilities;
using CloudPlant.Repository.Implementation;
using CloudPlant.Repository.Interface;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDeviceService _deviceService;
        private readonly IPasswordHasher<CloudPlantUser> _passwordHasher;

        public UserService(IUserRepository userRepository, IDeviceService deviceService, IPasswordHasher<CloudPlantUser> passwordHasher)
        {
            this._userRepository = userRepository;
            this._deviceService = deviceService;
            this._passwordHasher = passwordHasher;
        }
        public List<DeviceDTO> GetDevices(string username)
        {
            CloudPlantUser user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            List<DeviceDTO> deviceDTOs = user.Devices.Select(device => (DeviceDTO)device).ToList();

            return deviceDTOs;

        }

        public List<PlantWithPlantTypeDTO> GetPlants(string username)
        {
            CloudPlantUser user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            List<PlantWithPlantTypeDTO> plantDTOs = new List<PlantWithPlantTypeDTO>();

            foreach (Device device in  user.Devices)
            {
                plantDTOs.AddRange(this._deviceService.ListPlants(device.Code));
            }

            return plantDTOs;
        }

        public CloudPlantUser GetUserByUsername(string username)
        {
            CloudPlantUser user = _userRepository.GetByUsername(username);
            if(user == null) {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<AuthenticatedUserDTO> SignIn(CloudPlantUser user)
        {
            var dbUser = _userRepository.GetByUsername(user.Username);

            if (dbUser == null || _passwordHasher.VerifyHashedPassword(dbUser, dbUser.Password, user.Password) == PasswordVerificationResult.Failed)
            {
                throw new InvalidUsernamePasswordException("Invalid username or password");
            }

            return new AuthenticatedUserDTO()
            {
                Username = user.Username,
                Token = JwtGenerator.GenerateUserToken(user.Username)
            };
        }

        public async Task<AuthenticatedUserDTO> SignUp(CloudPlantUser user)
        {
            var checkUsername = _userRepository.GetByUsername(user.Username);

            if (checkUsername != null)
            {
                throw new UsernameAlreadyExistsException("User with that username already exists!");
            }

            user.Password = _passwordHasher.HashPassword(user, user.Password);

            _userRepository.Insert(user);

            return new AuthenticatedUserDTO
            {
                Username = user.Username,
                Token = JwtGenerator.GenerateUserToken(user.Username)
            };
        }
    }
}
