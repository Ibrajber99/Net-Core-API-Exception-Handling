using FluentValidation;
using NET_Core_API_Exception_Handling.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Core_API_Exception_Handling.Application.ValidationClasses
{
    public class UpdatePersonValidator : AbstractValidator<PersonDTO>
    {
        public UpdatePersonValidator()
        {
            RuleFor(p => p.PersonID).NotNull().NotEmpty();

            RuleFor(p => p.FirstName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(p => p.LastName).NotNull().NotEmpty().MinimumLength(3).MaximumLength(50);

            RuleFor(p => p.EmailAddress).EmailAddress().NotNull().NotEmpty();

            
        }
    }
}
