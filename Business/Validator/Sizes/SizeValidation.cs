using Business.Messages;
using DataAccess.Abstarct;
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
        private readonly ISizeDAL _sizeDAL;
        public SizeValidation(ISizeDAL sizeDAL)
        {
            _sizeDAL = sizeDAL;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(SizeMessage.SizeNameNoEmpty)
                .Length(1, 10).WithMessage(SizeMessage.SizeNameLength);

        }
            private bool BeUniqueName(string name)
            {
                return !_sizeDAL.GetAll(p => p.Name == name && p.Deleted == 0).Any();
            }
    }
}
