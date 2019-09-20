using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF.Query
{
    public interface IConnectionConfiguration
    {
        string ConnectionString { get; set; }
        bool ConnectionPooling { get; set; }
    }
}
