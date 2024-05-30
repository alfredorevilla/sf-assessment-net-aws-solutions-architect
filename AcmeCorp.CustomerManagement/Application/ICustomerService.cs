using AcmeCorp.CustomerManagement.Application.Commands;
using MediatR;

namespace AcmeCorp.CustomerManagement.Application;

public interface ICustomerService
{
    Task CreateAsyc(CreateCustomerCommand command);
}