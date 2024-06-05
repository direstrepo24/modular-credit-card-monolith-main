using Microsoft.EntityFrameworkCore;

namespace Transaction.Infraestructure.Persistence;

public class TransactionDbContext : DbContext
{
    public TransactionDbContext(): base(){}
    public  TransactionDbContext(DbContextOptions<TransactionDbContext> options): base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
     protected override void OnModelCreating(ModelBuilder builder) {
        builder.HasDefaultSchema(Schemas.Transaction);
        builder.ApplyConfiguration(new TransactionConfiguration());
    }
}
