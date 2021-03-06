using Kiwi.Json.Conversion;
using Kiwi.Json.Converters;

namespace Kiwi.Json.Tests.Conversion
{
    public class DataTableAsObjectArrayConverterFixture : DataTableConverterFixtureBase
    {
        protected override IJsonConverter CreateDatatableConverter()
        {
            return new DataTableAsObjectArrayConverter();
        }
    }
}