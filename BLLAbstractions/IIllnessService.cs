using Core.DataTransferObjects.Illnesses;

namespace BLLAbstractions
{
    public interface IIllnessService
    {
        Task<IEnumerable<string>> GetAllIllnessesAsync();
        Task<IllnessDto> GetIllnessAsync(string name);
        Task<IllnessDto> AddIllnessAsync(IllnessDto doctorToHire);
        Task RemoveIllnessAsync(string fullName);
    }
}