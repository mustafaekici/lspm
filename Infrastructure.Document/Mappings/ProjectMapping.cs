using Infrastructure.Document.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document.Mappings
{
    public class ProjectMapping : EntityMappingConfiguration<Project>
    {
        public override string TableName => "Projects";
        public override string Schema => "Doc";

        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.ProjectName)
                .IsRequired()
                .HasMaxLength(100); 
        }
    }
}
