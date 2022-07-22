using Core.DataTransferObjects.Illnesses;
using Core.RequestFeatures;

namespace BLLAbstractions
{
    public interface IIllnessService
    {
        Task<IEnumerable<string>> 
            GetAllIllnessesAsync(IllnessParameters parameters);
        Task<IllnessDto> GetIllnessAsync(string name);
        Task<IllnessDto> AddIllnessAsync(IllnessDto doctorToHire);
        Task RemoveIllnessAsync(string fullName);
    }
}