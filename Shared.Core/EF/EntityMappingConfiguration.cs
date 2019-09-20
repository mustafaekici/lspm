using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public abstract class EntityMappingConfiguration<T> : IEntityMappingConfiguration,
           IEntityTypeConfiguration<T> where T : class

    {
        public bool IgnoreLastModifiedShadowProperties { get; set; }
        public bool IgnoreKeyColumnMapping { get; set; }

        public abstract void Configure(EntityTypeBuilder<T> builder);

        public abstract string TableName { get; }

        public abstract string Schema { get; }

        public void Map(ModelBuilder b)
        {
            var builder = b.Entity<T>().ToTable(TableName, Schema);

            if (!IgnoreKeyColumnMapping)
            {
                builder.HasKey("Id");
                if (builder.Metadata.ClrType == typeof(Guid))
                    builder.Property("Id").HasDefaultValueSql("newsequentialid()");
            }

            if (!IgnoreLastModifiedShadowProperties)
            {
                //todo:builder
            }

            if (typeof(T) is ISoftDelete)
                builder.HasQueryFilter(x => !((ISoftDelete)x).IsDeleted);

            Configure(builder);
        }
    }
}
