
using AcmeCorp.CustomerManagement.Domain;
using AcmeCorp.CustomerManagement.Infrastructure;
using Microsoft.Extensions.Logging;

namespace AcmeCorp.CustomerManagement.Application.Commands;

public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, ILogger<CreateCustomerCommandHandler> logger) : IRequestHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ILogger<CreateCustomerCommandHandler> _logger = logger;

    public async Task Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling {CommandName} with VAT ID {VatId}", nameof(CreateCustomerCommand), request.VatId);
            
        var customer = new Customer(request.VatId, request.Name, email: request.Email, phoneNumber: request.PhoneNumber);
        await _customerRepository.AddAsync(customer);
        await _customerRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Handled {CommandName} with VAT ID {VatId}", nameof(CreateCustomerCommand), request.VatId);

    }
}