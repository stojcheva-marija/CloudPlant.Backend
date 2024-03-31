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
        public IActionResult CreatePlant(PlantDTO plantDTO)
        {
            var newPlant = _plantService.CreatePlant(plantDTO);
            return CreatedAtRoute("GetPlant", new { newPlant.Id },newPlant);
        }

        [HttpDelete]
        public IActionResult DeletePlant(PlantDTO plantDTO)
        {
            _plantService.DeletePlant(plantDTO);
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
