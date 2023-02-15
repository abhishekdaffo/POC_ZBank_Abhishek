using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    /// <summary>
    /// Configuration for TransactionInfo Model
    /// </summary>
    internal sealed class TransactionInfoConfiguration : IEntityTypeConfiguration<TransactionInfo>
    {
        public void Configure(EntityTypeBuilder<TransactionInfo> builder)
        {
            builder.ToTable("TransactionInfo");
            builder.HasKey(transactionInfo => transactionInfo.Id);
            builder.Property(transactionInfo => transactionInfo.Amount).IsRequired();
            builder.Property(transactionInfo => transactionInfo.ToBankName).IsRequired();
            builder.Property(transactionInfo => transactionInfo.ToBankAccountNo).IsRequired();
            builder.Property(transactionInfo => transactionInfo.PayeeName).IsRequired();
            builder.Property(transactionInfo => transactionInfo.PayeePhone).IsRequired();
            builder.Property(transactionInfo => transactionInfo.CreatedOn).IsRequired();
            builder.Property(transactionInfo => transactionInfo.Completed).IsRequired();

            builder.HasOne(transactionInfo => transactionInfo.Account)
                    .WithMany(account => account.TransactionInfos)
                    .HasForeignKey(transactionInfo => transactionInfo.AccountId);
        }
    }
}
