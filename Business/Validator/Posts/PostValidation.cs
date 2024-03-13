using Business.Messages;
using Entities.Concrete.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validator.Posts
{
    public class PostValidation : AbstractValidator<Post>
    {
        public PostValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(PostMessage.PostNameNoEmpty)
                .MinimumLength(3).WithMessage(PostMessage.PostNameMinLength)
                .MaximumLength(50).WithMessage(PostMessage.PostNameMaxLength);
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage(PostMessage.PostDescriptionNoEmpty)
               .MinimumLength(3).WithMessage(PostMessage.PostDescriptionMinLength)
               .MaximumLength(500).WithMessage(PostMessage.PostDescriptionMaxLength);
            RuleFor(x => x.ImagePath)
               .NotEmpty().WithMessage(PostMessage.PostImageNoEmpty);
        }
    }
}
