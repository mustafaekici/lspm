using Infrastructure.Document.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document
{
    public class DocumentDataContext : DbContextBase
    {
        public DocumentDataContext(DbContextOptions<DocumentDataContext> options) : base(options)
        {
        }

        protected override string DefaultSchema => "Doc";

        #region DbSets

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Infrastructure.Document.Models.Document> Documents { get; set; }

        #endregion
    }
}
