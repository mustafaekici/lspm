

using Shared.Contracts.Document.Model;

namespace Document.Business.DataMappers
{
    public static class DocumentMappers
    {
        public static Infrastructure.Document.Models.Document ToEntity(this DocumentDisplayModel model)
        {
            return new Infrastructure.Document.Models.Document();
        }

        public static DocumentDisplayModel ToModel(this Infrastructure.Document.Models.Document entity)
        {
            return new DocumentDisplayModel()
            {
                DocumentId = entity.Id,
                DocumentType = entity.DocumentType.TypeName ?? string.Empty,
                Project = entity.Project.ProjectName ?? string.Empty,
                ProjectId = entity.ProjectId,
                DocumentTypeId = entity.DocumentTypeId,
                FileName = entity.FileName,
                CreateDate = entity.CreatedDate,
                LastModifiedDate = entity.ModifiedDate
            };
        }
    }
}