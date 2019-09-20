

using Infrastructure.Document.Models;
using Shared.Contracts.Document.Model;

namespace Document.Business.DataMappers
{
    public static class ProjectMappers
    {
        public static Project ToEntity(this ProjectDisplayModel displayModel)
        {
            return new Project()
            {
                Id = displayModel.Id,
                ProjectName = displayModel.Name,
                CreatedDate = displayModel.CreatedDate,
                ModifiedDate = displayModel.LastModifiedDate
            };
        }

        public static ProjectDisplayModel ToModel(this Project entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProjectDisplayModel()
            {
                Id = entity.Id,
                Name = entity.ProjectName,
                CreatedDate = entity.CreatedDate,
                LastModifiedDate = entity.ModifiedDate
            };
        }
    }
}