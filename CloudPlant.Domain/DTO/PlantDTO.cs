using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class PlantDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime LastWatering { get; set; }
        public DateTime NextWatering { get; set; }
        public int PlantTypeId { get; set; } 
        public int DeviceId { get; set; }

        public static explicit operator PlantDTO(Plant plant) => new PlantDTO
        {
            Id = plant.Id,
            Title = plant.Title,
            LastWatering = plant.LastWatering,
            NextWatering = plant.NextWatering,
            PlantTypeId = plant.PlantType.Id,
            DeviceId = plant.Device.Id,
        };
    }
}
