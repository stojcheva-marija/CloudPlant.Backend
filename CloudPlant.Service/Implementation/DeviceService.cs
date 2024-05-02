using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Repository.Implementation;
using CloudPlant.Repository.Interface;
using CloudPlant.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
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

        public DeviceDTO AddUserToDevice(int deviceId, string username)
        {
            var device = _deviceRepository.GetById(deviceId);

            if (device == null)
            {
                throw new Exception("Device not found");
            }

            var user = _userRepository.GetByUsername(username);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            device.User = user;

            _deviceRepository.Update(device);

            return (DeviceDTO)device;
        }

        public Device CreateDevice(string code)
        {
            var device = new Device
            {
                Code = code,
            };

            _deviceRepository.Insert(device);

            return device;
        }

        public DeviceDTO GetDeviceById(int id)
        {
                var device = _deviceRepository.GetById(id);
                if (device == null)
                {
                    throw new Exception("Device not found");
                }
                return (DeviceDTO)device;
        }

        public DeviceDTO GetDeviceByCode(string code)
        {
            var device = _deviceRepository.GetByCode(code);
            if (device == null)
            {
                throw new Exception("Device not found");
            }
            return (DeviceDTO)device;
        }

        public List<PlantWithPlantTypeDTO> ListPlants(string code)
        {
            Device device = _deviceRepository.GetByCode(code);
            if (device == null)
            {
                throw new Exception("Device not found");
            }
            List<PlantWithPlantTypeDTO> plantDTOs = device.Plants.Select(plant => (PlantWithPlantTypeDTO)plant).ToList();

            return plantDTOs;
        }

        public DeviceDTO EditDevice(DeviceDTO deviceDTO)
        {
            var device = _deviceRepository.GetById(deviceDTO.Id);
            if (device == null)
            {
                throw new Exception("Device not found");
            }
            var user = _userRepository.GetByUsername(deviceDTO.Username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            device.Code = deviceDTO.Code;
            device.MACAddress = deviceDTO.MACAddress;
            device.User = user;

            _deviceRepository.Update(device);
            return (DeviceDTO)device;

        }

        public void DeleteDevice(int id)
        {
            var device = _deviceRepository.GetById(id);
            if (device == null)
            {
                throw new Exception("Device not found");
            }
            _deviceRepository.Delete(device);
        }
    
    }
}
