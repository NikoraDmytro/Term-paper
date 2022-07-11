using AutoMapper;
using CORE.Models;
using Api.DataTransferObjects;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HospitalUnit, HospitalUnitDto>()
                .ForMember(unit => unit.WorkforceSize,
                    option => 
                        option.MapFrom(x => x.Doctors.Count))
                .ForMember(unit => unit.WardsNumber,
                    option => 
                        option.MapFrom(x => x.HospitalWards.Count));
            
            CreateMap<HospitalUnitForCreationDto, HospitalUnit>();

            CreateMap<Doctor, DoctorDto>()
                .ForMember(d => d.Profession,
                    option =>
                        option.MapFrom(x => x.ProfessionName))
                .ForMember(d => d.FullName,
                    option =>
                        option.MapFrom(x =>
                            string.Join(' ', x.Surname, x.Name, x.Patronymic)));
        }
    }
}