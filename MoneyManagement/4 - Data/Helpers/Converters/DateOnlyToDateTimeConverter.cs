using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Helpers.Converters
{
    internal class DateOnlyToDateTimeConverter : ValueConverter<DateOnly, DateTime>
    {
        // NOTE: base(convertToProviderExpression, convertFromProviderExpression)
        public DateOnlyToDateTimeConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => DateOnly.FromDateTime(d))
        {}
    }
}
