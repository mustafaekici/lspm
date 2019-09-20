using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.EF
{
    public interface IEntity<T> where T : IComparable
    {
        T Id { get; set; }
    }
}
