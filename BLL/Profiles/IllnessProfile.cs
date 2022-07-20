using AutoMapper;
using Core.DataTransferObjects.Illnesses;
using CORE.Models;

namespace BLL.Profiles;

public class IllnessProfile: Profile
{
    public IllnessProfile()
    {
        CreateMap<Illness, IllnessDto>().ReverseMap();
    }
}