using AutoMapper;
using Core.DataTransferObjects.Medicine;
using CORE.Models;

namespace BLL.Profiles
{
    public class MedicineProfile : Profile
    {
        public MedicineProfile()
        {
            CreateMap<Medicine, MedicineDto>();

            CreateMap<CreateMedicineDto, Medicine>();
        }
    }
}