using Everflow.EventPlanner.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Everflow.EventPlanner.Persistence.Common
{
    public class EntityBaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(t => t.CreatedDateTime)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
