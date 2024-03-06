using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Ateiler API", Version = "v1" });
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference=new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id=JwtBearerDefaults.AuthenticationScheme
                            },
                            Scheme="Oauth2",
                            Name=JwtBearerDefaults.AuthenticationScheme,
                            In=ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            builder.Services.AddIdentityCore<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("Ateiler")
                .AddEntityFrameworkStores<AteilerDbContextAuth>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime=true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(builder.Configuration["Jwt:Key"]))
                        
                    });
                
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
            //builder.Services.AddIdentity<AteilerUser, AteilerRole>()
            //              .AddEntityFrameworkStores<AteilerDbContext>();

            builder.Services.AddDbContext<AteilerDbContextAuth>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("localDbAuth"));
            });
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
