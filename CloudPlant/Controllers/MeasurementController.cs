using CloudPlant.Domain.CustomExceptions;
using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            this._measurementService = measurementService;
        }

        [HttpPost]
        public IActionResult CreateMeasurement(MeasurementsCreationDTO measurements)
        {
            try
            {
                var newMeasurements = _measurementService.CreateMeasurements(measurements);
                return Ok(newMeasurements);
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(409, e.Message);
            }
        }
    }
}
