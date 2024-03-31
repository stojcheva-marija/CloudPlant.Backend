using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Implementation;
using CloudPlant.Service.Interface;
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

        [HttpPost]
        public IActionResult CreateDevice(DeviceDTO deviceDTO)
        {

            Device newDevice = _deviceService.CreateDevice(deviceDTO);
            return Ok(newDevice);
        }

        [HttpGet("{id}", Name = "GetDevice")]
        public IActionResult GetDevice(int id)
        {
            return Ok(_deviceService.GetDevice(id));
        }
    }
}
