using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApePI
{
    internal class ApiError
    {
        public string Error { get; private set; }

        public ApiError(string error)
        {
            Error = error;
        }
    }
}