using AutoMapper;
using DAL.DataTransferObjects;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

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
        try
        {
            var hospitalUnits = _repository.HospitalUnit.GetAllUnits();

            var hospitalUnitsDto = _mapper.Map<IEnumerable<HospitalUnitDto>>(hospitalUnits);
            
            return Ok(hospitalUnitsDto);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error");
        }
    }
}