using BLLAbstractions;
using BLLAbstractions.Interfaces;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/hospitalUnits")]
    public class HospitalUnitsController : ControllerBase
    {
        private readonly IHospitalUnitService _unitService;
        
        public HospitalUnitsController(IHospitalUnitService unitService)
        {
            _unitService = unitService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetHospitalUnits()
        {
            var units = await _unitService.GetAllUnitsAsync();

            return Ok(units);
        }
        
        [HttpGet("{name}")]
        public async Task<IActionResult> GetHospitalUnit(string name)
        {
            var unit = await _unitService.GetUnitAsync(name);
            
            return Ok(unit);
        }

        [HttpGet("{name}/doctors")]
        public async Task<IActionResult> GetDoctorsForUnit(
            string name,
            [FromQuery] DoctorParameters parameters)
        {
            var (pagesQuantity, doctors) = await _unitService
                .GetDoctorsAsync(name, parameters);

            return Ok(new
            {
                pagesQuantity,
                doctors
            });
        }
    }
}