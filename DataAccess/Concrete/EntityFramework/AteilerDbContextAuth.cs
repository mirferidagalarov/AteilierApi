using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class AteilerDbContextAuth : IdentityDbContext
    {
        public AteilerDbContextAuth(DbContextOptions<AteilerDbContextAuth> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "c0ce1111-b0eb-46b0-ad07-421b73e364ac";
            var writerRoleId = "7574f8a4-a754-4301-a355-c577cfff4f0b";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerId,
                    ConcurrencyStamp=readerId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id =writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
