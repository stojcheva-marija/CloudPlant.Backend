using CloudPlant.Domain.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.Domain_models
{
    public class Device : BaseEntity
    {
        //DELETE MACADRESS
        public string Code { get; set; }
        public string Name { get; set; }
        public string? MACAddress { get; set; }
        [ForeignKey("CloudPlantUserId")]
        public virtual CloudPlantUser? User { get; set; } 
        public virtual List<Plant> Plants { get; set; }
        public Device()
        {
            Plants = new List<Plant>();
        }
    }
}
