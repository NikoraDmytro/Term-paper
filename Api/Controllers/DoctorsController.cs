using Api.ActionFilters;
using BLLAbstractions;
using Core.DataTransferObjects.Doctor;
using Core.RequestFeatures;
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
        public async Task<IActionResult> GetDoctors(
            [FromQuery] DoctorParameters parameters)
        {
            var (pagesQuantity, doctors) = await _doctorService
                .GetAllDoctorsAsync(parameters);

            return Ok(new
            {
                pagesQuantity,
                doctors
            });
        }
        
        [HttpGet("{fullName}", Name = "GetDoctorByName")]
        public async Task<IActionResult> GetDoctorByName(string fullName)
        {
            var doctor = await _doctorService.GetDoctorAsync(fullName);
            
            return Ok(doctor);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> HireDoctor([FromBody] CreateDoctorDto doctorDto)
        {
            var hiredDoctor = await _doctorService.HireDoctorAsync(doctorDto);

            return CreatedAtRoute(
                "GetDoctorByName",
                 new { fullName = hiredDoctor.FullName },
                hiredDoctor);
        }

        [HttpDelete("{fullName}")]
        public async Task<IActionResult> FireDoctor(string fullName)
        {
            await _doctorService.FireDoctorAsync(fullName);

            return Ok($"Звільнено лікаря {fullName}");
        }

        [HttpPut("{fullName}")]
        public async Task<IActionResult> UpdateDoctorData(
            string fullName, 
            [FromBody] UpdateDoctorExperienceDto experienceDto)
        {
            await _doctorService
                .UpdateDoctorExperience(fullName, experienceDto);
            
            return Ok($"Оновлено дані доктора {fullName}!");
        }
    }
}