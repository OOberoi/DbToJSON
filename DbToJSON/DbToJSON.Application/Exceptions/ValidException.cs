using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace DbToJSON.Application.Exceptions
{
    public class ValidException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
