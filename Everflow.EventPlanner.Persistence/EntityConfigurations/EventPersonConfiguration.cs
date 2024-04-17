using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Domain.Features.People;
using Everflow.EventPlanner.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everflow.EventPlanner.Persistence.EntityConfigurations
{
    public class EventPersonConfiguration : EntityBaseConfiguration<EventPerson>
    {
        public override void Configure(EntityTypeBuilder<EventPerson> builder)
        {
            builder.ToTable(nameof(EventPerson));
            builder.Property(x => x.EventDetailId).IsRequired();
            builder.Property(x => x.PersonId).IsRequired();

            base.Configure(builder);
        }
    }
}
