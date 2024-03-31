using CloudPlant.Domain.Domain_models;
using CloudPlant.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudPlant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlantTypeController : ControllerBase
    {
        private readonly IPlantTypeService _plantTypeService;

        public PlantTypeController(IPlantTypeService plantTypeService)
        {
            this._plantTypeService = plantTypeService;
        }

        [HttpPost]
        public IActionResult CreatePlantType(PlantType plantType)
        {
            var newPlantType = _plantTypeService.CreatePlantType(plantType);
            return Ok(newPlantType);
        }
    }
}
