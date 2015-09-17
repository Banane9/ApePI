using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ApePI
{
    public sealed class ApePI
    {
        private readonly HttpListener httpListener = new HttpListener();

        private readonly object root;

        private static readonly Type apiErrorType = typeof(ApiError);

        public static readonly List<Type> EndpointTypes = new List<Type>
        {
            typeof(object),
            typeof(string),
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(float),
            typeof(double),
            typeof(decimal),
        };

        internal static readonly Dictionary<Type, ApiTypeDetails> ApiDetails = new Dictionary<Type, ApiTypeDetails>();

        public ApePI(object root, params string[] prefixes)
        {
            this.root = root;

            var rootType = root.GetType();
            ApiDetails.Add(rootType, new ApiTypeDetails(rootType));

            foreach (var prefix in prefixes)
                httpListener.Prefixes.Add(prefix);
        }

        public void Start()
        {
            httpListener.Start();
        }

        public void Stop()
        {
            httpListener.Stop();
        }

        private void acceptRequests()
        {
            while (true)
            {
                var context = httpListener.GetContext();
                var path = new ApiPath(context.Request.RawUrl);
                var returnObject = getReturnObject(path);
            }
        }

        private object getReturnObject(ApiPath path)
        {
            var currentReturnObject = root;
            while (path.HasRemainingParts)
            {
                var currentPathPart = path.DequeueNextPart();
                var currentApiDetails = ApiDetails[currentReturnObject.GetType()];

                if (!currentApiDetails.HasApiMethod(currentPathPart.Name))
                    return new ApiError("Incorrect Path");

                //currentReturnObject = currentApiDetails.GetApiMethod(currentPathPart.Name).Invoke(currentReturnObject, currentPathPart.Parameters);

                if (currentReturnObject == null || currentReturnObject.GetType() == apiErrorType)
                    break;
            }

            return path.HasRemainingParts ? new ApiError("Incorrect Path") : currentReturnObject;
        }
    }
}