using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Interface
{
    public interface IUserService
    {
        CloudPlantUser GetUserByUsername(string username);
        List<DeviceDTO> GetDevices(string username);
        List<PlantWithPlantTypeDTO> GetPlants(string username);
        Task<AuthenticatedUserDTO> SignUp(CloudPlantUser user);
        Task<AuthenticatedUserDTO> SignIn(CloudPlantUser user);
    }
}
