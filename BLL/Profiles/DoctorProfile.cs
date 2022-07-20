using AutoMapper;
using CORE.Models;
using Core.DataTransferObjects.Doctor;

namespace BLL.Profiles
{
    public class DoctorProfile: Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>()
                .ForMember(d => d.Profession,
                    option => option.MapFrom(
                        x => x.HospitalUnit.Profession));

            CreateMap<CreateDoctorDto, Doctor>();
        }
    }
}