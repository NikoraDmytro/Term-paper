using AutoMapper;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public abstract class Base : ControllerBase
    {
        protected readonly IMapper Mapper;
        protected readonly IUnitOfWork Repository;

        protected Base(IUnitOfWork repository, IMapper mapper)
        {
            Mapper = mapper;
            Repository = repository;
        }
    }
}
