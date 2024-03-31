using CloudPlant.Domain.Domain_models;
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
        CloudPlantUser CreateUser(CloudPlantUser user);
        CloudPlantUser GetUser(int id);
    }
}
