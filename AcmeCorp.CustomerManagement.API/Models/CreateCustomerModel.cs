namespace AcmeCorp.CustomerManagement.API.Models;

public record CreateCustomerModel(string VatId, string Name, string? Email, string? PhoneNumber);
