using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AcmeCorp.CustomerManagement.API.Infrastructure;
internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {


        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(255);
        builder.Property(c => c.VatId).IsRequired().HasMaxLength(16);
        builder.Property(c => c.Email).HasMaxLength(255);
        builder.Property(c => c.PhoneNumber).HasMaxLength(16);


    }
}