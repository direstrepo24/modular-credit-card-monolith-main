using Microsoft.EntityFrameworkCore;

namespace Cards.Infraestructure.Persistence;

public class CardDbContext : DbContext
{
    public CardDbContext(): base(){}
    public  CardDbContext(DbContextOptions<CardDbContext> options): base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
     protected override void OnModelCreating(ModelBuilder builder) {
        builder.HasDefaultSchema(Schemas.Card);
        builder.ApplyConfiguration(new CardConfiguration());
    }
}
