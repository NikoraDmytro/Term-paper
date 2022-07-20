using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.HospitalWard;
using Core.Exceptions;
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
        PagingParameters parameters)
    {
        var hospitalWards = await UnitOfWork.HospitalWardRepository
            .GetHospitalWardsAsync(
                parameters.PageNumber,
                parameters.PageSize);
        
        var hospitalWardsDto = Mapper
            .Map<IEnumerable<HospitalWardDto>>(hospitalWards);

        return hospitalWardsDto;
    }

    public async Task<HospitalWardDto> GetWardAsync(int wardNumber)
    {
        var hospitalWard = await UnitOfWork.HospitalWardRepository
            .GetAsync(ward => ward.Number == wardNumber,
                includeProperties: "Patients");

        var hospitalWardDto = Mapper
            .Map<HospitalWardDto>(hospitalWard.First());

        return hospitalWardDto;
    }

    public async Task<HospitalWardDto> OpenNewWardAsync(CreateHospitalWardDto hospitalWardDto)
    {
        var unitName = hospitalWardDto.HospitalUnitName;
        var unit = await UnitOfWork.HospitalUnitRepository
            .GetByIdAsync(unitName);

        if (unit == null)
        {
            throw new KeyNotFoundException($"У лікарні немає відділення з назвою {unitName}");
        }
        
        var wardToOpen = Mapper.Map<HospitalWard>(hospitalWardDto);

        await UnitOfWork.HospitalWardRepository
            .CreateHospitalWardAsync(wardToOpen);
        await UnitOfWork.SaveAsync();

        var openedWard = Mapper.Map<HospitalWardDto>(wardToOpen);
            
        return openedWard;
    }

    public async Task CloseWardAsync(int wardNumber)
    {
        await GetWardAsync(wardNumber);

        await UnitOfWork.HospitalWardRepository
            .DeleteByIdAsync(wardNumber);

        await UnitOfWork.SaveAsync();
    }
}