using Infrastructure.Document.Models;
using Shared.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Document
{
    public class DocumentDataSeeder : IDataSeeder<DocumentDataContext>
    {
        static readonly object LockObject = new object();

        public void Seed(DocumentDataContext context)
        {


            if (!context.Projects.Any())
            {
                var projects = new List<Project>
                    {
                        new Project { ProjectName = "Project 1", CreatedDate = DateTime.UtcNow, IsDeleted = false },
                        new Project { ProjectName = "Project 2", CreatedDate = DateTime.UtcNow, IsDeleted = false }
                    };
                context.AddRange(projects);
                context.SaveChangesAsync().Wait();
            }

            if (!context.DocumentTypes.Any())
            {
                var documentTypes = new List<DocumentType>
                    {
                        new DocumentType { TypeName = "Type 1", ProjectId = 1, CreatedDate = DateTime.UtcNow, IsDeleted = false, OrderNo = 1 },
                        new DocumentType { TypeName = "Type 2", ProjectId = 2, CreatedDate = DateTime.UtcNow, IsDeleted = false, OrderNo = 2 }
                    };
                context.AddRange(documentTypes);
                context.SaveChangesAsync().Wait();
            }
           

        }

        public void SeedSample(DocumentDataContext context)
        {
        }
    }
}
