using AutoMapper;
using DALAbstractions;
using Api.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/units")]
    [ApiController]
    public class HospitalUnitsController : ControllerBase
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public HospitalUnitsController(IUnitOfWork repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetUnits()
        {
            var hospitalUnits = _repository.HospitalUnit.GetAllUnits();

            var hospitalUnitsDto = _mapper.Map<IEnumerable<HospitalUnitDto>>(hospitalUnits);

            return Ok(hospitalUnitsDto);
        }
    }
}