using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for Account Model
    /// </summary>
    internal sealed class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(account => account.Id);
            builder.Property(account => account.AccountNumber).IsRequired();
            builder.Property(account => account.AccountBalance).IsRequired();
            builder.Property(account => account.IsLocked).HasDefaultValue(false);
            builder.Property(account => account.UserId).IsRequired();

            builder.HasOne(account => account.Customer)
                    .WithOne(customer => customer.Account)
                    .HasForeignKey<Account>(account => account.UserId);
            builder.HasMany(account => account.TransactionInfos)
                    .WithOne(transactionInfo => transactionInfo.Account)
                    .HasForeignKey(transactionInfo => transactionInfo.AccountId);


        }
    }
}
