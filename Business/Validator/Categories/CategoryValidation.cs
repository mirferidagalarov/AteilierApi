using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Categories
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(CategoryMessage.CategoryNameNoEmpty)
               .MinimumLength(3).WithMessage(CategoryMessage.CategoryNameMinLength)
               .MaximumLength(150).WithMessage(CategoryMessage.CategoryNameMaxLength);
        }
    }
}
