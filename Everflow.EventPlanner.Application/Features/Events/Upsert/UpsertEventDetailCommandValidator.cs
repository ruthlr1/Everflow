using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Application.Features.Events.Upsert
{
    public class UpsertEventDetailValidator : AbstractValidator<UpsertEventDetailCommand>
    {
        public UpsertEventDetailValidator()
        {
            RuleFor(x => x.EventDetailDescription).NotEmpty();
            RuleFor(x => x.EventDetailDate).NotEmpty();
            RuleFor(x => x.EventDetailStartTime).NotEmpty();
            RuleFor(x => x.EventDetailEndTime).NotEmpty().GreaterThan(x => x.EventDetailStartTime);

        }
    }
}
