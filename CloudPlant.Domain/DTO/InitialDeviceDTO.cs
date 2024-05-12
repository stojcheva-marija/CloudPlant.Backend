using CloudPlant.Domain.Domain_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Domain.DTO
{
    public class InitialDeviceDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public static explicit operator InitialDeviceDTO(Device device) => new InitialDeviceDTO
        {
            Id = device.Id,
            Code = device.Code,
            Name = device.Name
        };
    }
}
