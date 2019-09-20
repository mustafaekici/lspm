using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class AddressTypeMapping : EntityMappingConfiguration<AddressType>
    {
        public override string TableName => "AddressType";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<AddressType> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(x => x.AddressTypeName)
               .IsRequired()
               .HasMaxLength(40);
     

        }
    }
}
