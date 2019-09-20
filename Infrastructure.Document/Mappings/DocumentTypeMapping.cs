using Infrastructure.Document.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Mappings
{
    public class DocumentTypeMapping : EntityMappingConfiguration<DocumentType>
    {
        public override string TableName => "DocumentTypes";
        public override string Schema => "Doc";

        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.OrderNo).IsRequired();

            builder.Property(x => x.TypeName)
                .IsRequired()
                .HasMaxLength(150);

            builder.HasOne(x => x.Project)
                .WithMany(x => x.DocumentTypes)
                .HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
