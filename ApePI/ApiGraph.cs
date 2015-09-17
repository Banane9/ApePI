using ApePI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ApePI
{
    /// <summary>
    /// Contains the different options for the API access of a Type.
    /// </summary>
    internal sealed class ApiGraph
    {
        /// <summary>
        /// Gets a dictionary containing method endpoints mapped to the method name.
        /// </summary>
        public Dictionary<string, Endpoint> Endpoints { get; private set; }

        /// <summary>
        /// Gets a dictionary containing ApiGraphs mapped to the property name.
        /// </summary>
        public Dictionary<string, ApiGraph> Paths { get; private set; }

        public ApiGraph(Type rootType)
        {
            setupMethodEndpoints(rootType);
            setupPropertyEndpointsAndPaths(rootType);
        }

        private void setupMethodEndpoints(Type rootType)
        {
            foreach (var methodInfo in rootType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if (methodInfo.IsPrivate)
                    continue;

                Endpoints.Add(methodInfo.Name.ToLowerInvariant(), new Endpoint(methodInfo));
            }
        }

        private void setupPropertyEndpointsAndPaths(Type rootType)
        {
            foreach (var propertyInfo in rootType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                if ((propertyInfo.GetMethod == null || propertyInfo.GetMethod.IsPrivate)
                 && (propertyInfo.SetMethod == null || propertyInfo.SetMethod.IsPrivate))
                    continue;

                if (propertyInfo.PropertyType.IsNoEndpoint())
                    Paths.Add(propertyInfo.Name.ToLowerInvariant(), new ApiGraph(propertyInfo.PropertyType));
                //else
                //    PropertyEndpoints.Add(propertyInfo.Name.ToLowerInvariant(), new PropertyEndpoint(propertyInfo));
            }
        }
    }
}