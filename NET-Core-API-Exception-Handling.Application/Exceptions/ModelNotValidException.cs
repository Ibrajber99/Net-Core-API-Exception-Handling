using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application.Exceptions
{
    public class ModelNotValidException : ApplicationException
    {
        public List<string> Errors { get; set; }

        public ModelNotValidException(ValidationResult result)
        {
            Errors = new List<string>();

            foreach (var validationError in result.Errors)
            {
                Errors.Add(validationError.ErrorMessage);
            }
        }
    }
}
