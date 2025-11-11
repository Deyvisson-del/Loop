using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Loop.Infra.Data.Converters
{
    public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            v => v.ToTimeSpan(),
            v => TimeOnly.FromTimeSpan(v))
        { }
    }
}
