using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.Identity
{
    public class CloudPlantUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual List<Device> Devices { get; set; }
        public CloudPlantUser()
        {
            Devices = new List<Device>();
        }
    }
}
