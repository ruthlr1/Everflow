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
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(150);
            RuleFor(x => x.EmailAddress).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(150);

            When(x => !string.IsNullOrEmpty(x.EmailAddress), () => {
                RuleFor(x => x.EmailAddress).NotEmpty().Must(x => IsValidEmail(x)).WithMessage("Email address is invalid");
            });
            When(x => !string.IsNullOrEmpty(x.Password) && x.Password != x.ConfirmedPassword, () => {
                RuleFor(x => x.ConfirmedPassword).NotEmpty().WithMessage("Confirmed Password must match password");
            });
        }

        private bool IsValidEmail(string? email)
        {
            var result =  new EmailAddressAttribute().IsValid(email);
            return result;
        }
    }
}