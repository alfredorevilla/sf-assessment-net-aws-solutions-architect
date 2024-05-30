using AcmeCorp.CustomerManagement.Application.Commands;
using Microsoft.Extensions.Logging;

namespace AcmeCorp.CustomerManagement.Application;

public class CustomerService(ILogger<CustomerService> logger, IMediator mediator) : ICustomerService
{
    private readonly ILogger<CustomerService> _logger = logger;
    private readonly IMediator _mediator = mediator;

    public async Task CreateAsyc(CreateCustomerCommand command)
    {
        _logger.LogInformation($"{nameof(CreateCustomerCommand)} sent.");
        try
        {
            await _mediator.Send(command);
            _logger.LogInformation($"{nameof(CreateCustomerCommand)} succeeded.");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"{nameof(CreateCustomerCommand)} failed.");
            throw;
        }
    }
}