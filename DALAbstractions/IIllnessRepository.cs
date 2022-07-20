using CORE.Models;

namespace DALAbstractions;

public interface IIllnessRepository: IGenericRepository<Illness>
{
    Task<string[]> GetIllnessesNamesAsync();
    Task<Illness?> GetIllnessAsync(string name);
}