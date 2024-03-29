using AutoMapper;
using BLLAbstractions;
using BLLAbstractions.Interfaces;
using Core.DataTransferObjects.HospitalWard;
using Core.DataTransferObjects.Patient;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions.Interfaces;

namespace BLL.Services;

public class HospitalWardService: BaseService, IHospitalWardService
{
    public HospitalWardService(IMapper mapper, IUnitOfWork unitOfWork) 
        : base(mapper, unitOfWork)
    {
    }

    private async Task UnitExists(string unitName)
    {
        var unit = await UnitOfWork
            .HospitalUnitRepository
            .GetByIdAsync(unitName);

        if (unit == null)
        {
            throw new KeyNotFoundException(
                $"У лікарні немає відділення з назвою {unitName}");
        }
    }

    public async Task<(int, IEnumerable<HospitalWardDto>)> GetAllWardsAsync(
        HospitalWardParameters parameters)
    {
        var (pagesQuantity, hospitalWards) = await UnitOfWork
            .HospitalWardRepository
            .GetHospitalWardsAsync(parameters);
        
        var hospitalWardsDto = Mapper
            .Map<IEnumerable<HospitalWardDto>>(hospitalWards);

        return (pagesQuantity, hospitalWardsDto);
    }
    
    public async Task<HospitalWardDto> GetWardAsync(
        string unitName,
        int wardNumber)
    {
        await UnitExists(unitName);
        
        var hospitalWard = await UnitOfWork
            .HospitalWardRepository
            .GetHospitalWardAsync(wardNumber);

        if (hospitalWard == null)
        {
            throw new KeyNotFoundException(
                $"У лікарні немає палати №{wardNumber}");
        }
        
        var hospitalWardDto = Mapper.Map<HospitalWardDto>(hospitalWard);

        return hospitalWardDto;
    }

    public async Task<HospitalWardDto> OpenWardInHospitalUnit(
        string unitName,
        CreateHospitalWardDto hospitalWardDto)
    {
        await UnitExists(unitName);
        
        var wardToOpen = Mapper.Map<HospitalWard>(hospitalWardDto);
        wardToOpen.HospitalUnitName = unitName;
        
        await UnitOfWork
            .HospitalWardRepository
            .CreateHospitalWardAsync(wardToOpen);
        await UnitOfWork.SaveAsync();

        var openedWard = Mapper.Map<HospitalWardDto>(wardToOpen);
            
        return openedWard;
    }
    
    public async Task CloseWardAsync(
        string unitName,
        int wardNumber)
    {
        //Throws exception if ward not exists
        await GetWardAsync(unitName, wardNumber);

        await UnitOfWork
            .HospitalWardRepository
            .DeleteByIdAsync(wardNumber);

        await UnitOfWork.SaveAsync();
    }
    
    public async Task<(int, List<PatientDto>)> GetPatientsAsync(
        string unitName,
        int wardNumber,
        PatientParameters parameters)
    {
        //Throws exception if ward not exists
        await GetWardAsync(unitName, wardNumber);
        
        parameters.HospitalWard = wardNumber;
        
        var (pagesQuantity, patients) = await UnitOfWork
            .PatientRepository
            .GetPatientsAsync(parameters);

        var patientsDto = Mapper.Map<List<PatientDto>>(patients);

        return (pagesQuantity, patientsDto);
    }
}