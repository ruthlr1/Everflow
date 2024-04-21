using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events.Upsert
{
    public class UpsertEventDetailCommandValidator : AbstractValidator<UpsertEventDetailCommand>
    {
        public UpsertEventDetailCommandValidator()
        {
            RuleFor(x => x.EventDetailDescription).NotEmpty().MaximumLength(100);
            RuleFor(x => x.EventDetailDate).NotEmpty();
            RuleFor(x => x.EventDetailStartTime).NotEmpty();
            RuleFor(x => x.EventDetailEndTime).NotEmpty().GreaterThan(x => x.EventDetailStartTime);

        }
    }
}
