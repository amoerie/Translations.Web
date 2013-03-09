﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Translations.Core.Extensions
{
    public static class ExtensionsForType
    {
        private static readonly Func<MethodInfo, IEnumerable<Type>> ParameterTypeProjection =
        method => method.GetParameters()
                        .Select(p => p.ParameterType.GetGenericTypeDefinition());

        public static MethodInfo GetGenericMethod(this Type type, string name, params Type[] parameterTypes)
        {
            return (from method in type.GetMethods()
                    where method.Name == name
                    where parameterTypes.SequenceEqual(ParameterTypeProjection(method))
                    select method).SingleOrDefault();
        }
    }
}
