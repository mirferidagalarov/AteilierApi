using DataAccess.Concrete.EntityFramework;
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
            //builder.Services.AddDbContext<AteilerDbContext>().AddIdentity<User, Role>().AddEntityFrameworkStores<AteilerDbContext>();
            builder.Services.AddDbContext<AteilerDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("localDb"));

            });
            builder.Services.AddIdentity<User, Role>()
                          .AddEntityFrameworkStores<AteilerDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
