using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Repository.Implementation;
using CloudPlant.Repository.Interface;
using CloudPlant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudPlant.Service.Implementation
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUserRepository _userRepository;

        public DeviceService(IDeviceRepository deviceRepository, IUserRepository userRepository)
        {
            this._deviceRepository = deviceRepository;
            _userRepository = userRepository;
        }

        public Device CreateDevice(DeviceDTO deviceDTO)
        {
            var user = _userRepository.GetById(deviceDTO.UserId);

            var device = new Device
            {
                MACAddress = deviceDTO.MACAddress,
                User = user
            };

            _deviceRepository.Insert(device);

            return device;
        }

        public DeviceDTO GetDevice(int id)
        {
            return (DeviceDTO) _deviceRepository.GetById(id);
        }
    }
}
