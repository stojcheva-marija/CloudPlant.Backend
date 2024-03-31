using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Interface
{
    public interface IUserRepository
    {
        void Insert(CloudPlantUser entity);
        CloudPlantUser GetById(int id);
    }
}
