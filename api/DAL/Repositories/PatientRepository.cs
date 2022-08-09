using CORE.Models;
using Core.RequestFeatures;
using DALAbstractions;

namespace DAL.Repositories
{
    public class PatientRepository: PersonRepository<Patient>, IPatientRepository
    {
        public PatientRepository(HospitalContext context) : base(context)
        {
        }

        private Func<IQueryable<Patient>, IQueryable<Patient>>
            Filter(PatientParameters parameters) => (query) =>
        {
            if (!string.IsNullOrEmpty(parameters.Diagnosis))
            {
                query = query.Where(patient =>
                    patient.Diagnosis == parameters.Diagnosis);
            }
            if (parameters.HospitalWard != 0)
            {
                query = query.Where(patient =>
                    patient.HospitalWardNumber == parameters.HospitalWard);
            }

            if (!string.IsNullOrEmpty(parameters.AttendingDoctor))
            {
                query = query.Where(patient =>
                    patient.AttendingDoctorSurname + " " +
                    patient.AttendingDoctorName + " " +
                    patient.AttendingDoctorPatronymic
                    == parameters.AttendingDoctor);
            }
            if (!string.IsNullOrEmpty(parameters.SearchTerm))
            {
                query = query.Where(NameFilter(parameters.SearchTerm));
            }

            return query;
        };

        private Func<IQueryable<Patient>, IOrderedQueryable<Patient>>
            OrderBy(string orderBy) => (query) =>
        {
            string? param = orderBy.Split(" ")[0];
            bool isDescending = orderBy.EndsWith("desc");

            IOrderedQueryable<Patient> orderedQuery;
            
            switch (param)
            {
                case "fullName":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(patient => 
                            patient.Surname + " " + patient.Name) : 
                        query.OrderBy(patient => 
                            patient.Surname + " " + patient.Name);
                    break;
                case "age":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(patient => 
                            DateTime.Today - patient.BirthDate):
                        query.OrderBy(patient => 
                            DateTime.Today - patient.BirthDate);
                    break;
                case "dateOfAdmission":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(patient => 
                            DateTime.Today - patient.DateOfAdmission):
                        query.OrderBy(patient => 
                            DateTime.Today - patient.DateOfAdmission);
                    break;
                case "wardNumber": 
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(patient => 
                            patient.HospitalWardNumber):
                        query.OrderBy(patient => 
                            patient.HospitalWardNumber);
                    break;
                case "diagnosis":
                    orderedQuery = isDescending ? 
                        query.OrderByDescending(patient => 
                            patient.Diagnosis):
                        query.OrderBy(patient => 
                            patient.Diagnosis);
                    break;
                default:
                    goto case "fullName";
            }

            return orderedQuery;
        };
        
        public async Task<(int, List<Patient>)> GetPatientsAsync(
            PatientParameters parameters)
        {
            var (totalQuantity, patients) = await GetPagedAsync(
                parameters.PageNumber,
                parameters.PageSize,
                Filter(parameters),
                OrderBy(parameters.OrderBy));
            
            return (totalQuantity, patients) ;
        }
        
        public async Task DeletePatientAsync(string fullName)
        {
            await DeleteByNameAsync(fullName);
        }

        public async Task<Patient?> GetPatientAsync(string fullName)
        {
            var patient = await GetByNameAsync(fullName);

            return patient;
        }
    }
}