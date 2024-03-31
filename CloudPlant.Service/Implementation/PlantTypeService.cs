using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
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
    public class PlantTypeService : IPlantTypeService
    {
        private readonly IPlantTypeRepository _plantTypeRepository;

        public PlantTypeService(IPlantTypeRepository plantTypeRepository)
        {
            this._plantTypeRepository = plantTypeRepository;
        }

        public PlantType CreatePlantType(PlantType plantType)
        {
            _plantTypeRepository.Insert(plantType);

            return plantType;
        }
    }
}
