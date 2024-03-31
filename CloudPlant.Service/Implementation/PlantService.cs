using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Interface;
using CloudPlant.Repository.Interface;
using CloudPlant.Repository.Implementation;


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

       public PlantDTO CreatePlant(PlantDTO plantDTO)
        {
            var device = _deviceRepository.GetById(plantDTO.DeviceId);
            var plantType = _plantTypeRepository.GetById(plantDTO.PlantTypeId);

            var plant = new Plant
            {
                Title = plantDTO.Title,
                LastWatering = plantDTO.LastWatering,
                NextWatering = plantDTO.NextWatering, //Calculate this
                PlantType = plantType,
                Device = device
            };
            _plantRepository.Insert(plant);

            return (PlantDTO) plant;
        }

        public void DeletePlant(PlantDTO plantDTO)
        {
            var plant = _plantRepository.GetById(plantDTO.Id);
            _plantRepository.Delete(plant);
        }

        public PlantDTO EditPlant(PlantDTO plantDTO)
        {
            var plant = _plantRepository.GetById(plantDTO.Id);

            plant.Title = plantDTO.Title;
            plant.NextWatering = plantDTO.NextWatering;
            plant.LastWatering = plantDTO.LastWatering;

            _plantRepository.Update(plant);
            return (PlantDTO)plant;
        }

        public PlantDTO GetPlant(int id)
        {
            return (PlantDTO) _plantRepository.GetById(id);
        }
    }
}
