using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Kiwi.Json.Conversion.TypeBuilders
{
    public class CollectionBuilderFactory: ITypeBuilderFactory
    {
        public Func<ITypeBuilder> CreateTypeBuilder(Type type, ITypeBuilderRegistry registry)
        {
            // Check which ICollection<T> is implemented
            var interfaceType = (from @interface in new[] { type }.Concat(type.GetInterfaces())
                                 where
                                     @interface.IsGenericType &&
                                     @interface.GetGenericTypeDefinition() == typeof(ICollection<>)
                                 select @interface)
                .FirstOrDefault();

            if (interfaceType == null)
            {
                // Check if it is IEnumerable<T>
                interfaceType = (from @interface in new[] { type }.Concat(type.GetInterfaces())
                                 where
                                     @interface.IsGenericType &&
                                     @interface.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                                 select @interface)
                    .FirstOrDefault();
            }
            if (interfaceType == null)
            {
                return null;
            }

            var elementType = interfaceType.GetGenericArguments()[0];

            // Determine concrete ICollection<T> to instantiate
            var listType = type.IsInterface
                               ? typeof(List<>).MakeGenericType(elementType)
                               : type;

            if (!type.IsAssignableFrom(listType))
            {
                return null;
            }

            // List must have default constructor
            if (listType.GetConstructor(Type.EmptyTypes) == null)
            {
                return null;
            }

            return
                (Func<ITypeBuilder>)
                typeof(CollectionBuilder<,>).MakeGenericType(listType, interfaceType.GetGenericArguments()[0]).GetMethod(
                    "CreateTypeBuilderFactory", BindingFlags.Static | BindingFlags.Public).Invoke(null, new object[]{registry});
        }
    }
}