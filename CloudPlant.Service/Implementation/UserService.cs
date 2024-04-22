using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Domain.Identity;
using CloudPlant.Repository.Implementation;
using CloudPlant.Repository.Interface;
using CloudPlant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public CloudPlantUser CreateUser(CloudPlantUser user)
        {
            _userRepository.Insert(user);

            return user;
        }

        public CloudPlantUser GetUser(int id)
        {
            CloudPlantUser user = _userRepository.GetById(id);
            if(user == null) {
                throw new Exception("User not found");
            }
            return _userRepository.GetById(id);
        }
    }
}
