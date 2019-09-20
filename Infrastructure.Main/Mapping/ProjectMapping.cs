using Infrastructure.Main.Models;
using Shared.Core.EF;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Main.Mapping
{
    public class ProjectMapping : EntityMappingConfiguration<Project>
    {
        public override string TableName => "Project";

        public override string Schema => "Pm";

        public override void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.CreatedDate).IsRequired();
            builder.HasOne(p => p.SiteAddress)
                .WithMany(p => p.SiteAddresses)
                .HasForeignKey(p => p.SiteAddressId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ClientId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.ProjectManager)
                .WithMany(p => p.ProjectManagers)
                .HasForeignKey(p => p.ProjectManagerId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.InitialContact)
            .WithMany(p => p.InitialContacts)
            .HasForeignKey(p => p.InitialContactId).IsRequired(false).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.ProjectStatus)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.ProjectStatusId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(p => p.BillingStatus)
                .WithMany(p => p.Projects)
                .HasForeignKey(p => p.BillingStatusId).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.Property(x => x.ProjectName).HasMaxLength(60);
        }
    }
}
