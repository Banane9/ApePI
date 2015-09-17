using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApePI
{
    internal interface IApiMethod
    {
        object Invoke(object target, IEnumerable<string> path);
    }
}