namespace AcmeCorp.CustomerManagement.Domain;



public record class CustomerCreatedDomainEvent(string VatId,
        string Name,
        string? Email,
        string? PhoneNumber) : INotification
;