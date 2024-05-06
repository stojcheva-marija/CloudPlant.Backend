using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Interface;
using CloudPlant.Repository.Interface;
using CloudPlant.Repository.Implementation;
using CloudPlant.Domain.CustomExceptions;

namespace CloudPlant.Service.Implementation
{
    public class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IPlantTypeRepository _plantTypeRepository;

        public PlantService(IPlantRepository plantRepository, IDeviceRepository deviceRepository, IPlantTypeRepository plantTypeRepository)
        {
            this._plantRepository = plantRepository;
            this._deviceRepository = deviceRepository;
            this._plantTypeRepository = plantTypeRepository;
        }

       public PlantWithPlantTypeDTO CreatePlant(PlantCreationDTO plantCreationDTO)
        {
            var device = _deviceRepository.GetById(plantCreationDTO.DeviceId);
            if (device == null)
            {
                throw new DeviceNotFoundException($"Device with id {plantCreationDTO.DeviceId} not found");
            }
            var plantType = _plantTypeRepository.GetById(plantCreationDTO.PlantTypeId);
            if (plantType == null)
            {
                throw new PlantTypeNotFoundException($"Plant type with id {plantCreationDTO.PlantTypeId} not found");

            }

            var plant = new Plant
            {
                Title = plantCreationDTO.Title,
                PlantType = plantType,
                Device = device
            };
            _plantRepository.Insert(plant);

            return (PlantWithPlantTypeDTO) plant;
        }

        public void DeletePlant(int id)
        {
            var plant = _plantRepository.GetById(id);
            if (plant == null)
            {
                throw new PlantNotFoundException($"Plant with id {id} not found");
            }
            _plantRepository.Delete(plant);
        }

        public PlantWithPlantTypeDTO EditPlant(PlantDTO plantDTO)
        {
            var plant = _plantRepository.GetById(plantDTO.Id);
            if (plant == null)
            {
                throw new PlantNotFoundException($"Plant with id {plantDTO.Id} not found");
            }
            var device = _deviceRepository.GetById(plantDTO.DeviceId);
            if (device == null)
            {
                throw new DeviceNotFoundException($"Device with id {plantDTO.DeviceId} not found");
            }
            var plantType = _plantTypeRepository.GetById(plantDTO.PlantTypeId);
            if (plantType == null)
            {
                throw new PlantTypeNotFoundException($"Plant type with id {plantDTO.PlantTypeId} not found");

            }

            plant.Title = plantDTO.Title;
            plant.NextWatering = plantDTO.NextWatering;
            plant.LastWatering = plantDTO.LastWatering;
            plant.PlantType = plantType;
            plant.Device = device;

            _plantRepository.Update(plant);
            return (PlantWithPlantTypeDTO) plant;
        }

        public PlantWithPlantTypeDTO GetPlant(int id)
        {
            Plant plant = _plantRepository.GetById(id);
            if (plant == null)
            {
                throw new PlantNotFoundException($"Plant with id {id} not found");
            }
            return (PlantWithPlantTypeDTO) plant;
        }
    }
}
