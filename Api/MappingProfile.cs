using AutoMapper;
using CORE.Models;
using DAL.DataTransferObjects;

namespace Api;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<HospitalUnit, HospitalUnitDto>()
            .ForMember(unit => unit.WorkforceSize,
                option => option.MapFrom(x => x.Doctors.Count))
            .ForMember(unit => unit.WardsNumber,
                option => option.MapFrom(x => x.HospitalWards.Count));
    }
}