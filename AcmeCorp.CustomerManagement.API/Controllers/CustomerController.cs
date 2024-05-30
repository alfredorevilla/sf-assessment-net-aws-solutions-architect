using AcmeCorp.CustomerManagement.API.Models;
using AcmeCorp.CustomerManagement.Application;
using AcmeCorp.CustomerManagement.Application.Commands;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeCorp.CustomerManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService, IMapper mapper) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;
    private readonly IMapper _mapper = mapper;

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerModel model)
    {
        var command = _mapper.Map<CreateCustomerModel, CreateCustomerCommand>(model);
        await _customerService.CreateAsyc(command);
        return Ok();
    }

}

