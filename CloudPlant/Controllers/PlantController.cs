using CloudPlant.Domain.CustomExceptions;
using CloudPlant.Domain.Domain_models;
using CloudPlant.Domain.DTO;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService ) 
        {
            this._plantService = plantService;
        }

        [HttpPost]
        public IActionResult CreatePlant(PlantCreationDTO plantCreationDTO)
        {
            try
            {
                var plant = _plantService.CreatePlant(plantCreationDTO);
                return CreatedAtRoute("GetPlant", new { plant.Id }, plant);
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (InvalidNumberOfPlantsException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (PlantTypeNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletePlant(int id)
        {
            try
            {
                _plantService.DeletePlant(id);
                return Ok();
            }
            catch (PlantNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpPut]
        public IActionResult EditPlant(PlantDTO plantDTO)
        {
            try
            {
                return Ok(_plantService.EditPlant(plantDTO));
            }
            catch (PlantNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (DeviceNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (PlantTypeNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }


        [HttpPut("UpdateLastWatering")]
        public IActionResult UpdateLastWatering(int plantId, DateTime lastWatering)
        {
            try
            {
                return Ok(_plantService.UpdateLastWatering(plantId, lastWatering));
            }
            catch (PlantNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPlant")]
        public IActionResult GetPlant(int id)
        {
            try
            {
                return Ok(_plantService.GetPlant(id));
            }
            catch (PlantNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpGet("GetMeasurements")]
        public IActionResult GetMeasurements(int id)
        {
            try
            {
                return Ok(_plantService.GetMeasurements(id));
            }
            catch (PlantNotFoundException e)
            {
                return StatusCode(409, e.Message);
            }
        }
    }
}
