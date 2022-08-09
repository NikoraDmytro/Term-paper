using AutoMapper;
using Core.DataTransferObjects.HospitalWard;
using CORE.Models;

namespace BLL.Profiles
{
    public class HospitalWardProfile : Profile
    {
        public HospitalWardProfile()
        {
            CreateMap<HospitalWard, HospitalWardDto>();

            CreateMap<CreateHospitalWardDto, HospitalWard>();
        }
    }
}