using Microsoft.EntityFrameworkCore;

namespace Payment.Infraestructure.Persistence;

public class PaymentDbContext : DbContext
{
    public PaymentDbContext(): base(){}
    public  PaymentDbContext(DbContextOptions<PaymentDbContext> options): base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
     protected override void OnModelCreating(ModelBuilder builder) {
        builder.HasDefaultSchema(Schemas.Payment);
        builder.ApplyConfiguration(new PaymentConfiguration());
    }
}
