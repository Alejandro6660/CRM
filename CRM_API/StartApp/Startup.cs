using CRM_Service.Context;
using CRM_Service.Models;
using CRM_Service.Services.IManagers;
using CRM_Service.Services.Managers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CRM_API.StartApp
{
    public static class Startup
    {
        private static readonly string _MyCors = "MyCors";
        public static WebApplication InitApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Name", Version = "v1" });
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(_MyCors, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            builder.Services.AddDbContext<CRMContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<ISecurityBasic, SecurityBasic>();
            builder.Services.AddKeyedScoped<IGeneralManager<UserModel, UserInsertModel>, UserManager>("userServices");
        }

        private static void Configure(WebApplication app)
        {
            //Creador de tablas
            //using (var scope = app.Services.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<CRMContext>();
            //    context.Database.Migrate();
            //}

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(_MyCors);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
