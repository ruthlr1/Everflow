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

            Type type = typeof(TEntity);
            foreach(var prop in  type.GetProperties())
            {
                if(prop.PropertyType == typeof(string))
                    builder.Property(prop.Name).HasMaxLength(150);
            }
        }
    }
}
