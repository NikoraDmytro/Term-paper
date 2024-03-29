using Api.ActionFilters;
using BLLAbstractions.Interfaces;
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
            [FromQuery] PatientParameters parameters)
        {
            var (pagesQuantity, patients) = await _patientService
                .GetAllPatientsAsync(parameters);

            return Ok(new { pagesQuantity, patients });
        }
        
        [HttpGet("{fullName}", Name = "GetPatientByName")]
        public async Task<IActionResult> GetPatient(string fullName)
        {
            var patient = await _patientService
                .GetPatientAsync(fullName);
            
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
        
        [HttpPut("{fullName}")]
        public async Task<IActionResult> EditPatientData(
            string fullName,
            [FromBody] CreatePatientDto patientDto)
        {
            var editedPatient = await _patientService
                .UpdatePatient(fullName, patientDto);

            return Ok(editedPatient);
        }

        [HttpDelete("{fullName}")]
        public async Task<IActionResult> DischargePatient(string fullName)
        {
            await _patientService.DischargePatientAsync(fullName);

            return NoContent();
        }
    }
}