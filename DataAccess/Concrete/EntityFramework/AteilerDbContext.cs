using Entities.Concrete.TableModels ;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public  class AteilerDbContext:DbContext
    {
        public AteilerDbContext(DbContextOptions<AteilerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }


            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var createdDateProperty = entityType.FindProperty("CreatedDate");

                if (createdDateProperty is not null)
                    createdDateProperty.SetDefaultValueSql("getdate()");
            }

            //builder.Entity<AteilerUser>(e =>
            //{
            //    e.ToTable("Users", "Membership");
            //});
            //builder.Entity<AteilerRole>(e =>
            //{
            //    e.ToTable("Roles", "Membership");
            //});
            //builder.Entity<AteilerUserRole>(e =>
            //{
            //    e.ToTable("UserRoles", "Membership");
            //});
            //builder.Entity<AteilerUserClaim>(e =>
            //{
            //    e.ToTable("UserClaims", "Membership");
            //});
            //builder.Entity<AteilerRoleClaim>(e =>
            //{
            //    e.ToTable("RoleClaims", "Membership");
            //});
            //builder.Entity<AteilerUserLogin>(e =>
            //{
            //    e.ToTable("UserLogins", "Membership");
            //});
            //builder.Entity<AteilerUserToken>(e =>
            //{
            //    e.ToTable("UserTokens", "Membership");
            //});

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

     



        public DbSet<Category> Categories { get; set; } 
        public DbSet<Characteristic> Characteristics { get; set; }  
        public DbSet<Color> Colors { get; set; }    
        public DbSet<HomeBanner> HomeBanners { get; set; }  
        public DbSet<Post> Posts { get; set; }
        public DbSet<Product> Products { get; set; }    
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
