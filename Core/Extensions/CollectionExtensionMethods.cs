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
        public static ErrorDataResult<List<string>> ValidationErrorMessagesWithNewLine(this List<ValidationErrorModel> validationResults)
        {
            List<string> propertyNames = new List<string>();
            List<string> propertyErrorMessages = new List<string>();
            foreach (var error in validationResults)
            {
                propertyNames.Add(error.PropertyName);
                propertyErrorMessages.Add(error.ErrorMessage);
            }
            return new ErrorDataResult<List<string>>(propertyNames, propertyErrorMessages);
        }

    }
}
