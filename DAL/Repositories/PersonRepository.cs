using CORE.Models;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public abstract class PersonRepository<TPerson>: 
    GenericRepository<TPerson>,
    IPersonRepository<TPerson> where TPerson: Person 
{
    protected PersonRepository(HospitalContext context) : base(context)
    {
    }

    private string[] SplitName(string fullName)
    {
        string[] splitName = new string[3];
        string[] keys = fullName.Split(" ");

        if (keys.Length > 3)
        {
            return splitName;
        }
        keys.CopyTo(splitName, 0);

        return splitName;
    }

    public async Task<TPerson?> FindByFullNameAsync(string fullName, string includeProperties = "")
    {
        IQueryable<TPerson> query = DbSet;
        string[] splitName = SplitName(fullName);
        
        foreach (var property in includeProperties.Split
                     (',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(property);
        }
        
        var person = await query
            .SingleOrDefaultAsync(p => 
                p.Name == splitName[1] &&
                p.Surname == splitName[0] &&
                p.Patronymic == splitName[2]);

        return person;
    }

    public async Task DeleteByFullNameAsync(string fullName)
    {
        var person = await FindByFullNameAsync(fullName);

        if (person != null)
        {
            Delete(person);
        }
    }
}