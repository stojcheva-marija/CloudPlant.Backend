using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.Domain_models
{
    public class Plant : BaseEntity
    {
        public String Title { get; set; }
        public DateTime LastWatering { get; set; }
        public DateTime NextWatering { get; set; }
        [ForeignKey("PlantTypeId")]
        public virtual PlantType PlantType{ get; set; }
        [ForeignKey("DeviceId")]
        public virtual Device Device { get; set; }
        public virtual List<Measurement> Measurements { get; set; }
        public Plant()
        {
            Measurements = new List<Measurement>();
            LastWatering = DateTime.UtcNow;
            NextWatering = DateTime.UtcNow;
        }
    }
}
