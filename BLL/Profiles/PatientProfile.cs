using AutoMapper;
using Core.DataTransferObjects.Patient;
using CORE.Models;

namespace BLL.Profiles;

public class PatientProfile: Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>()
            .ForMember(p => p.HospitalWardNumber,
                option => option.MapFrom(
                    x => x.HospitalWard.Number));

        CreateMap<CreatePatientDto, Patient>();
    }
}