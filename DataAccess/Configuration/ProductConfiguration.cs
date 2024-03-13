using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.ImagePath).HasMaxLength(1000);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
            builder.HasIndex(x => new {x.Name,x.Deleted}).IsUnique().HasDatabaseName("idx_Product_Name_Deleted");
        }
    }
}