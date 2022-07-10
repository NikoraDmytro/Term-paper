using AutoMapper;
using DALAbstractions;
using Api.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class HospitalUnitsController: Base
    {
        public HospitalUnitsController(IUnitOfWork repository, IMapper mapper): base(repository, mapper)
        {
        }

        [HttpGet]
        public IActionResult GetUnits()
        {
            var hospitalUnits = _repository.HospitalUnit.GetAllUnits();

            var hospitalUnitsDto = _mapper.Map<IEnumerable<HospitalUnitDto>>(hospitalUnits);

            return Ok(hospitalUnitsDto);
        }

        [HttpGet("{name}")]
        public IActionResult GetUnit(string name)
        {
            var hospitalUnit = _repository.HospitalUnit.GetUnit(name);

            if (hospitalUnit == null)
            {
                return NotFound($"Hospital unit with name {name} doesn't exist!");
            }

            var hospitalUnitDto = _mapper.Map<HospitalUnitDto>(hospitalUnit);

            return Ok(hospitalUnitDto);
        }
    }
}