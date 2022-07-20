using BLLAbstractions;
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
    }
}