using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.Domain_models
{
    public class Measurement : BaseEntity
    {
       public float LightIntensity { get; set; }
       public float SoilMeasurement { get; set; }
       public float TemperatureMeasurement { get; set; }
       public float HumidityMeasurement { get; set; }
       public DateTime Date { get; set; }

        [ForeignKey("PlantId")]
       public virtual Plant Plant { get; set; }
    }
}
