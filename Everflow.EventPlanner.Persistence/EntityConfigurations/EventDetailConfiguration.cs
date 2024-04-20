using Everflow.EventPlanner.Domain.Features.Events;
using Everflow.EventPlanner.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everflow.EventPlanner.Persistence.EntityConfigurations
{
    public class EventDetailConfiguration : EntityBaseConfiguration<EventDetail>
    {
        public override void Configure(EntityTypeBuilder<EventDetail> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(EventDetail));
            builder.Property(x => x.EventDetailDescription);
            builder.Property(x => x.EventDetailDate).IsRequired();
            builder.Property(x => x.EventDetailStartTime).IsRequired();
            builder.Property(x => x.EventDetailEndTime).IsRequired();

        }
    }
}
