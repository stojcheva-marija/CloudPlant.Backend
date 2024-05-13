using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class MeasurementDTO
    {
        //   ADD LIGHT INTENSITY AND DATE
        public int Id { get; set; }
        public float LightIntensity { get; set; }
        public float TemperatureMeasurement { get; set; }
        public float HumidityMeasurement { get; set; }
        public float SoilMeasurement { get; set; }
        public int PlantId { get; set; }
        public DateTime Date { get; set; }

        public static explicit operator MeasurementDTO(Measurement measurement) => new MeasurementDTO
        {
            Id = measurement.Id,
            LightIntensity = measurement.LightIntensity,
            TemperatureMeasurement = measurement.TemperatureMeasurement,
            HumidityMeasurement = measurement.HumidityMeasurement,
            SoilMeasurement = measurement.SoilMeasurement,
            Date = measurement.Date,
            PlantId = measurement.Plant.Id
        };
    }
}
