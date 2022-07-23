using AutoMapper;
using Core.DataTransferObjects.Patient;
using CORE.Models;

namespace BLL.Profiles;

public class PatientProfile: Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>()
            .ForMember(p => p.AttendingDoctor,
                option => option.MapFrom(
                    x => x.AttendingDoctorPatronymic != "" ? 
                        $"{x.AttendingDoctorSurname} " +
                        $"{x.AttendingDoctorName} " +
                        $"{x.AttendingDoctorPatronymic}" 
                        :
                        $"{x.AttendingDoctorSurname} " +
                        $"{x.AttendingDoctorName}"));

        CreateMap<CreatePatientDto, Patient>()
            .ForMember(p => p.AttendingDoctor,
                option => option.Ignore());
    }
}