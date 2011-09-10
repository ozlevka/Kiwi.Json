﻿using Kiwi.Json.Untyped;

namespace Kiwi.Json.Conversion
{
    public class ToJsonBool : IToJson
    {
        #region IToJson Members

        public IJsonValue ToJson(object value, IToJsonContext context)
        {
            return context.CreateBool((bool) value);
        }

        #endregion
    }
}