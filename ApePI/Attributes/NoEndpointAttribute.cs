using System;
using System.Collections.Generic;
using System.Linq;

namespace ApePI.Attributes
{
    /// <summary>
    /// Marks a Type as not being an Endpoint of the API.
    /// That is, something the path can end with.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    public sealed class NoEndpointAttribute : Attribute
    {
    }

    internal static class NoEndpointAttributeExtension
    {
        public static bool IsNoEndpoint(this Type type)
        {
            if (type == null)
                return false;

            return type.GetCustomAttributes(typeof(NoEndpointAttribute), false).Any();
        }
    }
}