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
            var newMeasurements = _measurementService.CreateMeasurements(measurements);
            return Ok(newMeasurements);
        }
    }
}
