using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApePI
{
    internal class ApiMethod : IApiMethod
    {
        private readonly MethodInfo method;

        /// <summary>
        /// Gets whether authentication is required to call this method.
        /// </summary>
        public bool RequiresAuth
        {
            get { return method.IsAssembly; }
        }

        public ApiMethod(MethodInfo methodInfo)
        {
            method = methodInfo;
        }

        public object Invoke(object target, IEnumerable<string> path)
        {
            throw new NotImplementedException();
        }
    }
}