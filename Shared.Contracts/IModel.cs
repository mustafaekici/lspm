using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts
{
    public interface IModel<T> where T : IComparable
    {
        T Id { get; set; }
    }
}
