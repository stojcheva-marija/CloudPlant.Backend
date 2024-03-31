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
        public int Id { get; set; } //Change to string
        public int UserId { get; set; }
        public string MACAddress { get; set; }
        public List<Plant> Plants { get; set; }

        public static explicit operator DeviceDTO(Device device) => new DeviceDTO
        {
            Id = device.Id,
            UserId = device.User.Id,
            MACAddress = device.MACAddress,
            Plants = device.Plants
        };
    }
}
