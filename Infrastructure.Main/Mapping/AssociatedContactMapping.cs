using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class AssociatedContactMapping : EntityMappingConfiguration<AssociatedContact>
    {
        public override string TableName => "AssociatedContact";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<AssociatedContact> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.HasOne(p => p.Client)
                       .WithMany(p => p.Clients)
                       .HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.AssociatedClient)
                     .WithMany(p => p.AssociatedClients)
                     .HasForeignKey(p => p.AssociatedClientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
