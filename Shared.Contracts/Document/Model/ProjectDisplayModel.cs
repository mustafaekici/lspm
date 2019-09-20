using System;

namespace Shared.Contracts.Document.Model
{
    public class ProjectDisplayModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}