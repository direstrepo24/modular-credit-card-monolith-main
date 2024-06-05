using Cards.Api;
using Payment.Api;
using Transaction.Api;

namespace CrediCard.Api;

public static class ModuleMigrationsExtensions
{
    public static void ApplyModuleMigrations(this IApplicationBuilder app){
        using IServiceScope scope = app.ApplicationServices.CreateScope();
        app.ApplyMigrationsCardModule(scope);
        app.ApplyMigrationsPaymentModule(scope);
        app.ApplyMigrationsTransactionModule(scope);
    }
}
