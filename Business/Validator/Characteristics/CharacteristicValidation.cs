using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Characteristics
{
    public class CharacteristicValidation: AbstractValidator<Characteristic>
    {
        public CharacteristicValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(CharacteristicMessage.CharacteristicNameNoEmpty)
                .MinimumLength(3).WithMessage(CharacteristicMessage.CharacteristicNameMinLength)
                .MaximumLength(50).WithMessage(CharacteristicMessage.CharacteristicNameMaxLength);
        }
    }
}
