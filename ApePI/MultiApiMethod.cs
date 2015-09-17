using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApePI
{
    internal class MultiApiMethod : IApiMethod
    {
        private readonly List<ApiMethod> methods;

        public MultiApiMethod(IEnumerable<MethodInfo> methodInfos)
        {
            methods = methodInfos.Select(methodInfo => new ApiMethod(methodInfo)).ToList();
        }

        public object Invoke(object target, IEnumerable<string> path)
        {
            throw new NotImplementedException();
        }
    }
}