using AutoMapper;
using Core.DataTransferObjects.HospitalUnit;
using CORE.Models;

namespace BLL.Profiles
{
    public class HospitalUnitProfile: Profile
    {
        public HospitalUnitProfile()
        {
            CreateMap<HospitalUnit, HospitalUnitDto>();
        }
    }
}