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
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual List<Device> Devices { get; set; }
        public CloudPlantUser()
        {
            Name = "Default";
            Surname = "Default";
            Email = "Default";
            Phone = "Default";
            Address = "Default";
            City = "Default";
            Country = "Default";
            Devices = new List<Device>();
        }
    }
}
