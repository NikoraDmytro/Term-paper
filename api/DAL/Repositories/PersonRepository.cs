using CORE.Models;
using System.Linq.Expressions;
using DALAbstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public abstract class PersonRepository<TPerson> :
    GenericRepository<TPerson>,
    IPersonRepository<TPerson> where TPerson : Person
{
    protected PersonRepository(HospitalContext context) : base(context)
    {
    }

    public Expression<Func<TPerson, bool>> NameFilter(string fullName) =>
        person =>
            (person.Surname + " " + person.Name + " " + person.Patronymic)
            .Trim()
            .ToLower()
            .Contains(fullName.Trim().ToLower());

    public async Task<TPerson?> GetByNameAsync(
        string fullName,
        string includeProperties = "")
    {
        IQueryable<TPerson> query = DbSet;

        foreach (var property in includeProperties.Split
                         (',', StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(property);
        }

        var person = await query
            .SingleOrDefaultAsync(NameFilter(fullName));

        return person;
    }

    public async Task DeleteByNameAsync(string fullName)
    {
        var person = await DbSet
            .SingleOrDefaultAsync(NameFilter(fullName));

        if (person != null)
        {
            Delete(person);
        }
    }
}