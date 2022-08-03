using AutoMapper;
using Core.DataTransferObjects.Illnesses;
using Core.DataTransferObjects.Treatment;
using CORE.Models;

namespace BLL.Profiles;

public class IllnessProfile: Profile
{
    public IllnessProfile()
    {
        CreateMap<Illness, IllnessDto>();
        CreateMap<CreateIllnessDto, Illness>();

        CreateMap<Treatment, TreatmentDto>()
            .ForMember(t => t.Quantity, 
                opt => opt.MapFrom(
                    x => x.MedicineQuantity))
            .ForMember(t => t.DosageForm, 
                opt => opt.MapFrom(
                    x => x.Medicine != null ? x.Medicine.DosageForm : ""))
            .ForMember(t => t.UnitOfMeasure, 
                opt => opt.MapFrom(
                    x => x.Medicine != null ? x.Medicine.UnitOfMeasure : ""));
        
        CreateMap<CreateTreatmentDto, Treatment>();
    }
}