using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class ContactTypeMapping : EntityMappingConfiguration<ContactType>
    {
        public override string TableName => "ContactType";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<ContactType> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(x => x.ContactTypeName)
               .IsRequired()
               .HasMaxLength(40);

        }
    }
}
