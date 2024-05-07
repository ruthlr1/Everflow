using Everflow.EventPlanner.Domain.Features.People;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.Persistence.Common;
using Everflow.EventPlanner.Domain.Features.Events;

namespace Everflow.EventPlanner.Persistence.EntityConfigurations
{
    public class PersonConfiguration : EntityBaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            base.Configure(builder);
            builder.ToTable(nameof(Person));
            builder.Property(x => x.FirstName);
            builder.Property(x => x.LastName);
            builder.Property(x => x.EmailAddress);
            builder.Property(x => x.Password);
        }
    }
}