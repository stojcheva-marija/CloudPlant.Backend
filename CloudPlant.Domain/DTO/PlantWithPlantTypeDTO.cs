using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class PlantWithPlantTypeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? LastWatering { get; set; }
        public int PlantTypeId { get; set; } 
        public int DeviceId { get; set; }
        public string PlantTypeName { get; set; }
        public float ThresholdValue1 { get; set; }
        public float ThresholdValue2 { get; set; }
        public float ThresholdValue3 { get; set; }
        public float ThresholdValue4 { get; set; }

        public static explicit operator PlantWithPlantTypeDTO(Plant plant) => new PlantWithPlantTypeDTO
        {
            Id = plant.Id,
            Title = plant.Title,
            LastWatering = plant.LastWatering,
            DeviceId = plant.Device.Id,
            PlantTypeId = plant.PlantType.Id,
            PlantTypeName = plant.PlantType.PlantTypeName,
            ThresholdValue1 = plant.PlantType.ThresholdValue1,
            ThresholdValue2 = plant.PlantType.ThresholdValue2,
            ThresholdValue3 = plant.PlantType.ThresholdValue3,
            ThresholdValue4 = plant.PlantType.ThresholdValue4};
    }
}
