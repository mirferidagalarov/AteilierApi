using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.HomeBanners
{
    public class HomeBannerValidation : AbstractValidator<HomeBanner>
    {
        public HomeBannerValidation()
        {
            RuleFor(x => x.ImagePath).NotEmpty().WithMessage("You must choose image");
        }
    }
}
