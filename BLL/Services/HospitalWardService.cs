using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.HospitalWard;
using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace BLL.Services;

public class HospitalWardService: BaseService, IHospitalWardService
{
    public HospitalWardService(IMapper mapper, IUnitOfWork unitOfWork) 
        : base(mapper, unitOfWork)
    {
    }
    
    public async Task<IEnumerable<HospitalWardDto>> GetAllWardsAsync(
        string unitName,
        HospitalWardParameters parameters)
    {
        var hospitalWards = await UnitOfWork
            .HospitalWardRepository
            .GetHospitalWardsAsync(unitName, parameters);
        
        var hospitalWardsDto = Mapper
            .Map<IEnumerable<HospitalWardDto>>(hospitalWards);

        return hospitalWardsDto;
    }
    
    public async Task<HospitalWardDto> GetWardAsync(int wardNumber)
    {
        var hospitalWard = await UnitOfWork
            .HospitalWardRepository
            .GetHospitalWardAsync(wardNumber);

        var hospitalWardDto = Mapper.Map<HospitalWardDto>(hospitalWard);

        return hospitalWardDto;
    }

    public async Task<HospitalWardDto> OpenWardInHospitalUnit(string unitName, CreateHospitalWardDto hospitalWardDto)
    {
        var unit = await UnitOfWork
            .HospitalUnitRepository
            .GetByIdAsync(unitName);

        if (unit == null)
        {
            throw new KeyNotFoundException(
                $"У лікарні немає відділення з назвою {unitName}");
        }
        
        var wardToOpen = Mapper.Map<HospitalWard>(hospitalWardDto);
        wardToOpen.HospitalUnitName = unit.Name;
        
        await UnitOfWork
            .HospitalWardRepository
            .CreateHospitalWardAsync(wardToOpen);
        await UnitOfWork.SaveAsync();

        var openedWard = Mapper.Map<HospitalWardDto>(wardToOpen);
            
        return openedWard;
    }
    
    public async Task CloseWardAsync(int wardNumber)
    {
        //will throw error if ward not exist
        await GetWardAsync(wardNumber);

        await UnitOfWork
            .HospitalWardRepository
            .DeleteByIdAsync(wardNumber);

        await UnitOfWork.SaveAsync();
    }
}