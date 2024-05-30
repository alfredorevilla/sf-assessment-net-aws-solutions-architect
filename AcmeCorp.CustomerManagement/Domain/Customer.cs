namespace AcmeCorp.CustomerManagement.Domain;

public class Customer(string vatId, string name, string? email, string? phoneNumber) : Entity, IAggregateRoot
{

    public string VatId { get; private set; } = vatId;
    public string Name { get; private set; } = name;
    public string? Email { get; private set; } = email;
    public string? PhoneNumber { get; private set; } = phoneNumber;


}
