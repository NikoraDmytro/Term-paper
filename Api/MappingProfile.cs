using AutoMapper;
using Core.DataTransferObjects;
using CORE.Models;

namespace Api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(d => d.FullName,
                    option => option.MapFrom(
                            x => x.FullName))
                .ForMember(d => d.Profession,
                    option => option.MapFrom(
                        x => x.HospitalUnit.Profession));
            
            CreateMap<CreateDoctorDto, Doctor>();
        }
    }
}