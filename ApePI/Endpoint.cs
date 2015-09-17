using ApePI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ApePI
{
    /// <summary>
    /// Contains information about an Endpoint of the API.
    /// </summary>
    internal class Endpoint
    {
        public MethodInfo MethodInfo { get; private set; }

        public Dictionary<string, ParameterInfo> OptionalParameters { get; private set; }

        public Dictionary<string, ParameterInfo> RequiredParameters { get; private set; }

        /// <summary>
        /// Gets whether authentication is required to GET this endpoint.
        /// </summary>
        public bool RequiresAuth
        {
            get { return MethodInfo.IsAssembly; }
        }

        public bool CanEndHere { get; private set; }

        public Endpoint(MethodInfo methodInfo)
        {
            MethodInfo = methodInfo;
            CanEndHere = !methodInfo.ReturnType.IsNoEndpoint();

            setupParameters(methodInfo);
        }

        private void setupParameters(MethodInfo methodInfo)
        {
            OptionalParameters = methodInfo.GetParameters().Where(parameter => parameter.IsOptional)
                .ToDictionary(parameter => parameter.Name.ToLowerInvariant());

            RequiredParameters = methodInfo.GetParameters().Where(parameter => !parameter.IsOptional)
                .ToDictionary(parameter => parameter.Name.ToLowerInvariant());
        }
    }
}