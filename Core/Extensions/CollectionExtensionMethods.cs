using Core.Helpers.Result.Concrete;
using Core.Validation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class CollectionExtensionMethods
    {
        public static ErrorDataResult<List<string>> ValidationErrorMessagesWithNewLine(this ValidationResult validationResult)
        {

                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
        }

    }
}
