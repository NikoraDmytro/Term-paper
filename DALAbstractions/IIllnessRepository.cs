using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions;

public interface IIllnessRepository: IGenericRepository<Illness>
{
    Task<(int, string[])> GetIllnessesNamesAsync(
        IllnessParameters parameters);
    Task<Illness?> GetIllnessAsync(string name);
}