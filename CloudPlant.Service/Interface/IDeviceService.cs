using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Interface
{
    public interface IDeviceService 
    {
        Device CreateDevice(DeviceDTO deviceDTO);
        DeviceDTO GetDevice(int id);
    }
}
