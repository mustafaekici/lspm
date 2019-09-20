using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface IDataSeeder<in T> where T : DbContext
    {
        void Seed(T context);
        void SeedSample(T context);
    }
}
