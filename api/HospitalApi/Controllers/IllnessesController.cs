using Api.ActionFilters;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.Illnesses;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/illnesses")]
    public class IllnessesController : ControllerBase
    {
        private readonly IIllnessService _illnessService;

        public IllnessesController(IIllnessService illnessService)
        {
            _illnessService = illnessService;
        }

        [HttpGet]
        public async Task<IActionResult>
            GetIllnesses([FromQuery] IllnessParameters parameters)
        {
            var (pagesQuantity, illnesses) = await _illnessService
                .GetAllIllnessesAsync(parameters);

            return Ok(new { 
                    pagesQuantity,
                    illnesses
                });
    }

        [HttpGet("{name}", Name = "GetIllness")]
        public async Task<IActionResult> GetIllness(string name)
        {
            var illness = await _illnessService.GetIllnessAsync(name);

            return Ok(illness);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddIllness([FromBody] CreateIllnessDto illnessDto)
        {
            var addedIllness = await _illnessService
                .AddIllnessAsync(illnessDto);

            return CreatedAtRoute(
                "GetIllness",
                new {name = addedIllness.Name},
                addedIllness);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteIllness(string name)
        {
            await _illnessService.RemoveIllnessAsync(name);

            return Ok($"{name} видалено з бази даних!");
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> EditIllness(
            string name, CreateIllnessDto newIllnessDto)
        {
            var editedIllness = await _illnessService
                .EditIllnessAsync(name, newIllnessDto);

            return Ok(editedIllness);
        }
    }
}