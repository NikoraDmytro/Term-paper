using Core.DataTransferObjects.Illnesses;
using Core.RequestFeatures;

namespace BLLAbstractions.Interfaces
{
    public interface IIllnessService
    {
        Task<(int, IEnumerable<string>)> 
            GetAllIllnessesAsync(IllnessParameters parameters);
        Task<IllnessDto> GetIllnessAsync(string name);
        Task<IllnessDto> AddIllnessAsync(CreateIllnessDto illnessDto);
        Task RemoveIllnessAsync(string fullName);
    }
}