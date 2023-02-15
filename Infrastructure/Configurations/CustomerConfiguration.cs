using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for Customer Model
    /// </summary>
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(customer => customer.Id);
            builder.Property(customer => customer.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(customer => customer.LastName).IsRequired().HasMaxLength(100);
            builder.Property(customer => customer.Email).IsRequired();
            builder.Property(customer => customer.FriendlyId).IsRequired();

            builder.HasOne(customer => customer.Account)
                    .WithOne(account => account.Customer)
                    .HasForeignKey<Account>(x => x.UserId);
        }
    }
}
