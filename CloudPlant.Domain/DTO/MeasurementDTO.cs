using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class MeasurementsCreationDTO
    {
        public int DeviceID {get; set; } //Change to string
        public float LightIntensity { get; set; }   
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float SensorMoisture1 { get; set; }
        public float SensorMoisture2 { get; set; }
        public float SensorMoisture3 { get; set; }
    }
}
