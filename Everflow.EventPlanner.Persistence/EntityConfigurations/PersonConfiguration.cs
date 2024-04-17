using Everflow.EventPlanner.Domain.Features.People;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Everflow.EventPlanner.Persistence.Common;

namespace Everflow.EventPlanner.Persistence.EntityConfigurations
{
    public class PersonConfiguration : EntityBaseConfiguration<Person>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.EmailAddress).HasMaxLength(100);

            base.Configure(builder);
        }
    }
}