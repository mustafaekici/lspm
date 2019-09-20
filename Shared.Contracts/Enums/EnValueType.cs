using System;

namespace Shared.Contracts.Enums
{
    [Flags]
    public enum EnValueType
    {
        Text = 0x1,
        Number = 0x2,
        Checkbox = 0x4,
        DatePicker = 0x8,
        Select = 0x10,
        All = 0x1F
    }
}
