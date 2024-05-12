using CloudPlant.Domain.CustomExceptions;
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
        public IActionResult CreateDevice(string code)
        {
            try
            {
                Device newDevice = _deviceService.CreateDevice(code);
                return Ok(newDevice);
            }
            catch (InvalidDeviceCodeException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpGet("GetDeviceById")]
        public IActionResult GetDeviceById(int id)
        {
            try
            {
                return Ok(_deviceService.GetDeviceById(id));
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpGet("GetDeviceByCode")]
        public IActionResult GetDeviceByCode(string code)
        {
            try
            {
                return Ok(_deviceService.GetDeviceByCode(code));
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpGet("ListPlantsByDevice")]
        public IActionResult ListPlantsByDevice(string code)
        {
            try
            {
                return Ok(_deviceService.ListPlants(code));
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }
        [HttpGet("GetAllDevices")]
        public IActionResult GetAllDevices()
        {
            return Ok(_deviceService.GetAllDevices());
        }

        [HttpGet("IsCreated")]
        public IActionResult IsCreated(string code)
        {
            return Ok(_deviceService.IsCreated(code));
        }


        [HttpDelete]
        public IActionResult DeleteDevice(int id)
        {
            try
            {
                _deviceService.DeleteDevice(id);
                return Ok();
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditDevice(DeviceDTO deviceDTO)
        {
            try
            {
                return Ok(_deviceService.EditDevice(deviceDTO));
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (UserNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }
    }
}
