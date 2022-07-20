using CORE.Models;
using DALAbstractions;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class HospitalUnitRepository: GenericRepository<HospitalUnit>, IHospitalUnitRepository
    {
        public HospitalUnitRepository(HospitalContext context)
            : base(context)
        {
        }
    }
}