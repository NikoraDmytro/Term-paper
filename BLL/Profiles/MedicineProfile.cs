using AutoMapper;
using Core.DataTransferObjects.Medicine;
using CORE.Models;

namespace BLL.Profiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>()
                .ForMember(m => m.Quantity,
                    option => option.MapFrom(
                        x => x.QuantityInStock))
                .ReverseMap()
                .ForMember(m => m.QuantityInStock,
                    option => option.MapFrom(
                        x => x.Quantity));

            CreateMap<Treatment, MedicineDto>()
                .ForMember(m => m.Quantity,
                    option => option.MapFrom(
                        x => x.MedicineQuantity))
                .ForMember(m => m.Name,
                    option => option.MapFrom(
                        x => x.MedicineName))
                .ReverseMap()
                .ForMember(t => t.MedicineQuantity,
                    option => option.MapFrom(
                        x => x.Quantity))
                .ForMember(t => t.MedicineName,
                    option => option.MapFrom(
                        x => x.Name));
        }
    }
}