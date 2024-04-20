using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.People.Upsert
{
    public class UpsertPersonCommandValidator : AbstractValidator<UpsertPersonCommand>
    {
        public UpsertPersonCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.EmailAddress).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();

            When(x => !string.IsNullOrEmpty(x.EmailAddress), () => {
                RuleFor(x => x.EmailAddress).NotEmpty().Must(x => IsValidEmail(x)).WithMessage("Email address is invalid");
            });
        }

        private bool IsValidEmail(string? email)
        {
            var result =  new EmailAddressAttribute().IsValid(email);
            return result;
        }
    }
}