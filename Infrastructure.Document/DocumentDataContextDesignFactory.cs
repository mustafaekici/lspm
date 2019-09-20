using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Document
{
    public class DocumentDataContextDesignFactory : IDesignTimeDbContextFactory<DocumentDataContext>
    {
        public DocumentDataContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DocumentDataContext>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=LSDocument;Integrated Security=true;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(DocumentDataContext).GetTypeInfo().Assembly.GetName().Name)
                .MigrationsHistoryTable("MigrationHistory", "Doc")
                );
            return new DocumentDataContext(builder.Options);
        }
    }
}
