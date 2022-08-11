using CORE.Models;
using Core.RequestFeatures;

namespace DALAbstractions.Interfaces;

public interface IIllnessRepository: IGenericRepository<Illness>
{
    Task<(int, string[])> GetIllnessesNamesAsync(
        IllnessParameters parameters);
    Task<Illness?> GetIllnessAsync(string name);
}