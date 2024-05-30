
namespace AcmeCorp.CustomerManagement.Application.Commands;

public record class CreateCustomerCommand(string VatId,
        string Name,
        string? Email,
        string? PhoneNumber) : IRequest;