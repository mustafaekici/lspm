

using Shared.Contracts.Attributes;

namespace Shared.Contracts.Enums
{
    public enum EnComparisonOperation
    {
        [ContractMeta("Equals")]
        [ComparisonUsage(EnValueType.All)]
        Equals = 1,

        [ContractMeta("Not equal")]
        [ComparisonUsage(EnValueType.All)]
        NotEqual = 2,

        [ContractMeta("Greater or equal")]
        [ComparisonUsage(EnValueType.Number | EnValueType.DatePicker)]
        GreaterOrEqual = 3,

        [ContractMeta("Less or equal")]
        [ComparisonUsage(EnValueType.Number | EnValueType.DatePicker)]
        LessOrEqual = 4,

        [ContractMeta("Greater than")]
        [ComparisonUsage(EnValueType.Number | EnValueType.DatePicker)]
        GreaterThan = 5,

        [ContractMeta("Less than")]
        [ComparisonUsage(EnValueType.Number | EnValueType.DatePicker)]
        LessThan = 6,

        [ContractMeta("Contains")]
        [ComparisonUsage(EnValueType.Text)]
        Contains = 7,

        [ContractMeta("Doesn't contain")]
        [ComparisonUsage(EnValueType.Text)]
        DoNotContain = 8,

        [ContractMeta("Starts with")]
        [ComparisonUsage(EnValueType.Text)]
        StartsWith = 9,

        [ContractMeta("Ends with")]
        [ComparisonUsage(EnValueType.Text)]
        EndsWith = 10,

        [ContractMeta("In")]
        [ComparisonUsage(EnValueType.Text | EnValueType.Number | EnValueType.Select)]
        In = 11,

        [ContractMeta("Not In")]
        [ComparisonUsage(EnValueType.Text | EnValueType.Number | EnValueType.Select)]
        NotIn = 12,

        [ContractMeta("Contains Any")]
        [ComparisonUsage(EnValueType.Text)]
        ContainsAny = 13,

        [ContractMeta("Not Contains Any")]
        [ComparisonUsage(EnValueType.Text)]
        NotContainsAny = 14,

        [ContractMeta("Doesn't Start with")]
        [ComparisonUsage(EnValueType.Text)]
        NotStartsWith = 15,

        [ContractMeta("Doesn't End with")]
        [ComparisonUsage(EnValueType.Text)]
        NotEndsWith = 16,
    }
}