using Api.ActionFilters;
using BLLAbstractions;
using Microsoft.AspNetCore.Mvc;
using Core.DataTransferObjects.Medicine;
using Core.RequestFeatures;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/medicines")]
    public class MedicinesController : ControllerBase
    {
        private readonly IMedicineService _medicineService;
        
        public MedicinesController(IMedicineService doctorService)
        {
            _medicineService = doctorService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetMedicines(
            [FromQuery] MedicineParameters parameters)
        {
            var (pagesQuantity, medicines) = await _medicineService
                .GetAllAsync(parameters);

            return Ok(new { pagesQuantity, medicines });
        }
        
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddMedicine([FromBody]MedicineDto medicineDto)
        {
            var addedMedicine = await _medicineService.AddNewMedicineAsync(medicineDto);
            
            return Created("", addedMedicine);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteMedicine(string name)
        {
            await _medicineService.DeleteMedicineAsync(name);

            return Ok($"{name} більше не числиться на складі");
        }

        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ResupplyMedicines(
            List<UpdateMedicineDto> medicines)
        {
            await _medicineService.ResupplyMedicinesAsync(medicines);

            return Ok($"Запас медикаментів поповнено!");
        }
    }
}