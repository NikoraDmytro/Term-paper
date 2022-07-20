using Api.ActionFilters;
using BLLAbstractions;
using Core.DataTransferObjects.Patient;
using Core.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        
        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetPatients(
            [FromQuery] PagingParameters parameters)
        {
            var patients = await _patientService
                .GetAllPatientsAsync(parameters);

            return Ok(patients);
        }
        
        [HttpGet("{fullName}", Name = "GetPatientByName")]
        public async Task<IActionResult> GetPatient(string fullName)
        {
            var patient = await _patientService.GetPatientAsync(fullName);
            
            return Ok(patient);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterPatient([FromBody]CreatePatientDto patientDto)
        {
            var registeredPatient = await _patientService
                .RegisterPatientAsync(patientDto);

            return CreatedAtRoute(
                "GetPatientByName",
                new { fullName = registeredPatient.FullName },
                registeredPatient);
        }

        [HttpDelete("{fullName}")]
        public async Task<IActionResult> DischargePatient(string fullName)
        {
            await _patientService.DischargePatientAsync(fullName);

            return Ok($"Пацієнта {fullName} виписано з лікарні!");
        }
    }
}