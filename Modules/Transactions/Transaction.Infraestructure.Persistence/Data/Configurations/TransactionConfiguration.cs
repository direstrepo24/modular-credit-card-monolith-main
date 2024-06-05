using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Transaction.Domain;

namespace Transaction.Infraestructure.Persistence;

public class TransactionConfiguration : IEntityTypeConfiguration<TransactionEntity>
{
    public void Configure(EntityTypeBuilder<TransactionEntity> builder)
    {
        builder.ToTable("transaction");
        builder.HasKey(a => a.Id);
        builder.Property(e => e.Type)
                 .HasConversion(
                     v => v.ToString(),
                     v => (CreditCardTransactionType)Enum.Parse(typeof(CreditCardTransactionType), v)
                 )
                 .HasMaxLength(50);
    }
}
