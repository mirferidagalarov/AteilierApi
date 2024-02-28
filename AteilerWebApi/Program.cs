using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Mapper;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace AteilerWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
                         .ConfigureContainer<ContainerBuilder>(builder =>
                         {
                             builder.RegisterModule(new AutofacBusinessModule());
                         });
            builder.Services.AddDbContext<AteilerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("localDb"));

            });
            builder.Services.AddIdentity<User, Role>()
                          .AddEntityFrameworkStores<AteilerDbContext>();
            builder.Services.AddAutoMapper(typeof(Automapper));
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("cors", policy =>
                {
                    policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("cors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
