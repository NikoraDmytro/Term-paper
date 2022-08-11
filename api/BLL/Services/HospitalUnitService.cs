using AutoMapper;
using BLLAbstractions;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.Doctor;
using Core.DataTransferObjects.HospitalUnit;
using Core.RequestFeatures;
using DALAbstractions.Interfaces;

namespace BLL.Services;

public class HospitalUnitService: BaseService, IHospitalUnitService
{
    public HospitalUnitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }
    
    public async Task<HospitalUnitDto> GetUnitAsync(string name)
    {
        var unit = await UnitOfWork
            .HospitalUnitRepository
            .GetUnitAsync(name);

        if (unit == null)
        {
            throw new KeyNotFoundException(
                $"У лікарні немає відділення з назвою {name}");
        }
        
        var unitDto = Mapper.Map<HospitalUnitDto>(unit);

        return unitDto;
    }

    public async Task<IEnumerable<HospitalUnitDto>> GetAllUnitsAsync()
    {
        var units = await UnitOfWork
            .HospitalUnitRepository
            .GetAllUnitsAsync();

        var unitsDto = Mapper.Map<IEnumerable<HospitalUnitDto>>(units);

        return unitsDto;
    }

    public async Task<(int, List<DoctorDto>)> GetDoctorsAsync(
        string unitName,
        DoctorParameters parameters)
    {
        //Throws exception if unit not exists
        await GetUnitAsync(unitName);

        parameters.HospitalUnit = unitName;
        
        var (pagesQuantity, doctors) = await UnitOfWork
            .DoctorRepository
            .GetDoctorsAsync(parameters);

        var doctorsDto = Mapper.Map<List<DoctorDto>>(doctors);
        
        return (pagesQuantity, doctorsDto);
    }
}