using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class AddressMapping : EntityMappingConfiguration<Address>
    {
        public override string TableName => "Address";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(x => x.AddressLine1).HasMaxLength(128);
            builder.Property(x => x.AddressLine1).HasMaxLength(128);
            builder.Property(x => x.PostalCode).HasMaxLength(16);
            //builder.HasOne(p => p.AddressType)
            // .WithMany(p => p.Adresses)
            // .HasForeignKey(p => p.AddressTypeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.City)
            .WithMany(p => p.Adresses)
            .HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
