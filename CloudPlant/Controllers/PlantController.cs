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
            var plant= _plantService.CreatePlant(plantCreationDTO);
            return CreatedAtRoute("GetPlant", new { plant.Id }, plant);
        }

        [HttpDelete]
        public IActionResult DeletePlant(int id)
        {
            _plantService.DeletePlant(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditPlant(PlantDTO plantDTO)
        {
            return Ok(_plantService.EditPlant(plantDTO));
        }

        [HttpGet("{id}", Name = "GetPlant")]
        public IActionResult GetPlant(int id)
        {
            return Ok(_plantService.GetPlant(id)); 
        }
    }
}
