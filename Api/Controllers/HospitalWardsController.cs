using Api.ActionFilters;
using BLLAbstractions;
using Core.DataTransferObjects.HospitalWard;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/hospitalUnits/{unitName}/wards")]
    public class HospitalWardsController : ControllerBase
    {
        private readonly IHospitalWardService _hospitalWardService;
        
        public HospitalWardsController(IHospitalWardService hospitalWardService)
        {
            _hospitalWardService = hospitalWardService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetHospitalWards(
            string unitName,
            [FromQuery] HospitalWardParameters parameters)
        {
            var hospitalWards = await _hospitalWardService
                .GetAllWardsAsync(unitName, parameters);

            return Ok(hospitalWards);
        }
        
        [HttpGet("{wardNumber}", Name = "GetHospitalWard")]
        public async Task<IActionResult> GetHospitalWard(short wardNumber)
        {
            var hospitalWard = await _hospitalWardService
                .GetWardAsync(wardNumber);
            
            return Ok(hospitalWard);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> OpenWardInHospitalUnit(
            string unitName,
            [FromBody]CreateHospitalWardDto hospitalWardDto)
        {
            var openedHospitalWard = await _hospitalWardService
                .OpenWardInHospitalUnit(unitName, hospitalWardDto);

            return CreatedAtRoute(
                "GetHospitalWard",
                new {unitName, wardNumber = openedHospitalWard.Number },
                openedHospitalWard);
        }

        [HttpDelete("{wardNumber}")]
        public async Task<IActionResult> CloseHospitalWard(int wardNumber)
        {
            await _hospitalWardService.CloseWardAsync(wardNumber);

            return Ok($"Палата №{wardNumber} була зачинена!");
        }
    }
}