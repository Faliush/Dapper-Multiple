using Microsoft.Extensions.DependencyInjection;

namespace DapperMultiple;

public static class DapperDbContextExtension
{
    public static IServiceCollection AddDbContext<TDbContext>(
        this IServiceCollection services, 
        Action<DbContextOptionBuilder> optionActions)
        where  TDbContext: DbContext
    {
        var options = new DbContextOptionBuilder();
        optionActions(options);

        if (options.Connection is null)
            throw new ArgumentNullException(nameof(options.Connection), "Connection string cannot be null");
        
        services.AddScoped<TDbContext>(_ => (TDbContext)Activator.CreateInstance(typeof(TDbContext), options.Connection)!);
        
        return services;
    }
}