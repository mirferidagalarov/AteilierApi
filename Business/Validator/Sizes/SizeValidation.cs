using Business.Messages;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Sizes
{
    public class SizeValidation:AbstractValidator<Size>
    {
        SizeEFDAL sizeEFDAL = new SizeEFDAL(new AteilerDbContext(new DbContextOptions<AteilerDbContext>()));

        public SizeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(SizeMessage.SizeNameNoEmpty)
                .Length(1, 10).WithMessage(SizeMessage.SizeNameLength)
                .Must(BeUniqueName).WithMessage(SizeMessage.SizeNameUnique);

        }
            private bool BeUniqueName(string name)
            {
                return !sizeEFDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
            }
    }
}
