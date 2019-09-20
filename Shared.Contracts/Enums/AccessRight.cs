using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Contracts.Enums
{
    [Flags]
    public enum AccessRight
    {
        None = 0,
        Read = 1,
        Write = 2,
        Edit = 4,
        Delete = 8,

        ReadAndWrite = Read | Write,
        ReadAndEdit = Read | Edit,
        ReadAndDelete = Read | Delete,
        WriteAndEdit = Write | Edit,
        WriteAndDelete = Write | Delete,
        EditAndDelete = Edit | Delete,

        ReadAndWriteAndEdit = Read | Write | Edit,
        ReadAndWriteAndDelete = Read | Write | Delete,
        ReadAndEditAndDelete = Read | Edit | Delete,
        WriteAndEditAndDelete = Write | Edit | Delete,
        FullAccess = Read | Write | Edit | Delete,
    }
}
