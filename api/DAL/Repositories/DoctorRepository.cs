using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;
using DALAbstractions.Interfaces;

namespace DAL.Repositories
{
    public class DoctorRepository : PersonRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HospitalContext context)
            : base(context)
        {
        }

        private Func<IQueryable<Doctor>, IQueryable<Doctor>>
            Filter(string search, string unit) => (query) =>
            {
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(NameFilter(search));
                }

                if (!string.IsNullOrEmpty(unit))
                {
                    query = query.Where(d =>
                        d.HospitalUnitName == unit);
                }

                return query;
            };

        private Func<IQueryable<Doctor>, IOrderedQueryable<Doctor>>
            OrderBy(string orderBy) => (query) =>
        {
            string? param = orderBy.Split(" ")[0];
            bool isDescending = orderBy.EndsWith("desc");

            IOrderedQueryable<Doctor> orderedQuery;
            
            switch (param)
            {
                case "fullName":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(d => 
                            d.Surname + " " + d.Name) : 
                        query.OrderBy(d => d.Surname + " " + d.Name);
                    break;
                case "age":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(d => DateTime.Today - d.BirthDate):
                        query.OrderBy(d => DateTime.Today - d.BirthDate);
                    break;
                case "experience": 
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(d => d.Experience):
                        query.OrderBy(d => d.Experience);
                    break;
                default:
                    goto case "fullName";
            }

            return orderedQuery;
        };


        public async Task<(int, List<Doctor>)> GetDoctorsAsync(DoctorParameters parameters)
        {
            var (total, doctors) = await GetPagedAsync(
                parameters.PageNumber,
                parameters.PageSize,
                Filter(parameters.SearchTerm, parameters.HospitalUnit),
                OrderBy(parameters.OrderBy),
                "HospitalUnit");
            
            return (total, doctors);
        }
        
        public async Task<Doctor?> GetDoctorAsync(string fullName)
        {
            var doctor = await GetByNameAsync(
                fullName,
                "HospitalUnit");

            return doctor;
        }

        public async Task DeleteDoctorAsync(string fullName)
        {
            await DeleteByNameAsync(fullName);
        }
    }
}