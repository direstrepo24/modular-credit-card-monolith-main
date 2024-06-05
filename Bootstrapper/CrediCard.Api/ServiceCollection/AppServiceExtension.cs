using Asp.Versioning.ApiExplorer;
namespace CrediCard.Api;
public static class AppServiceExtension
{
    public static void ConfigureServices(this WebApplication app,IApiVersionDescriptionProvider? provider)
        {
            app.UseRouting();
            app.UseCors(CorsConfig.MyPolicy);
            app.UseDefaultFiles();
            app.UseStaticFiles();
            if (app.Environment.IsDevelopment())
            {
                app.UseNSwaggerUI(provider);
                app.ApplyModuleMigrations();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseExceptionHandler();
            app.MapControllers();
            app.MapFallbackToFile("/index.html");
        }
}