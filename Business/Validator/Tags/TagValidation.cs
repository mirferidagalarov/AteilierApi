using Business.Messages;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Tags
{
    public class TagValidation:AbstractValidator<Tag>
    {
        TagEFDAL sizeEFDAL = new TagEFDAL(new AteilerDbContext(new DbContextOptions<AteilerDbContext>()));
        public TagValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(TagMessage.TagNameNoEmpty)
                .MinimumLength(3).WithMessage(TagMessage.TagNameMinLength)
                .MaximumLength(150).WithMessage(TagMessage.TagNameMaxLength)
                .Must(BeUniqueName).WithMessage(TagMessage.TagNameUnique);
        }

        private bool BeUniqueName(string name)
        {
            return !sizeEFDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
        }
    }
}
