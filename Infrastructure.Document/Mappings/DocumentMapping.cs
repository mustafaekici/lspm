using Infrastructure.Document.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Mappings
{
    public class DocumentMapping : EntityMappingConfiguration<Models.Document>
    {
        public override string TableName => "Documents";
        public override string Schema => "Doc";

        public override void Configure(EntityTypeBuilder<Models.Document> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Content).IsRequired();
            builder.Property(p => p.FileName).IsRequired();
            builder.Property(p => p.CreatedDate).IsRequired();

            builder.HasOne(p => p.DocumentType)
                .WithMany(p => p.Documents)
                .HasForeignKey(p => p.DocumentTypeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Project)
                .WithMany(p => p.Documents)
                .HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
