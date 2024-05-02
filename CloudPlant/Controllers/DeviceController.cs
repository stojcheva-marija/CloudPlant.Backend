using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Implementation;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this._deviceService = deviceService;
        }

        [HttpPost("CreateDevice")]
        public IActionResult CreateDevice(String code)
        {

            Device newDevice = _deviceService.CreateDevice(code);
            return Ok(newDevice);
        }

        [HttpPost("AddUserToDevice")]
        public IActionResult AddUserToDevice(int deviceId, string username)
        {

            DeviceDTO deviceDTO = _deviceService.AddUserToDevice(deviceId, username);
            return Ok(deviceDTO);
        }

        [HttpGet("GetDeviceById")]
        public IActionResult GetDeviceById(int id)
        {
            return Ok(_deviceService.GetDeviceById(id));
        }

        [HttpGet("GetDeviceByCode")]
        public IActionResult GetDeviceByCode(string code)
        {
            return Ok(_deviceService.GetDeviceByCode(code));
        }

        [HttpGet("ListPlantsByDevice")]
        public IActionResult ListPlantsByDevice(string code)
        {
            return Ok(_deviceService.ListPlants(code));
        }

        [HttpDelete]
        public IActionResult DeleteDevice(int id)
        {
            _deviceService.DeleteDevice(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditDevice(DeviceDTO deviceDTO)
        {
            return Ok(_deviceService.EditDevice(deviceDTO));
        }
    }
}
