using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class DeviceDTO 
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Username{ get; set; }

        public static explicit operator DeviceDTO(Device device) => new DeviceDTO
        {
            Id = device.Id,
            Username = device.User.Username,
            Code = device.Code,
            Name = device.Name
        };
    }
}
