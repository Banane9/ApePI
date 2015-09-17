using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApePI
{
    internal class ApiPath
    {
        private readonly static char[] pathSeparator = new[] { '/' };

        private readonly static char[] querySeparator = new[] { '?' };

        private readonly static char[] queryFieldSeparator = new[] { '&' };

        private readonly Queue<ApiPathPart> remainingPathParts;

        internal ApiPath(string rawUrl)
        {
            var parts = new Queue<string>(WebUtility.UrlDecode(rawUrl).Split(pathSeparator, StringSplitOptions.RemoveEmptyEntries));

            while (parts.Count > 0)
            {
                var currentPart = parts.Dequeue().Split(querySeparator);
                var name = currentPart[0];
                var parameters = currentPart.Length > 1 ?
                    string.Join(querySeparator[0].ToString(), currentPart.Skip(1)).Split(queryFieldSeparator, StringSplitOptions.RemoveEmptyEntries)
                    : new string[0];
            }
        }

        internal ApiPathPart DequeueNextPart()
        {
            return remainingPathParts.Dequeue();
        }

        internal bool HasRemainingParts
        {
            get { return remainingPathParts.Count > 0; }
        }

        internal class ApiPathPart
        {
            internal string Name { get; private set; }

            internal IEnumerable<ApiPathParameter> Parameters { get; set; }

            internal class ApiPathParameter
            {
                internal string Name { get; private set; }

                internal string Value { get; private set; }

                internal bool TryParse<TResult>(out TResult result)
                {
                    try
                    {
                        result = (TResult)Convert.ChangeType(Value, typeof(TResult));
                        return true;
                    }
                    catch
                    {
                        result = default(TResult);
                        return false;
                    }
                }
            }
        }
    }
}