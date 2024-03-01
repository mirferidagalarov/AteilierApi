using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Sizes
{
    public class SizeValidation:AbstractValidator<Size>
    {
        public SizeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(SizeMessage.SizeNameNoEmpty)
                .MinimumLength(3).WithMessage(SizeMessage.SizeNameMinLength)
                .MaximumLength(150).WithMessage(SizeMessage.SizeNameMaxLength);
        }
    }
}
