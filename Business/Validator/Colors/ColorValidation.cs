using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Colors
{
    public class ColorValidation:AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ColorMessage.ColorNameNoEmpty)
                .MinimumLength(3).WithMessage(ColorMessage.ColorNameMinLength)
                .MaximumLength(150).WithMessage(ColorMessage.ColorNameMaxLength);
        }
    }
}
