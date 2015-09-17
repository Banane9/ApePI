using ApePI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApePI
{
    internal class ApiTypeDetails
    {
        private readonly Type type;
        private readonly Dictionary<string, IApiMethod> apiMethods;

        public bool NoEndpoint { get; private set; }

        internal ApiTypeDetails(Type type)
        {
            this.type = type;
            apiMethods = collectApiMethods(type);
            NoEndpoint = type.IsNoEndpoint();
        }

        private static Dictionary<string, IApiMethod> collectApiMethods(Type type)
        {
            return type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy)
                .Where(methodInfo => !methodInfo.IsPrivate)
                .Concat(type.GetProperties().SelectMany(propertyInfo => new[] { propertyInfo.GetMethod, propertyInfo.SetMethod }))
                .GroupBy(methodInfo => methodInfo.Name)
                .ToDictionary(grouping => grouping.Key, grouping => grouping.Count() > 1 ?
                    (IApiMethod)new MultiApiMethod(grouping) : new ApiMethod(grouping.First()));
        }

        public IApiMethod GetApiMethod(string name)
        {
            if (!HasApiMethod(name))
                throw new ArgumentOutOfRangeException("name", "No Api Method with that name found.");

            return apiMethods[name];
        }

        public bool HasApiMethod(string name)
        {
            return apiMethods.ContainsKey(name);
        }
    }
}