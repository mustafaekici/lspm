using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class ClientMapping : EntityMappingConfiguration<Client>
    {
        public override string TableName => "Client";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(x => x.FirstName).HasMaxLength(100);
            builder.Property(x => x.LastName).HasMaxLength(100);
            builder.Property(x => x.WebAddress).HasMaxLength(100);
            builder.HasOne(p => p.ClientRating)
             .WithMany(p => p.Clients)
             .HasForeignKey(p => p.ClientRatingId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ContactType)
            .WithMany(p => p.Clients)
            .HasForeignKey(p => p.ContactTypeId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
