using System;

namespace Kiwi.Json.Serialization.TypeBuilders
{
    public class EnumBuilder<TEnum> : AbstractTypeBuilder where TEnum: struct 
    {
        public override object CreateString(string value)
        {
            TEnum @enum;
            if (Enum.TryParse(value, false, out @enum))
            {
                return @enum;
            }
            return base.CreateString(value);
        }

        public override object CreateNumber(long value)
        {
            var @enum = Enum.ToObject(typeof (TEnum), value);
            return (TEnum)@enum;
        }
    }
}