using AutoMapper;
using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public abstract class Base : ControllerBase
    {
        protected readonly IUnitOfWork _repository;
        protected readonly IMapper _mapper;

        protected Base(IUnitOfWork repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}
