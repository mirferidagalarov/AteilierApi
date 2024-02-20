﻿using Entities.Concrete.TableModels;
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
    public  class AteilerDbContext : IdentityDbContext<User, Role, int>
    {
        public AteilerDbContext()
        {

        }
        public AteilerDbContext(DbContextOptions<AteilerDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
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