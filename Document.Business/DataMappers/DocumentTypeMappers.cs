

using Infrastructure.Document.Models;
using Shared.Contracts.Document.Model;

namespace Document.Business.DataMappers
{
    public static class DocumentTypeMappers
    {
        public static DocumentType ToEntity(this DocumentTypeDisplayModel displayModel)
        {
            return new DocumentType()
            {
                Id = displayModel.Id,
                TypeName = displayModel.TypeName,
                ProjectId = displayModel.ProjectId,
                CreatedDate = displayModel.CreatedDate,
                ModifiedDate = displayModel.LastModifiedDate
            };
        }

        public static DocumentTypeDisplayModel ToModel(this DocumentType entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new DocumentTypeDisplayModel()
            {
                Id = entity.Id,
                TypeName = entity.TypeName,
                ProjectId = entity.ProjectId,
                ProjectName = entity.Project.ProjectName ?? string.Empty,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.ModifiedDate,
                OrderNo = entity.OrderNo
            };
        }
    }
}