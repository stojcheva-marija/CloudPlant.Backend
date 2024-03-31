using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Repository.Interface
{
    public interface IPlantTypeRepository
    {
        void Insert(PlantType entity);
        PlantType GetById(int id);
    }
}
