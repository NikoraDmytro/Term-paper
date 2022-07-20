using AutoMapper;
using Core.DataTransferObjects.HospitalWard;
using CORE.Models;

namespace BLL.Profiles
{
    public class HospitalWardProfile : Profile
    {
        public HospitalWardProfile()
        {
            CreateMap<HospitalWard, HospitalWardDto>()
                .ForMember(hwd => hwd.Occupancy, 
                    option => option.MapFrom(
                        x => x.Patients.Count()));

            CreateMap<CreateHospitalWardDto, HospitalWard>();
        }
    }
}