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
    public class PostValidation:AbstractValidator<Post>
    {
        public PostValidation()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage(PostMessage.PostNameNoEmpty)
               .MinimumLength(3).WithMessage(PostMessage.PostNameMinLength)
               .MaximumLength(150).WithMessage(PostMessage.PostNameMaxLength);
        }
    }
}
