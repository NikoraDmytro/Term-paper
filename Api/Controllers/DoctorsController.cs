using Api.DataTransferObjects;
using AutoMapper;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/units/{unitName}/doctors")]
    [ApiController]
    public class DoctorsController : Base
    {
        public DoctorsController(IUnitOfWork repository, IMapper mapper) : base(repository, mapper)
        {
        }

        [HttpGet]
        public IActionResult GetDoctors(string unitName)
        {
            var hospitalUnit = _repository.HospitalUnit.GetUnit(unitName);

            if (hospitalUnit == null)
            {
                return NotFound($"Hospital unit with name {unitName} doesn't exist!");
            }

            var doctors = _repository.Doctor.GetDoctors(unitName);

            var doctorsDto = _mapper.Map<IEnumerable<DoctorDto>>(doctors);

            return Ok(doctorsDto);
        }

        [HttpGet("{fullName}")]
        public IActionResult GetUnit(string unitName, string fullName)
        {
            var hospitalUnit = _repository.HospitalUnit.GetUnit(unitName);

            if (hospitalUnit == null)
            {
                return NotFound($"Hospital unit with name {unitName} doesn't exist!");
            }

            string[] nameParts = fullName.Split(' ');

            if (nameParts.Length < 2)
            {
                return BadRequest("Doctor name and/or surname is not provided!");
            }

            string name = nameParts[1];
            string surname = nameParts[0];

            var doctor = _repository.Doctor.GetDoctor(unitName, name, surname);

            if (doctor == null)
            {
                return NotFound($"Doctor with full name: {fullName} doesn't exist!");
            }
            
            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            
            return Ok(doctorDto);
        }
    }
}