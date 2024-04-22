﻿using CloudPlant.Domain.Domain_models;
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
        Device CreateDevice(String code);
        DeviceDTO GetDeviceById(int id);
        DeviceDTO GetDeviceByCode(string code);
        Device AddUserToDevice(int deviceId, int userId);
        List<PlantWithPlantTypeDTO> ListPlants(string code);
        DeviceDTO EditDevice(DeviceDTO deviceDTO);
        void DeleteDevice(DeviceDTO deviceDTO);
    }
}
