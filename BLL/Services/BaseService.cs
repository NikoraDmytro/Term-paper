using AutoMapper;
using DALAbstractions;

namespace BLL.Services
{
    public abstract class BaseService
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }
    }
}