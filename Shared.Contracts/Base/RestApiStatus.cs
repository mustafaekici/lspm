using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Base
{
    /// <summary>
    ///  Validation or exception are status type
    /// </summary>
    public enum RestApiStatus
    {
        None = 0,
        Ok = 1,
        ValidationError = 2,
        BusinessException = 3,
        UnhandledException = 4,
        NotFoundException = 5
    }

    /// <summary>
    ///  Rest Api Sub Status
    /// </summary>
    public enum RestApiSubStatus
    {
        None = 0,
        Ok = 1
    }
}
