using Backend.Repositories.Example;
using Backend.Services.Example;
using Models;
using Models.Configuration;
using Models.Entities.DTOs;
using Models.Entities.Mappers;
using Models.Entities.Models;

namespace Backend;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        IDatabaseConfigurator databaseConfigurator = DatabaseConfiguratorFactory.Create(
            DatabaseConfigurators.SQLITE
        );

        // Add services to the container.
        builder.Services.AddAuthorization();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<AppDbContext>(databaseConfigurator.Configure);

        builder.Services.AddControllers();
        // Dependency injection
        builder.Services.AddTransient<IMapper<ExampleModel, ExampleDto>, ExampleMapper>();
        builder.Services.AddTransient<IExampleRepository, ExampleRepository>();
        builder.Services.AddTransient<IExampleService, ExampleService>();

        // CORS
        builder.Services.AddCors();

        // NO builder.Services... FROM HERE ONWARDS
        WebApplication app = builder.Build(); // Sets builder.stuff as readonly

        app.UseCors(builder =>
            builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
        );

        // Data seeding
        using (IServiceScope scope = app.Services.CreateScope())
        {
            IServiceProvider services = scope.ServiceProvider;
            DataSeeder.Seed(services);
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
