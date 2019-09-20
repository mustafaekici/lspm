using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class ClientRatingMapping : EntityMappingConfiguration<ClientRating>
    {
        public override string TableName => "ClientRating";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<ClientRating> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.Property(x => x.Raiting)
               .IsRequired()
               .HasMaxLength(40);
        }
    }
}
