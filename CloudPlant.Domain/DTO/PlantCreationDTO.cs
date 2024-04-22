using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class PlantCreationDTO
    {
        public int DeviceId { get; set; }
        public string Title { get; set; }
        public int PlantTypeId { get; set; }
    }
}
