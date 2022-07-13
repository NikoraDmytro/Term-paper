using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        
        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();

            return Ok(doctors);
        }
        
        [HttpGet("{fullName}", Name = "GetByName")]
        public async Task<IActionResult> GetDoctorByName(string fullName)
        {
            string[] splitFullName = fullName.Split(' ');

            if (splitFullName.Length < 2)
            {
                return BadRequest("Не вказано ім'я або/та прізвище доктора!");
            }
            if (splitFullName.Length > 3)
            {
                return BadRequest("Вказано зайві параметри!");
            }

            string name = splitFullName[1];
            string surname = splitFullName[0];
            string patronymic = splitFullName.Length == 3
                ? splitFullName[2] 
                : "";
            
            var doctor = await _doctorService.GetDoctorAsync(name, surname, patronymic);

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> HireDoctor([FromBody]CreateDoctorDto doctorDto)
        {
            var hiredDoctor = await _doctorService.HireDoctorAsync(doctorDto);

            return CreatedAtRoute(
                "GetByName", 
                new { fullName = hiredDoctor.FullName },
                hiredDoctor);
        }

        [HttpDelete("{fullName}")]
        public async Task<IActionResult> FireDoctor(string fullName)
        {
            string[] splitFullName = fullName.Split(' ');

            if (splitFullName.Length < 2)
            {
                return BadRequest("Не вказано ім'я або/та прізвище доктора!");
            }
            if (splitFullName.Length > 3)
            {
                return BadRequest("Вказано зайві параметри!");
            }

            string name = splitFullName[1];
            string surname = splitFullName[0];
            string patronymic = splitFullName.Length == 3
                ? splitFullName[2] 
                : "";

            
            await _doctorService.FireDoctorAsync(name, surname, patronymic);

            return NoContent();
        }
    }
}