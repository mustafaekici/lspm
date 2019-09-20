using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Document
{
    public class DocumentConnectionConfiguration : IDocumentConnectionConfiguration
    {
        public string ConnectionString { get; set; }
        public bool ConnectionPooling { get; set; }
    }
}
