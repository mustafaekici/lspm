using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface IEntityMappingConfiguration
    {
        void Map(ModelBuilder b);
    }
}
