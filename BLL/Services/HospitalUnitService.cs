using AutoMapper;
using BLLAbstractions;
using Core.DataTransferObjects.HospitalUnit;
using DALAbstractions;

namespace BLL.Services;

public class HospitalUnitService: BaseService, IHospitalUnitService
{
    public HospitalUnitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

    public async Task<HospitalUnitDto> GetUnitAsync(string name)
    {
        var unit = await UnitOfWork.HospitalUnitRepository
            .GetByIdAsync(name);

        var unitDto = Mapper.Map<HospitalUnitDto>(unit);

        return unitDto;
    }

    public async Task<IEnumerable<HospitalUnitDto>> GetAllUnitsAsync()
    {
        var units = await UnitOfWork.HospitalUnitRepository
            .GetAsync();

        var unitsDto = Mapper.Map<IEnumerable<HospitalUnitDto>>(units);

        return unitsDto;
    }
}