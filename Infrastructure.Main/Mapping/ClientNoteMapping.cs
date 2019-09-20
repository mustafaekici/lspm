using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class ClientNoteMapping : EntityMappingConfiguration<ClientNote>
    {
        public override string TableName => "ClientNote";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<ClientNote> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.HasOne(p => p.Client)
                       .WithMany(p => p.ClientNotes)
                       .HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
