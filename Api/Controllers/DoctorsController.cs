using DALAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/doctors")]
[ApiController]
public class DoctorsController : ControllerBase
{
    private readonly IUnitOfWork _repository;

    public DoctorsController(IUnitOfWork repository)
    {
        _repository = repository;
    }
}