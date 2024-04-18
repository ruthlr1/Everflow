using FluentValidation;
using System;
using System.Collections.Generic;
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

        }
    }
}