using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Interface
{
    public interface IPlantService
    {
        PlantDTO GetPlant(int id);
        PlantDTO EditPlant(PlantDTO plantDTO);
        PlantDTO CreatePlant(PlantDTO plantDTO);
        void DeletePlant(PlantDTO plantDTO);
    }
}
