using Api.ActionFilters;
using BLLAbstractions;
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
            var illnesses = await _illnessService
                .GetAllIllnessesAsync(parameters);

            return Ok(illnesses);
        }

        [HttpGet("{name}", Name = "GetIllness")]
        public async Task<IActionResult> GetIllness(string name)
        {
            var illness = await _illnessService.GetIllnessAsync(name);

            return Ok(illness);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddIllness([FromBody] IllnessDto illnessDto)
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
    }
}